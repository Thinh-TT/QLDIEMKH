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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "UserName")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.Text = "UserName";
                txtUserName.ForeColor = Color.Gray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "UserName";
            txtUserName.ForeColor = Color.Gray;
            txtPassWord .Text = "PassWord";
            txtPassWord.ForeColor = Color.Gray;
            cbbChoiceRole.SelectedIndex = 0;

        }

        private void txtPassWord_Enter(object sender, EventArgs e)
        {
            if (txtPassWord.Text == "PassWord")
            {
                txtPassWord.Text = "";
                txtPassWord.ForeColor = Color.Black;
            }
        }

        private void txtPassWord_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                txtPassWord.Text = "PassWord";
                txtPassWord.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            fControl f = new fControl();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắn chắn thoát chương trình?", "Xác nhận",
                MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
