using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
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
            string ownerContact = "Contact: Your Contact Information";  // Replace with actual contact information

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

            // Set up font and position for invoice details
            int yOffset = 140; // Adjusted starting position for details
            XFont font = new XFont("Arial", 12, XFontStyle.Regular);

            // Iterate through selectedItems and add information to the document
            foreach (var item in selectedItems)
            {
                gfx.DrawString($"Price: {item.Price:C2}", font, XBrushes.Black, new XRect(10, yOffset, pageWidth, 20), XStringFormats.TopLeft);
                yOffset += 20;
            }
        }

        private void generatePDFButton_Click(object sender, EventArgs e)
        {
            GenerateInvoice();
            
        }
    }
}
