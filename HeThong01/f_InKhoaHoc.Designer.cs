namespace HeThong01
{
    partial class f_InKhoaHoc
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
            this.rpvInKhoaHoc = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvInKhoaHoc
            // 
            this.rpvInKhoaHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvInKhoaHoc.Location = new System.Drawing.Point(0, 0);
            this.rpvInKhoaHoc.Name = "rpvInKhoaHoc";
            this.rpvInKhoaHoc.ServerReport.BearerToken = null;
            this.rpvInKhoaHoc.Size = new System.Drawing.Size(800, 450);
            this.rpvInKhoaHoc.TabIndex = 0;
            // 
            // f_InKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvInKhoaHoc);
            this.Name = "f_InKhoaHoc";
            this.Text = "f_InKhoaHoc";
            this.Load += new System.EventHandler(this.f_InKhoaHoc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInKhoaHoc;
    }
}