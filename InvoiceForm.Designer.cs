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
            this.previewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generatePDFButton
            // 
            this.generatePDFButton.Location = new System.Drawing.Point(187, 406);
            this.generatePDFButton.Name = "generatePDFButton";
            this.generatePDFButton.Size = new System.Drawing.Size(169, 32);
            this.generatePDFButton.TabIndex = 0;
            this.generatePDFButton.Text = "Generate PDF";
            this.generatePDFButton.UseVisualStyleBackColor = true;
            this.generatePDFButton.Click += new System.EventHandler(this.generatePDFButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(12, 406);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(169, 32);
            this.previewButton.TabIndex = 1;
            this.previewButton.Text = "Preview PDF";
            this.previewButton.UseVisualStyleBackColor = true;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.generatePDFButton);
            this.Name = "InvoiceForm";
            this.Text = "InvoiceForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generatePDFButton;
        private System.Windows.Forms.Button previewButton;
    }
}