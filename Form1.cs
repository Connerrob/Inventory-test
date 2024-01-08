using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsAppColby
{
    public partial class Form1 : Form
    {
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private List<InventoryItem> selectedPartsToAdd = new List<InventoryItem>();
        private string inventoryFilePath = "inventory.txt";
        private InventoryManager inventoryManager;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            
            dataGridViewInventory.CellContentClick += dataGridViewInventory_CellContentClick;

            this.WindowState = FormWindowState.Maximized;

            inventoryManager = new InventoryManager(inventoryItems);
        }
        private void InitializeSelectedPartsDisplay()
        {
            // Call your method to initialize the display for selected parts
            UpdateSelectedPartsDisplay();
        }

        private void InitializeDataGridView()
        {
            dataGridViewInventory.AutoGenerateColumns = false;

            // Create columns programmatically
            DataGridViewTextBoxColumn partNumberColumn = new DataGridViewTextBoxColumn();
            partNumberColumn.HeaderText = "Part Number";
            partNumberColumn.DataPropertyName = "PartNumber";
            dataGridViewInventory.Columns.Add(partNumberColumn);

            DataGridViewTextBoxColumn listPriceColumn = new DataGridViewTextBoxColumn();
            listPriceColumn.HeaderText = "List Price";
            listPriceColumn.DataPropertyName = "ListPrice"; 
            listPriceColumn.DefaultCellStyle.Format = "C2";
            dataGridViewInventory.Columns.Add(listPriceColumn);

            DataGridViewTextBoxColumn costColumn = new DataGridViewTextBoxColumn();
            costColumn.HeaderText = "Cost";
            costColumn.DataPropertyName = "Cost"; 
            costColumn.DefaultCellStyle.Format = "C2";
            dataGridViewInventory.Columns.Add(costColumn);

            DataGridViewTextBoxColumn myPriceColumn = new DataGridViewTextBoxColumn();
            myPriceColumn.HeaderText = "Price";
            myPriceColumn.DataPropertyName = "Price";
            myPriceColumn.DefaultCellStyle.Format = "C2";
            dataGridViewInventory.Columns.Add(myPriceColumn);

            DataGridViewTextBoxColumn onHandColumn = new DataGridViewTextBoxColumn();
            onHandColumn.HeaderText = "On Hand";
            onHandColumn.DataPropertyName = "OnHand";
            dataGridViewInventory.Columns.Add(onHandColumn);

            DataGridViewLinkColumn orderColumn = new DataGridViewLinkColumn();
            orderColumn.HeaderText = "Order";
            orderColumn.DataPropertyName = "Order";
            dataGridViewInventory.Columns.Add(orderColumn);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void LoadInventory()
        {
            if (File.Exists(inventoryFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(inventoryFilePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 6
                            && decimal.TryParse(parts[1], out decimal listPrice)
                            && decimal.TryParse(parts[2], out decimal cost)
                            && decimal.TryParse(parts[3], out decimal myPrice)
                            && int.TryParse(parts[4], out int onHandQuantity)
                            && Uri.TryCreate(parts[5], UriKind.Absolute, out Uri orderLink))
                        {
                            inventoryItems.Add(new InventoryItem
                            {
                                PartNumber = parts[0],
                                ListPrice = listPrice,
                                Cost = cost,
                                Price = myPrice,
                                OnHand = onHandQuantity,
                                Order = orderLink,
                            });
                        }
                    }

                    listBoxLow.Items.Clear();

                    // Identify and add items with "On Hand" less than 5 to the ListBox or ListView
                    foreach (var item in inventoryItems)
                    {
                        if (item.OnHand < 4)
                        {
                            listBoxLow.Items.Add(item.PartNumber);
                        }
                    }

                    // Update the display based on the loaded inventory
                    UpdateInventoryDisplay();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading inventory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateLowInventoryList()
        {
            // Clear existing items in the ListBox or ListView
            listBoxLow.Items.Clear();

            // Identify and add items with "On Hand" less than 5 to the ListBox or ListView
            foreach (var item in inventoryItems)
            {
                if (item.OnHand < 4)
                {
                    listBoxLow.Items.Add(item.PartNumber);
                }
            }
        }
            private void saveButton_Click(object sender, EventArgs e)
        {
            SaveInventory();
            UpdateInventoryDisplay();
        }

        public void SaveInventory()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save changes?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(inventoryFilePath))
                    {
                        foreach (var item in inventoryItems)
                        {
                            writer.WriteLine($"{item.PartNumber},{item.ListPrice},{item.Cost},{item.Price},{item.OnHand},{item.Order}");
                        }
                    }

                    MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving inventory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            UpdateLowInventoryList();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Filter the DataGridView based on the entered part number
            string searchText = searchTextBox.Text.Trim();
            List<InventoryItem> filteredList = inventoryItems
                .Where(item => item.PartNumber.Contains(searchText))
                .ToList();

            UpdateInventoryDisplay(filteredList);
        }

        private void UpdateInventoryDisplay(List<InventoryItem> displayList = null)
        {
            dataGridViewInventory.DataSource = null;
            dataGridViewInventory.DataSource = displayList ?? inventoryItems;
        }

        private void dataGridViewInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridViewInventory.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value != null)
                {
                    if (cell.Value is Uri orderLink)
                    {
                        System.Diagnostics.Process.Start(orderLink.ToString());
                    }
                }
            }
        }
        private void OpenInvoiceForm()
        {
            // Ensure that there are selected rows
            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                List<InventoryItem> selectedItems = new List<InventoryItem>();

                // Iterate through selected rows and add corresponding InventoryItems to the list
                foreach (DataGridViewRow selectedRow in dataGridViewInventory.SelectedRows)
                {
                    // Assuming DataBoundItem is of type InventoryItem
                    selectedItems.Add((InventoryItem)selectedRow.DataBoundItem);
                }

                // Pass the selected items and the inventory manager to the InvoiceForm
                InvoiceForm invoiceForm = new InvoiceForm(selectedItems, inventoryManager);
                invoiceForm.Show();
            }
            else
            {
                MessageBox.Show("Please select items from the inventory to generate an invoice.", "No Items Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void generateInvoiceButton_Click(object sender, EventArgs e)
        {
            // Ensure that there are selected parts
            if (selectedPartsToAdd.Count > 0)
            {
                // Create a copy of selectedPartsToAdd to pass to the InvoiceForm
                List<InventoryItem> selectedPartsCopy = new List<InventoryItem>(selectedPartsToAdd);

                UpdateInventoryDisplay();

                // Open the InvoiceForm with the selected parts copy
                InvoiceForm invoiceForm = new InvoiceForm(selectedPartsCopy, inventoryManager);
                invoiceForm.Show();

                SaveInventory();
            }
            else
            {
                MessageBox.Show("Please select parts to add to the invoice.", "No Parts Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void addToInvoiceButton_Click(object sender, EventArgs e)
        {
            // Ensure that there are selected rows
            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                // Iterate through selected rows and add corresponding InventoryItems to the selected parts list
                foreach (DataGridViewRow selectedRow in dataGridViewInventory.SelectedRows)
                {
                    // Assuming DataBoundItem is of type InventoryItem
                    InventoryItem selectedPart = (InventoryItem)selectedRow.DataBoundItem;

                    string input = Microsoft.VisualBasic.Interaction.InputBox($"How many {selectedPart.PartNumber} did you use?", "Quantity Used", "1");

                    // Prompt the user for the quantity used
                    int quantityUsed;
                    if (int.TryParse(input, out quantityUsed))
                    {
                        selectedPart.QuantityUsed = quantityUsed;
                        selectedPart.OriginalOnHand = selectedPart.OnHand; // Store the original quantity

                        // Add the item to the selected parts list
                        selectedPartsToAdd.Add(selectedPart);

                        // Update the on-hand quantity in the inventory
                        selectedPart.OnHand -= quantityUsed;
                    }
                    else
                    {
                        MessageBox.Show("Invalid quantity entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Update the display for selected parts
                UpdateSelectedPartsDisplay();

            }
            else
            {
                MessageBox.Show("Please select items from the inventory to add to the invoice.", "No Items Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private bool selectedPartsColumnsInitialized = false;
        private void UpdateSelectedPartsDisplay()
        {
            if (!selectedPartsColumnsInitialized)
            {
                // Create columns programmatically
                DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
                quantityColumn.HeaderText = "Quantity";
                quantityColumn.DataPropertyName = "QuantityUsed"; // Use the QuantityUsed property
                dataGridViewSelectParts.Columns.Add(quantityColumn);

                // Create columns programmatically
                DataGridViewTextBoxColumn partNumberColumn = new DataGridViewTextBoxColumn();
                partNumberColumn.HeaderText = "Part Number";
                partNumberColumn.DataPropertyName = "PartNumber";
                dataGridViewSelectParts.Columns.Add(partNumberColumn);

                DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
                priceColumn.HeaderText = "Price";
                priceColumn.DataPropertyName = "Price";
                priceColumn.DefaultCellStyle.Format = "C2"; // Currency format
                dataGridViewSelectParts.Columns.Add(priceColumn);

                selectedPartsColumnsInitialized = true;  // Set the flag to true after initializing columns
            }

            // Create a new list with only the necessary information for display
            var displayList = selectedPartsToAdd.Select(item => new
            {
                PartNumber = item.PartNumber,
                Price = item.Price,
                QuantityUsed = item.QuantityUsed
            }).ToList();

            // Update the DataGridView for selected parts
            dataGridViewSelectParts.DataSource = null;
            dataGridViewSelectParts.DataSource = displayList;
        }
        private void clearInvoiceList_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to clear the invoice list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // Restore original on-hand quantities
                foreach (var selectedPart in selectedPartsToAdd)
                {
                    selectedPart.OnHand = selectedPart.OriginalOnHand;
                }

                // Clear the selected parts list
                selectedPartsToAdd.Clear();

                // Clear the columns in the DataGridView
                dataGridViewSelectParts.Columns.Clear();

                // Update the DataGridView by clearing its data source and reassigning it
                dataGridViewSelectParts.DataSource = null;
                dataGridViewSelectParts.DataSource = selectedPartsToAdd;

                // Reinitialize the columns
                InitializeSelectedPartsDisplay();
            }
        }


    }
}