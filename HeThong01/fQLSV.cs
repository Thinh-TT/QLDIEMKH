using HeThong01.data;
using HeThong01.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong01
{
    public partial class fQLSV : Form
    {
        CouseContext db = new CouseContext();
        bool isAdding = false;
        public fQLSV()
        {
            InitializeComponent();
        }


        private void btnTai_Click(object sender, EventArgs e)
        {
            LoadSinhVien();
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
            txtMaSV.ReadOnly = false;
        }

        private void fQLSV_Load(object sender, EventArgs e)
        {
            LoadSinhVien();
            SetButtonState(true);
        }

        private void SetButtonState(bool normal)
        {

            btnThem.Enabled = normal;
            btnSua.Enabled = normal;
            btnXoa.Enabled = normal;

            btnLuu.Enabled = !normal;
            btnHuy.Enabled = !normal;
        }

        private void LoadSinhVien()
        {
            var data = db.SinhViens
                            .Select(sv => new
                            {
                                sv.ma_SV,
                                sv.hoTen_SV,
                                GioiTinh = sv.gioiTinh ? "Nam" : "Nữ",
                                sv.email_SV,
                                sv.diaChi_SV,
                                sv.SDT_SV,
                                sv.ngaySinh
                            })
                            .ToList();

            dgvDanhSachSV.DataSource = data;
        }

        private void dgvDanhSachSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtMaSV.Text = dgvDanhSachSV.Rows[e.RowIndex].Cells["ma_SV"].Value.ToString();
            txtHoTenSV.Text = dgvDanhSachSV.Rows[e.RowIndex].Cells["hoTen_SV"].Value.ToString();

            string gt = dgvDanhSachSV.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
            rdbNam.Checked = gt == "Nam";
            rdbNu.Checked = gt == "Nữ";

            txtEmailSV.Text = dgvDanhSachSV.Rows[e.RowIndex].Cells["email_SV"].Value?.ToString();
            txtDiaChiSV.Text = dgvDanhSachSV.Rows[e.RowIndex].Cells["diaChi_SV"].Value?.ToString();
            txtSDTSV.Text = dgvDanhSachSV.Rows[e.RowIndex].Cells["SDT_SV"].Value?.ToString();
            dtpNgaySinhSV.Value = Convert.ToDateTime(dgvDanhSachSV.Rows[e.RowIndex].Cells["ngaySinh"].Value);
            txtMaSV.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaSV.ReadOnly = false;
            isAdding = true;
            SetButtonState(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text)) return;

            txtMaSV.ReadOnly = true;
            isAdding = false;
            SetButtonState(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text)) return;

            var sv = db.SinhViens.Find(txtMaSV.Text);
            if (sv == null) return;

            if (MessageBox.Show("Xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.SinhViens.Remove(sv);
                db.SaveChanges();
                LoadSinhVien();
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtMaSV.Clear();
            txtHoTenSV.Clear();
            txtEmailSV.Clear();
            txtDiaChiSV.Clear();
            txtSDTSV.Clear();
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            dtpNgaySinhSV.Value = DateTime.Now;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (isAdding)
            {
                if (db.SinhViens.Any(s => s.ma_SV == txtMaSV.Text))
                {
                    MessageBox.Show("Trùng mã sinh viên!");
                    return;
                }

                SinhVien sv = new SinhVien
                {
                    ma_SV = txtMaSV.Text,
                    hoTen_SV = txtHoTenSV.Text,
                    gioiTinh = rdbNam.Checked,
                    email_SV = txtEmailSV.Text,
                    diaChi_SV = txtDiaChiSV.Text,
                    SDT_SV = txtSDTSV.Text,
                    ngaySinh = dtpNgaySinhSV.Value
                };

                db.SinhViens.Add(sv);
                MessageBox.Show("Thêm sinh viên thành công!");
                clearInput();
            }
            else
            {
                var sv = db.SinhViens.Find(txtMaSV.Text);
                if (sv == null) return;

                sv.hoTen_SV = txtHoTenSV.Text;
                sv.gioiTinh = rdbNam.Checked;
                sv.email_SV = txtEmailSV.Text;
                sv.diaChi_SV = txtDiaChiSV.Text;
                sv.SDT_SV = txtSDTSV.Text;
                sv.ngaySinh = dtpNgaySinhSV.Value;
            }

            db.SaveChanges();
            LoadSinhVien();
            SetButtonState(true);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTenSV.Text))
            {
                MessageBox.Show("Mã SV và Tên SV không được rỗng");
                return false;
            }

            if (!rdbNam.Checked && !rdbNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmailSV.Text))
            {
                if (!Regex.IsMatch(txtEmailSV.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ");
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtSDTSV.Text) && !txtSDTSV.Text.All(char.IsDigit))
            {
                MessageBox.Show("SĐT chỉ được chứa số");
                return false;
            }

            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetButtonState(true);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            f_InSinhVien fInSV = new f_InSinhVien();
            fInSV.ShowDialog();
        }
    }
}
