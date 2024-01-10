namespace WindowsAppColby
{
    partial class InvoiceForm
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
            this.generatePDFButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generatePDFButton
            // 
            this.generatePDFButton.BackColor = System.Drawing.Color.DarkGray;
            this.generatePDFButton.Location = new System.Drawing.Point(54, 36);
            this.generatePDFButton.Name = "generatePDFButton";
            this.generatePDFButton.Size = new System.Drawing.Size(182, 103);
            this.generatePDFButton.TabIndex = 0;
            this.generatePDFButton.Text = "Generate PDF";
            this.generatePDFButton.UseVisualStyleBackColor = false;
            this.generatePDFButton.Click += new System.EventHandler(this.generatePDFButton_Click);
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(306, 180);
            this.Controls.Add(this.generatePDFButton);
            this.Name = "InvoiceForm";
            this.Text = "Invoice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generatePDFButton;
    }
}