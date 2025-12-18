using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong01
{
    public partial class fControl : Form
    {
        public fControl()
        {
            InitializeComponent();
        }
        private void LoadForm(Form frm)
        {
            panelContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(frm);
            frm.Show();
        }

        private void fControl_Load(object sender, EventArgs e)
        {
            LoadForm(new fHome());
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fHome());
        }

        private void qLGiangVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fQLGV());
        }

        private void qLKhoahocToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadForm(new fQLKH());
        }

        private void qLSinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fQLSV());
        }

        private void qLBKTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fQLBaiKT());
        }

        private void nhapDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fNhapDiem());
        }

        private void xemDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fXemDiem());
        }

        private void thongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fThongKe());
        }

        private void taikhoantoolStripComboBox1_Click(object sender, EventArgs e)
        {
            LoadForm(new fAccount());
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fRole());
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new fUser());
        }
    }
}
