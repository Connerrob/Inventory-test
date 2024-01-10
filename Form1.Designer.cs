namespace WindowsAppColby
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.generateInvoiceButton = new System.Windows.Forms.Button();
            this.addToInvoiceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listBoxLow = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clearInvoiceList = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewSelectParts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectParts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInventory
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            this.dataGridViewInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewInventory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewInventory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewInventory.GridColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewInventory.Location = new System.Drawing.Point(277, 13);
            this.dataGridViewInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewInventory.RowHeadersWidth = 100;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewInventory.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewInventory.Size = new System.Drawing.Size(1326, 723);
            this.dataGridViewInventory.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.addToInvoiceButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Location = new System.Drawing.Point(4, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 722);
            this.panel1.TabIndex = 2;
            // 
            // generateInvoiceButton
            // 
            this.generateInvoiceButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.generateInvoiceButton.ForeColor = System.Drawing.SystemColors.Control;
            this.generateInvoiceButton.Location = new System.Drawing.Point(41, 175);
            this.generateInvoiceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.generateInvoiceButton.Name = "generateInvoiceButton";
            this.generateInvoiceButton.Size = new System.Drawing.Size(230, 52);
            this.generateInvoiceButton.TabIndex = 1;
            this.generateInvoiceButton.Text = "Generate Invoice";
            this.generateInvoiceButton.UseVisualStyleBackColor = false;
            this.generateInvoiceButton.Click += new System.EventHandler(this.generateInvoiceButton_Click);
            // 
            // addToInvoiceButton
            // 
            this.addToInvoiceButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.addToInvoiceButton.ForeColor = System.Drawing.SystemColors.Control;
            this.addToInvoiceButton.Location = new System.Drawing.Point(3, 283);
            this.addToInvoiceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addToInvoiceButton.Name = "addToInvoiceButton";
            this.addToInvoiceButton.Size = new System.Drawing.Size(260, 52);
            this.addToInvoiceButton.TabIndex = 2;
            this.addToInvoiceButton.Text = "Add Item to Invoice List";
            this.addToInvoiceButton.UseVisualStyleBackColor = false;
            this.addToInvoiceButton.Click += new System.EventHandler(this.addToInvoiceButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Part Number";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(9, 229);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(251, 35);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.saveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.saveButton.Location = new System.Drawing.Point(41, 4);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(230, 52);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel3.Controls.Add(this.saveButton);
            this.panel3.Controls.Add(this.listBoxLow);
            this.panel3.Controls.Add(this.label2);
            this.panel3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Location = new System.Drawing.Point(1609, 14);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(303, 722);
            this.panel3.TabIndex = 4;
            // 
            // listBoxLow
            // 
            this.listBoxLow.FormattingEnabled = true;
            this.listBoxLow.ItemHeight = 30;
            this.listBoxLow.Location = new System.Drawing.Point(13, 108);
            this.listBoxLow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxLow.Name = "listBoxLow";
            this.listBoxLow.Size = new System.Drawing.Size(282, 574);
            this.listBoxLow.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Parts Getting Low";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Controls.Add(this.clearInvoiceList);
            this.panel2.Location = new System.Drawing.Point(4, 743);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 244);
            this.panel2.TabIndex = 6;
            // 
            // clearInvoiceList
            // 
            this.clearInvoiceList.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.clearInvoiceList.ForeColor = System.Drawing.SystemColors.Control;
            this.clearInvoiceList.Location = new System.Drawing.Point(18, 188);
            this.clearInvoiceList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearInvoiceList.Name = "clearInvoiceList";
            this.clearInvoiceList.Size = new System.Drawing.Size(230, 52);
            this.clearInvoiceList.TabIndex = 2;
            this.clearInvoiceList.Text = "Clear Invoice List";
            this.clearInvoiceList.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel5.Controls.Add(this.generateInvoiceButton);
            this.panel5.Location = new System.Drawing.Point(1609, 743);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(303, 244);
            this.panel5.TabIndex = 7;
            // 
            // dataGridViewSelectParts
            // 
            this.dataGridViewSelectParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSelectParts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSelectParts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectParts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewSelectParts.GridColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewSelectParts.Location = new System.Drawing.Point(277, 743);
            this.dataGridViewSelectParts.Name = "dataGridViewSelectParts";
            this.dataGridViewSelectParts.RowHeadersWidth = 100;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewSelectParts.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSelectParts.Size = new System.Drawing.Size(1326, 244);
            this.dataGridViewSelectParts.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1916, 1038);
            this.Controls.Add(this.dataGridViewSelectParts);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewInventory);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Robeson Hydraulic";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectParts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxLow;
        private System.Windows.Forms.Button generateInvoiceButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridViewSelectParts;
        private System.Windows.Forms.Button addToInvoiceButton;
        private System.Windows.Forms.Button clearInvoiceList;
    }
}

