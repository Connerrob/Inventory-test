using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsAppColby
{
    public partial class InvoiceForm : Form
    {
        private List<InventoryItem> selectedItems;
        private InventoryManager inventoryManager;
        private int invoiceCounter;
        private string InvoiceNumberFilePath;

        public InvoiceForm(List<InventoryItem> items, InventoryManager manager)
        {
            InitializeComponent();
            selectedItems = items;
            inventoryManager = manager;
            InvoiceNumberFilePath = "InvoiceNumber.txt";
            invoiceCounter = GetLastInvoiceNumber() + 1;
            CollectAndAddAdditionalRow();
        }

        // Method to collect input for last row of table
        private void CollectAndAddAdditionalRow()
        {
            decimal additionalQuantity;
            decimal additionalRate;
            string customerName;
            string contactInfo;

            if (CollectAdditionalRowInput(out additionalQuantity, out additionalRate, out customerName, out contactInfo))
            {
                // Add the additional row to selectedItems
                selectedItems.Add(new InventoryItem
                {
                    QuantityUsed = additionalQuantity,
                    PartNumber = "Labor",
                    Price = additionalRate,
                    Total = additionalQuantity * additionalRate,
                    CustomerName = customerName,
                    ContactInfo = contactInfo
                });
            }
            else
            {
                // Cancel the generation of the invoice
                return;
            }
        }

        // Method to collect input for an additional row
        private bool CollectAdditionalRowInput(out decimal quantity, out decimal rate, out string customerName, out string contactInfo)
        {
            quantity = 0;
            rate = 0;
            customerName = "";
            contactInfo = "";

            using (var inputForm = new Form())
            {
                // Create controls for user input
                var quantityLabel = new Label { Text = "Hours:", Top = 10, Left = 10 };
                var quantityTextBox = new TextBox { Top = 10, Left = 120, Width = 150 };

                var rateLabel = new Label { Text = "Rate:", Top = 40, Left = 10 };
                var rateTextBox = new TextBox { Top = 40, Left = 120, Width = 150 };

                var nameInputLabel = new Label { Text = "Customer Name:", Top = 70, Left = 10 };
                var nameTextBox = new TextBox { Top = 70, Left = 120, Width = 150 };

                var contactInfoInputLabel = new Label { Text = "Contact Information:", Top = 100, Left = 10 };
                var contactInfoTextBox = new TextBox { Top = 100, Left = 120, Width = 150 };

                var confirmButton = new Button { Text = "Confirm", DialogResult = DialogResult.OK, Top = 130, Left = 10 };
                var cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Top = 130, Left = 80 };

                // Add controls to the form
                inputForm.Controls.AddRange(new Control[] { quantityLabel, quantityTextBox, rateLabel, rateTextBox, nameInputLabel, nameTextBox, contactInfoInputLabel, contactInfoTextBox, confirmButton, cancelButton });

                // Show the form
                var result = inputForm.ShowDialog();

                // Process user input
                if (result == DialogResult.OK)
                {
                    if (decimal.TryParse(quantityTextBox.Text, out quantity) && decimal.TryParse(rateTextBox.Text, out rate))
                    {
                        customerName = nameTextBox.Text;
                        contactInfo = contactInfoTextBox.Text;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                // User canceled or closed the form
                return false;
            }
        }

        // Method to retrieve the last used invoice number
        private int GetLastInvoiceNumber()
        {
            int lastInvoiceNumber = 1000;

            if (File.Exists(InvoiceNumberFilePath))
            {
                string content = File.ReadAllText(InvoiceNumberFilePath);
                if (int.TryParse(content, out lastInvoiceNumber))
                {
                    return lastInvoiceNumber;
                }
                else
                {
                    // Log or handle the case where the content is not a valid integer
                }
            }

            return lastInvoiceNumber;
        }

        // Method to update the invoice counter
        private void UpdateInvoiceCounter()
        {
            File.WriteAllText(InvoiceNumberFilePath, invoiceCounter.ToString());
        }

        // Method to generate an invoice number
        private string GenerateInvoiceNumber()
        {
            string preFix = "Invoice";
            string sequentialNumber = invoiceCounter.ToString("D4");
            return $"{preFix} #{sequentialNumber}";
        }

        // Method to generate an invoice
        private void GenerateInvoice()
        {
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                string invoiceNumber = GenerateInvoiceNumber();
                string currentDate = DateTime.Now.ToString("MMMM dd, yyyy");

                GenerateInvoiceContent(gfx, page.Width, page.Height, currentDate, invoiceNumber);

                string customerName = selectedItems.LastOrDefault()?.CustomerName ?? "N_A";
                string filePath = $@"D:\conne\Documents\{customerName}_{invoiceNumber}.pdf";
                document.Save(filePath);

                UpdateInvoiceCounter();

                MessageBox.Show($"Invoice {GenerateInvoiceNumber()} saved successfully at {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenPdfFile(filePath);
            }
        }

        // Method to generate content for the invoice
        private void GenerateInvoiceContent(XGraphics gfx, XUnit pageWidth, XUnit pageHeight, string currentDate, string invoiceNumber)
        {
            string companyName = "Robeson Hydraulics LLC.";
            string ownerName = "Colby Robeson";
            string ownerContact = "Contact: 123-345-6789";

            string customerName = selectedItems.LastOrDefault()?.CustomerName ?? "N/A";
            string contactInfo = selectedItems.LastOrDefault()?.ContactInfo ?? "N/A";

            int yOffset = 140;
            float rightPadding = 475;
            float paddingDate = 40;

            XStringFormat rightAlignment = new XStringFormat
            {
                Alignment = XStringAlignment.Far,
                LineAlignment = XLineAlignment.Near
            };

            decimal subtotal = selectedItems.Sum(item => item.Total);
            decimal taxRate = 0.07m;
            decimal taxTotal = subtotal * taxRate;
            decimal total = subtotal + taxTotal;

            XFont companyFont = new XFont("Arial", 24, XFontStyle.Bold);
            XRect companyRect = new XRect(0, 20, pageWidth, 40);

            // Draw company information with centered alignment
            gfx.DrawString(companyName, companyFont, XBrushes.Black, companyRect, XStringFormats.Center);

            XFont ownerFont = new XFont("Arial", 12, XFontStyle.Regular);
            XRect ownerRect = new XRect(10, 80, pageWidth, 20);

            // Draw owner information
            gfx.DrawString($"Owner: {ownerName}", ownerFont, XBrushes.Black, ownerRect, XStringFormats.TopLeft);
            ownerRect = new XRect(10, 100, pageWidth, 20);
            gfx.DrawString(ownerContact, ownerFont, XBrushes.Black, ownerRect, XStringFormats.TopLeft);

            // Draw customer information
            XRect customerRect = new XRect(10, 180, pageWidth, 20);
            gfx.DrawString($"Customer: {customerName}", ownerFont, XBrushes.Black, customerRect, XStringFormats.TopLeft);
            customerRect = new XRect(10, 200, pageWidth, 20);
            gfx.DrawString($"Contact: {contactInfo}", ownerFont, XBrushes.Black, customerRect, XStringFormats.TopLeft);

            XFont dateFont = new XFont("Arial", 12, XFontStyle.Regular);
            XRect dateRect = new XRect(10, yOffset, pageWidth - 10 - paddingDate, 20);

            XFont font = new XFont("Arial", 12, XFontStyle.Regular);

            gfx.DrawLine(XPens.Black, 10, yOffset - 10, pageWidth - 10, yOffset - 10);

            // Draw the invoice number above the line
            gfx.DrawString($"{invoiceNumber}", dateFont, XBrushes.Black, new XRect(10, yOffset - 30, pageWidth - 10 - paddingDate, 20), rightAlignment);

            yOffset += 40;

            // Draw the current date below the line
            gfx.DrawString($"{currentDate}", dateFont, XBrushes.Black, dateRect, rightAlignment);
            yOffset += 20;

            yOffset += 60;

            XFont headerFont = new XFont("Arial", 12, XFontStyle.Bold);
            int headerYOffset = yOffset;

            double columnWidth = (pageWidth - 20) / 4;

            // Draw table headers
            gfx.DrawString("Quantity", headerFont, XBrushes.Black, new XRect(10, yOffset, columnWidth, 20), XStringFormats.TopLeft);
            gfx.DrawString("Part", headerFont, XBrushes.Black, new XRect(10 + columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);
            gfx.DrawString("Price", headerFont, XBrushes.Black, new XRect(10 + 2 * columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);
            gfx.DrawString("Total", headerFont, XBrushes.Black, new XRect(10 + 3 * columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);

            yOffset += 20;

            gfx.DrawLine(XPens.Black, 10, yOffset, pageWidth - 10, yOffset);

            // Iterate through selectedItems and add information to the document
            foreach (var item in selectedItems)
            {
                gfx.DrawLine(XPens.Black, 10, yOffset, pageWidth - 10, yOffset);

                gfx.DrawString(item.QuantityUsed.ToString(), font, XBrushes.Black, new XRect(10, yOffset, columnWidth, 20), XStringFormats.TopLeft);
                gfx.DrawString(item.PartNumber, font, XBrushes.Black, new XRect(10 + columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);
                gfx.DrawString(item.Price.ToString("C2"), font, XBrushes.Black, new XRect(10 + 2 * columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);
                gfx.DrawString(item.Total.ToString("C2"), font, XBrushes.Black, new XRect(10 + 3 * columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);

                yOffset += 20;
            }

            decimal partsTotal = selectedItems.Sum(item => item.Total);

            yOffset += 20;

            gfx.DrawString($"Subtotal:", font, XBrushes.Black, new XRect(10, yOffset, pageWidth - 10 - rightPadding, 20), XStringFormats.TopLeft);
            gfx.DrawString($"{subtotal:C2}", font, XBrushes.Black, new XRect(10, yOffset, pageWidth - 10 - rightPadding, 20), rightAlignment);
            yOffset += 20;

            gfx.DrawString($"Tax Total:", font, XBrushes.Black, new XRect(10, yOffset, pageWidth - 10 - rightPadding, 20), XStringFormats.TopLeft);
            gfx.DrawString($"{taxTotal:C2}", font, XBrushes.Black, new XRect(10, yOffset, pageWidth - 10 - rightPadding, 20), rightAlignment);
            yOffset += 20;

            yOffset += 10;
            gfx.DrawLine(XPens.Black, 10, yOffset - 10, pageWidth - 10, yOffset - 10);

            gfx.DrawString($"Total:", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XRect(10, yOffset, pageWidth - 10 - rightPadding, 20), XStringFormats.TopLeft);
            gfx.DrawString($"{total:C2}", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XRect(10, yOffset, pageWidth - 10 - rightPadding, 20), rightAlignment);
            yOffset += 20;
        }

        // Method to open the generated PDF file
        private void OpenPdfFile(string filePath)
        {
            try
            {
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the PDF file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the "Generate PDF" button click
        private void generatePDFButton_Click(object sender, EventArgs e)
        {
            GenerateInvoice();
        }
    }
}