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
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
        }

        private void fHome_Load(object sender, EventArgs e)
        {
            //lblUser.Text = $"Xin chào: {CurrentUser.HoTen} ({CurrentUser.Role})";
            lblUser.Text = $"Xin chào, Trần Trường Thịnh | Quyền: quản trị viên. ";
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {

        }
    }
}
