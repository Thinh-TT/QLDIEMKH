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
    public partial class fQLSV : Form
    {
        public fQLSV()
        {
            InitializeComponent();
        }


        private void btnTai_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void clearInput()
        {
            txtMaSV.Clear();
            txtHoTenSV.Clear();
            txtEmailSV.Clear();
            txtDiaChiSV.Clear();
            txtSDTSV.Clear();
            dtpNgaySinhSV.Value = DateTime.Now;
        }

        private void fQLSV_Load(object sender, EventArgs e)
        {
            rdbNam.Checked = true;
        }
    }
}
