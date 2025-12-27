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
    public partial class fQLGV : Form
    {
        CouseContext db = new CouseContext();

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
            txtMaGV.Enabled = true;
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInput();
        }

        void LoadData()
        {
            var data = db.GiangViens
        .Select(gv => new
        {
            MaGV = gv.ma_GV,
            HoTen = gv.hoTen_GV,
            Email = gv.email_GV,
            DiaChi = gv.diaChi_GV,
            SDT = gv.SDT_GV,
            NgaySinh = gv.ngaySinh,
            SoKhoaHoc = gv.khoaHocs.Count()
        })
        .ToList();

            dgvDanhSachGV.DataSource = data;

            // Dat tieu de cot cho dep
            dgvDanhSachGV.Columns["MaGV"].HeaderText = "Mã giảng viên";
            dgvDanhSachGV.Columns["HoTen"].HeaderText = "Họ tên";
            dgvDanhSachGV.Columns["Email"].HeaderText = "Email";
            dgvDanhSachGV.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDanhSachGV.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvDanhSachGV.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDanhSachGV.Columns["SoKhoaHoc"].HeaderText = "Số HP đang dạy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text == "" ||
                txtHoTenGV.Text == "" ||
                txtEmailGV.Text == "" ||
                txtDiaChiGV.Text == "" ||
                txtSDTGV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var check = db.GiangViens.Find(txtMaGV.Text);
            if (check != null)
            {
                MessageBox.Show("Mã giảng viên đã tồn tại!");
                return;
            }

            if (dtpNgaySinhGV.Value > DateTime.Now)
            {
                MessageBox.Show("Ngay sinh khong hop le!");
                return;
            }

            var gv = new GiangVien
            {
                ma_GV = txtMaGV.Text,
                hoTen_GV = txtHoTenGV.Text,
                email_GV = txtEmailGV.Text,
                diaChi_GV = txtDiaChiGV.Text,
                SDT_GV = txtSDTGV.Text,
                ngaySinh = dtpNgaySinhGV.Value
            };

            db.GiangViens.Add(gv);
            db.SaveChanges();
            LoadData();
            ClearInput();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaGV.Text;
            var gv = db.GiangViens.FirstOrDefault(x => x.ma_GV == id);

            if (gv == null)
            {
                MessageBox.Show("Không tìm thấy giảng viên!");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa giảng viên: {gv.hoTen_GV} ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                db.GiangViens.Remove(gv);
                db.SaveChanges();
                LoadData();
                ClearInput();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaGV.Text;
            var gv = db.GiangViens.FirstOrDefault(x => x.ma_GV == id);

            if (gv == null)
            {
                MessageBox.Show("Không tìm thấy giảng viên!");
                return;
            }

            gv.hoTen_GV = txtHoTenGV.Text;
            gv.email_GV = txtEmailGV.Text;
            gv.diaChi_GV = txtDiaChiGV.Text;
            gv.SDT_GV = txtSDTGV.Text;
            gv.ngaySinh = dtpNgaySinhGV.Value;

            db.SaveChanges();
            MessageBox.Show("Sửa thành công!");
            LoadData();
            ClearInput();
        }

        private void dgvDanhSachGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaGV.Text = dgvDanhSachGV.Rows[e.RowIndex].Cells["MaGV"].Value.ToString();
                txtHoTenGV.Text = dgvDanhSachGV.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                txtEmailGV.Text = dgvDanhSachGV.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtDiaChiGV.Text = dgvDanhSachGV.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txtSDTGV.Text = dgvDanhSachGV.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                dtpNgaySinhGV.Value =
                    Convert.ToDateTime(dgvDanhSachGV.Rows[e.RowIndex].Cells["NgaySinh"].Value);
                txtMaGV.Enabled = false;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            fr_InGiangViencs f = new fr_InGiangViencs();
            f.ShowDialog();
        }

        private void fQLGV_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
