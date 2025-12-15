namespace HeThong01
{
    partial class fControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fControl));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLGiangVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLKhoahocToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.qLSinhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giangViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLBKTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhapDiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taikhoantoolStripComboBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.giangViênToolStripMenuItem,
            this.taikhoantoolStripComboBox1,
            this.thoatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(150, 653);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Image = global::HeThong01.Properties.Resources.home;
            this.homeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(137, 27);
            this.homeToolStripMenuItem.Text = "&Trang chủ";
            this.homeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qLGiangVienToolStripMenuItem,
            this.qLKhoahocToolStripMenuItem1,
            this.qLSinhVienToolStripMenuItem});
            this.adminToolStripMenuItem.Image = global::HeThong01.Properties.Resources.admin;
            this.adminToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(137, 27);
            this.adminToolStripMenuItem.Text = "&Quản trị viên";
            this.adminToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // qLGiangVienToolStripMenuItem
            // 
            this.qLGiangVienToolStripMenuItem.Name = "qLGiangVienToolStripMenuItem";
            this.qLGiangVienToolStripMenuItem.Size = new System.Drawing.Size(202, 28);
            this.qLGiangVienToolStripMenuItem.Text = "QL &Giảng viên";
            this.qLGiangVienToolStripMenuItem.Click += new System.EventHandler(this.qLGiangVienToolStripMenuItem_Click);
            // 
            // qLKhoahocToolStripMenuItem1
            // 
            this.qLKhoahocToolStripMenuItem1.Name = "qLKhoahocToolStripMenuItem1";
            this.qLKhoahocToolStripMenuItem1.Size = new System.Drawing.Size(202, 28);
            this.qLKhoahocToolStripMenuItem1.Text = "QL &Khóa học";
            this.qLKhoahocToolStripMenuItem1.Click += new System.EventHandler(this.qLKhoahocToolStripMenuItem1_Click);
            // 
            // qLSinhVienToolStripMenuItem
            // 
            this.qLSinhVienToolStripMenuItem.Name = "qLSinhVienToolStripMenuItem";
            this.qLSinhVienToolStripMenuItem.Size = new System.Drawing.Size(202, 28);
            this.qLSinhVienToolStripMenuItem.Text = "QL &Sinh viên";
            this.qLSinhVienToolStripMenuItem.Click += new System.EventHandler(this.qLSinhVienToolStripMenuItem_Click);
            // 
            // giangViênToolStripMenuItem
            // 
            this.giangViênToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qLBKTToolStripMenuItem,
            this.nhapDiemToolStripMenuItem,
            this.xemDiemToolStripMenuItem,
            this.thongKeToolStripMenuItem});
            this.giangViênToolStripMenuItem.Image = global::HeThong01.Properties.Resources.lecturer;
            this.giangViênToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.giangViênToolStripMenuItem.Name = "giangViênToolStripMenuItem";
            this.giangViênToolStripMenuItem.Size = new System.Drawing.Size(137, 27);
            this.giangViênToolStripMenuItem.Text = "&Giảng viên";
            this.giangViênToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // qLBKTToolStripMenuItem
            // 
            this.qLBKTToolStripMenuItem.Name = "qLBKTToolStripMenuItem";
            this.qLBKTToolStripMenuItem.Size = new System.Drawing.Size(211, 28);
            this.qLBKTToolStripMenuItem.Text = "QL &Bài kiểm tra";
            this.qLBKTToolStripMenuItem.Click += new System.EventHandler(this.qLBKTToolStripMenuItem_Click);
            // 
            // nhapDiemToolStripMenuItem
            // 
            this.nhapDiemToolStripMenuItem.Name = "nhapDiemToolStripMenuItem";
            this.nhapDiemToolStripMenuItem.Size = new System.Drawing.Size(211, 28);
            this.nhapDiemToolStripMenuItem.Text = "&Nhập điểm";
            this.nhapDiemToolStripMenuItem.Click += new System.EventHandler(this.nhapDiemToolStripMenuItem_Click);
            // 
            // xemDiemToolStripMenuItem
            // 
            this.xemDiemToolStripMenuItem.Name = "xemDiemToolStripMenuItem";
            this.xemDiemToolStripMenuItem.Size = new System.Drawing.Size(211, 28);
            this.xemDiemToolStripMenuItem.Text = "&Xem điểm";
            this.xemDiemToolStripMenuItem.Click += new System.EventHandler(this.xemDiemToolStripMenuItem_Click);
            // 
            // thongKeToolStripMenuItem
            // 
            this.thongKeToolStripMenuItem.Name = "thongKeToolStripMenuItem";
            this.thongKeToolStripMenuItem.Size = new System.Drawing.Size(211, 28);
            this.thongKeToolStripMenuItem.Text = "&Thống kê";
            this.thongKeToolStripMenuItem.Click += new System.EventHandler(this.thongKeToolStripMenuItem_Click);
            // 
            // taikhoantoolStripComboBox1
            // 
            this.taikhoantoolStripComboBox1.Image = global::HeThong01.Properties.Resources.account;
            this.taikhoantoolStripComboBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taikhoantoolStripComboBox1.Name = "taikhoantoolStripComboBox1";
            this.taikhoantoolStripComboBox1.Size = new System.Drawing.Size(137, 27);
            this.taikhoantoolStripComboBox1.Text = "Tài &khoản";
            this.taikhoantoolStripComboBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.taikhoantoolStripComboBox1.Click += new System.EventHandler(this.taikhoantoolStripComboBox1_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.thoatToolStripMenuItem.Image = global::HeThong01.Properties.Resources._out;
            this.thoatToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(137, 27);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelContainer.Location = new System.Drawing.Point(148, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1033, 652);
            this.panelContainer.TabIndex = 3;
            // 
            // fControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý điểm khóa học ";
            this.Load += new System.EventHandler(this.fControl_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giangViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLBKTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLGiangVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLKhoahocToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem qLSinhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taikhoantoolStripComboBox1;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ToolStripMenuItem nhapDiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
    }
}