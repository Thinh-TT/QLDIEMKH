namespace HeThong01
{
    partial class f_InDiem
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
            this.rpvInDiem = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvInDiem
            // 
            this.rpvInDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvInDiem.Location = new System.Drawing.Point(0, 0);
            this.rpvInDiem.Name = "rpvInDiem";
            this.rpvInDiem.ServerReport.BearerToken = null;
            this.rpvInDiem.Size = new System.Drawing.Size(800, 450);
            this.rpvInDiem.TabIndex = 0;
            // 
            // f_InDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvInDiem);
            this.Name = "f_InDiem";
            this.Text = "f_InDiem";
            this.Load += new System.EventHandler(this.f_InDiem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInDiem;
    }
}