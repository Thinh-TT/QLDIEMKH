using HeThong01.model;
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

        private User _currentUser;
        public fHome(User user)
        {
            InitializeComponent();
            _currentUser = user;
            string roleName = _currentUser.Roles
                        .Select(r => r.Name)
                        .FirstOrDefault() ?? "Không xác định";
            lblUser.Text = $"Xin chào {_currentUser.FullName} | Quyền: {roleName}";
        }

        private void fHome_Load(object sender, EventArgs e)
        {
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {

        }
    }
}
