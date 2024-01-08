using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsAppColby
{
    public partial class InvoiceForm : Form
    {
        private List<InventoryItem> selectedItems;
        private InventoryManager inventoryManager;

        public InvoiceForm(List<InventoryItem> items, InventoryManager manager)
        {
            InitializeComponent();
            this.selectedItems = items;
            this.inventoryManager = manager;
        }

        private void GenerateInvoice()
        {
            // Create a PDF document
            using (PdfDocument document = new PdfDocument())
            {
                // Create a single page
                PdfPage page = document.AddPage();

                // Create a drawing object
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Add content to the PDF
                GenerateInvoiceContent(gfx, page.Width, page.Height);

                // Save the document to a file
                string filePath = @"D:\conne\Documents\Invoice.pdf";
                document.Save(filePath);

                MessageBox.Show($"Invoice saved successfully at {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GenerateInvoiceContent(XGraphics gfx, XUnit pageWidth, XUnit pageHeight)
        {
            // Set up company information
            string companyName = "Robeson Hydraulic";
            string ownerName = "Colby Robeson";
            string ownerContact = "Contact: 123-345-6789";

            int yOffset = 140;
            float rightPadding = 475;
            float paddingDate = 40;

            XStringFormat rightAlignment = new XStringFormat
            {
                Alignment = XStringAlignment.Far,
                LineAlignment = XLineAlignment.Near
            };

            // Calculate subtotal, tax total, and total
            decimal subtotal = selectedItems.Sum(item => item.Total);
            decimal taxRate = 0.07m; 
            decimal taxTotal = subtotal * taxRate;
            decimal total = subtotal + taxTotal;


            // Set up font and position for company information
            XFont companyFont = new XFont("Arial", 24, XFontStyle.Bold); // Larger font size for company name
            XRect companyRect = new XRect(0, 20, pageWidth, 40); // Centered position

            // Draw company information with centered alignment
            gfx.DrawString(companyName, companyFont, XBrushes.Black, companyRect, XStringFormats.Center);

            // Set up font and position for owner information
            XFont ownerFont = new XFont("Arial", 12, XFontStyle.Regular);
            XRect ownerRect = new XRect(10, 80, pageWidth, 20);

            // Draw owner information
            gfx.DrawString($"Owner: {ownerName}", ownerFont, XBrushes.Black, ownerRect, XStringFormats.TopLeft);
            ownerRect = new XRect(10, 100, pageWidth, 20);
            gfx.DrawString(ownerContact, ownerFont, XBrushes.Black, ownerRect, XStringFormats.TopLeft);


            XFont dateFont = new XFont("Arial", 12, XFontStyle.Regular);
            XRect dateRect = new XRect(10, yOffset, pageWidth - 10 - paddingDate, 20);
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy"); // Format the date as desired
            
            // Draw the current date
            gfx.DrawString($"{currentDate}", dateFont, XBrushes.Black, dateRect, rightAlignment  );
            yOffset += 20; // Increment yOffset for spacing


            // Set up font and position for invoice details
            yOffset = 140; 
            XFont font = new XFont("Arial", 12, XFontStyle.Regular);


            // Draw a horizontal line to separate sections
            gfx.DrawLine(XPens.Black, 10, yOffset - 10, pageWidth - 10, yOffset - 10);

            // Increase yOffset for spacing between first line and table
            yOffset += 60;

            // Draw table headers
            XFont headerFont = new XFont("Arial", 12, XFontStyle.Bold);
            int headerYOffset = yOffset; // Adjusted starting position for headers

            // Calculate the width of each column
            double columnWidth = (pageWidth - 20) / 4;

            // Draw table headers
            gfx.DrawString("Quantity", headerFont, XBrushes.Black, new XRect(10, yOffset, columnWidth, 20), XStringFormats.TopLeft);
            gfx.DrawString("Part", headerFont, XBrushes.Black, new XRect(10 + columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);
            gfx.DrawString("Price", headerFont, XBrushes.Black, new XRect(10 + 2 * columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);
            gfx.DrawString("Total", headerFont, XBrushes.Black, new XRect(10 + 3 * columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);

            // Increment yOffset for content
            yOffset += 20;

            // Draw grid lines
            gfx.DrawLine(XPens.Black, 10, yOffset, pageWidth - 10, yOffset); // Horizontal line

            // Iterate through selectedItems and add information to the document
            foreach (var item in selectedItems)
            {
                // Draw grid lines between rows
                gfx.DrawLine(XPens.Black, 10, yOffset, pageWidth - 10, yOffset);

                // Draw table content
                gfx.DrawString(item.QuantityUsed.ToString(), font, XBrushes.Black, new XRect(10, yOffset, columnWidth, 20), XStringFormats.TopLeft);
                gfx.DrawString(item.PartNumber, font, XBrushes.Black, new XRect(10 + columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);
                gfx.DrawString(item.Price.ToString("C2"), font, XBrushes.Black, new XRect(10 + 2 * columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);
                gfx.DrawString(item.Total.ToString("C2"), font, XBrushes.Black, new XRect(10 + 3 * columnWidth, yOffset, columnWidth, 20), XStringFormats.TopLeft);

                yOffset += 20; // Adjusted spacing between rows
            }

            decimal partsTotal = selectedItems.Sum(item => item.Total);

            yOffset += 20;

            gfx.DrawString($"Parts Total:", font, XBrushes.Black, new XRect(10, yOffset, pageWidth - 10 - rightPadding, 20), XStringFormats.TopLeft);
            gfx.DrawString($"{partsTotal:C2}", font, XBrushes.Black, new XRect(10, yOffset, pageWidth - 10 - rightPadding, 20), rightAlignment);
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


            private void generatePDFButton_Click(object sender, EventArgs e)
        {
            GenerateInvoice();
            
        }
    }
}
