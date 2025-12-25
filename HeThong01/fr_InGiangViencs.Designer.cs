namespace HeThong01
{
    partial class fr_InGiangViencs
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
            this.rpvInGiangVien = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvInGiangVien
            // 
            this.rpvInGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvInGiangVien.Location = new System.Drawing.Point(0, 0);
            this.rpvInGiangVien.Name = "rpvInGiangVien";
            this.rpvInGiangVien.ServerReport.BearerToken = null;
            this.rpvInGiangVien.Size = new System.Drawing.Size(800, 450);
            this.rpvInGiangVien.TabIndex = 0;
            // 
            // fr_InGiangViencs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvInGiangVien);
            this.Name = "fr_InGiangViencs";
            this.Text = "fr_InGiangViencs";
            this.Load += new System.EventHandler(this.fr_InGiangViencs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInGiangVien;
    }
}