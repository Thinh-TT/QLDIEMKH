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
    public partial class fQLKH : Form
    {
        public fQLKH()
        {
            InitializeComponent();
        }

        private void clerInput()
        {
            txtMaHP.Clear();
            txtTenHP.Clear();
            txtSoTinChi.Clear();
            cbbGVphuTrach.SelectedIndex = 0;
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            clerInput();
        }
    }
}
