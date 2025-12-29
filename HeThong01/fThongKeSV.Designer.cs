namespace HeThong01
{
    partial class fThongKeSV
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvThongKeSV = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.cbbSinhVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblthongtin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeSV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.lblthongtin);
            this.panel1.Controls.Add(this.dgvThongKeSV);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Controls.Add(this.btnReLoad);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.cbbSinhVien);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 605);
            this.panel1.TabIndex = 3;
            // 
            // dgvThongKeSV
            // 
            this.dgvThongKeSV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKeSV.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvThongKeSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeSV.Location = new System.Drawing.Point(18, 119);
            this.dgvThongKeSV.Name = "dgvThongKeSV";
            this.dgvThongKeSV.RowHeadersWidth = 51;
            this.dgvThongKeSV.RowTemplate.Height = 24;
            this.dgvThongKeSV.Size = new System.Drawing.Size(985, 474);
            this.dgvThongKeSV.TabIndex = 4;
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnIn.Location = new System.Drawing.Point(558, 43);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(110, 39);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            // 
            // btnReLoad
            // 
            this.btnReLoad.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnReLoad.Location = new System.Drawing.Point(442, 43);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(110, 39);
            this.btnReLoad.TabIndex = 3;
            this.btnReLoad.Text = "Tải lại ";
            this.btnReLoad.UseVisualStyleBackColor = true;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.Location = new System.Drawing.Point(304, 43);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(132, 39);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cbbSinhVien
            // 
            this.cbbSinhVien.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.cbbSinhVien.FormattingEnabled = true;
            this.cbbSinhVien.Location = new System.Drawing.Point(18, 43);
            this.cbbSinhVien.Name = "cbbSinhVien";
            this.cbbSinhVien.Size = new System.Drawing.Size(280, 39);
            this.cbbSinhVien.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thống kê sinh viên";
            // 
            // lblthongtin
            // 
            this.lblthongtin.AutoSize = true;
            this.lblthongtin.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblthongtin.Location = new System.Drawing.Point(12, 85);
            this.lblthongtin.Name = "lblthongtin";
            this.lblthongtin.Size = new System.Drawing.Size(77, 31);
            this.lblthongtin.TabIndex = 5;
            this.lblthongtin.Text = "label2";
            // 
            // fThongKeSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 605);
            this.Controls.Add(this.panel1);
            this.Name = "fThongKeSV";
            this.Text = "fThongKeSV";
            this.Load += new System.EventHandler(this.fThongKeSV_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeSV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvThongKeSV;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnReLoad;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ComboBox cbbSinhVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblthongtin;
    }
}