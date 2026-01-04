namespace HeThong01
{
    partial class f_InTheoSinhVien
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
            this.rpvInTKSinhVien = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvInTKSinhVien
            // 
            this.rpvInTKSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvInTKSinhVien.Location = new System.Drawing.Point(0, 0);
            this.rpvInTKSinhVien.Name = "rpvInTKSinhVien";
            this.rpvInTKSinhVien.ServerReport.BearerToken = null;
            this.rpvInTKSinhVien.Size = new System.Drawing.Size(800, 450);
            this.rpvInTKSinhVien.TabIndex = 0;
            // 
            // f_InTheoSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvInTKSinhVien);
            this.Name = "f_InTheoSinhVien";
            this.Text = "f_InTheoSinhVien";
            this.Load += new System.EventHandler(this.f_InTheoSinhVien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInTKSinhVien;
    }
}