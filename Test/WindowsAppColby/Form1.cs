﻿using System;
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
        private string inventoryFilePath = "inventory.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            dataGridViewInventory.CellContentClick += dataGridViewInventory_CellContentClick;
        }

        private void InitializeDataGridView()
        {
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
            myPriceColumn.HeaderText = "My Price";
            myPriceColumn.DataPropertyName = "MyPrice";
            myPriceColumn.DefaultCellStyle.Format = "C2";
            dataGridViewInventory.Columns.Add(myPriceColumn);

            DataGridViewTextBoxColumn onHandColumn = new DataGridViewTextBoxColumn();
            onHandColumn.HeaderText = "On Hand";
            onHandColumn.DataPropertyName = "OnHand";
            dataGridViewInventory.Columns.Add(onHandColumn);

            DataGridViewLinkColumn orderColumn = new DataGridViewLinkColumn();
            orderColumn.HeaderText = "Order";
            orderColumn.DataPropertyName = "OrderLink";
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
                                MyPrice = myPrice,
                                OnHand = onHandQuantity,
                                OrderLink = orderLink,
                            });
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveInventory();
        }

        private void SaveInventory()
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
                            writer.WriteLine($"{item.PartNumber},{item.ListPrice},{item.Cost},{item.MyPrice},{item.OnHand},{item.OrderLink}");
                        }
                    }

                    MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving inventory: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    else
                    {
                        MessageBox.Show("Invalid link format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Null value in the cell", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}