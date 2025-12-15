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
    public partial class fQLGV : Form
    {
        public fQLGV()
        {
            InitializeComponent();
        }

        private void ClearInput()
        {
            txtMaGV.Clear();
            txtHoTenGV.Clear();
            txtEmailGV.Clear();
            txtDiaChiGV.Clear();
            txtSDTGV.Clear();
            dtpNgaySinhGV.Value = DateTime.Now;
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

    }
}
