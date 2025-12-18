using HeThong01.data;
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
    public partial class fUser : Form
    {
        CouseContext db = new CouseContext();

        public fUser()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == ""||
                txtUserName.Text == "" ||
                txtPassWord.Text == "" ||
                txtPassWordValues.Text == "" ||
                lbxRole.SelectedItems.Count == 0
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                return;
            }

            var check = db.Users.FirstOrDefault(u => u.Username == txtUserName.Text);
            if (check != null)
            {
                MessageBox.Show("Username đã tồn tại!");
                return;
            }

            if (txtPassWord.Text != txtPassWordValues.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRoleIds = lbxRole.SelectedItems
                                .Cast<Role>()
                                .Select(r => r.Id)
                                .ToList();

            var roles = db.Roles
                          .Where(r => selectedRoleIds.Contains(r.Id))
                          .ToList();

            var user = new User
            {
                Username = txtUserName.Text,
                FullName = txtFullName.Text,
                PasswordHash = PasswordHelper.HashPassword(txtPassWord.Text),
                Roles = roles,
                IsActive = true

            };
            

            db.Users.Add(user);
            db.SaveChanges();
            LoadData();
            ClearInput();
        }

        private void ClearInput()
        {
            txtFullName.Clear();
            txtUserName.Clear();
            txtPassWord.Clear();
            txtPassWordValues.Clear();
            lbxRole.ClearSelected();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new CouseContext())
            {
                var data = db.Users
                     .Select(u => new
                     {
                         u.Id,
                         u.Username,
                         Roles = u.Roles.Select(r => r.Name)
                     })
                     .ToList()
                     .Select(u => new
                     {
                         u.Id,
                         u.Username,
                         Role = string.Join(", ", u.Roles)
                     })
                     .ToList();

                dgvUser.AutoGenerateColumns = true;
               dgvUser.DataSource = data;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            var user = db.Users.FirstOrDefault(x => x.Username == userName);

            if (user == null)
            {
                MessageBox.Show("Không tìm thấy username!");
                return;
            }

            user.Username = txtUserName.Text;

            db.SaveChanges();
            LoadData();
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            var user = db.Users.FirstOrDefault(x => x.Username == userName);

            if (user == null)
            {
                MessageBox.Show("Không tìm thấy username!");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa username: {user.Username} ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                LoadData();
                ClearInput();
            }
        }

        private void fUser_Load(object sender, EventArgs e)
        {
            lbxRole.DataSource = db.Roles.ToList();
            lbxRole.DisplayMember = "Name";
            lbxRole.ValueMember = "Id";
        }

        private void btnFormLogin_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
