namespace HeThong01
{
    partial class f_InSinhVien
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
            this.rpvInSinhVien = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvInSinhVien
            // 
            this.rpvInSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvInSinhVien.Location = new System.Drawing.Point(0, 0);
            this.rpvInSinhVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rpvInSinhVien.Name = "rpvInSinhVien";
            this.rpvInSinhVien.ServerReport.BearerToken = null;
            this.rpvInSinhVien.Size = new System.Drawing.Size(1025, 536);
            this.rpvInSinhVien.TabIndex = 0;
            // 
            // f_InSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 536);
            this.Controls.Add(this.rpvInSinhVien);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "f_InSinhVien";
            this.Text = "f_InSinhVien";
            this.Load += new System.EventHandler(this.f_InSinhVien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInSinhVien;
    }
}