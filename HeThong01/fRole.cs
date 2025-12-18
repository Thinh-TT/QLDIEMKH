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
    public partial class fRole : Form
    {
        CouseContext db = new CouseContext();

        public fRole()
        {
            InitializeComponent();
        }


        private void LoadData()
        {
            using (var db = new CouseContext())
            {
                var data = db.Roles
                             .Select(r => new
                             {
                                 r.Id,
                                 r.Name
                             })
                             .ToList();

                dgvRole.AutoGenerateColumns = true;
                dgvRole.DataSource = data;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Role!");
                return;
            }

            var check = db.GiangViens.Find(txtRoleName.Text);
            if (check != null)
            {
                MessageBox.Show("Role đã tồn tại!");
                return;
            }

            var role = new Role
            {
                Name = txtRoleName.Text
            };

            db.Roles.Add(role);
            db.SaveChanges();
            LoadData();
            ClearInput();
        }

        private void ClearInput()
        {
            txtRoleName.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtRoleName.Text;
            var role = db.Roles.FirstOrDefault(x => x.Name == name);

            if (role == null)
            {
                MessageBox.Show("Không tìm thấy giảng viên!");
                return;
            }

            role.Name = txtRoleName.Text;

            db.SaveChanges();
            LoadData();
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtRoleName.Text;
            var role = db.Roles.FirstOrDefault(x => x.Name == name);

            if (role == null)
            {
                MessageBox.Show("Không tìm thấy role!");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa role: {role.Name} ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                db.Roles.Remove(role);
                db.SaveChanges();
                LoadData();
                ClearInput();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFormUser_Click(object sender, EventArgs e)
        {
            fUser f = new fUser();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
