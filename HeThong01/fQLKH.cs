using HeThong01.data;
using HeThong01.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong01
{
    public partial class fQLKH : Form
    {
        CouseContext db = new CouseContext();

        public fQLKH()
        {
            InitializeComponent();
        }

        private void clearInput()
        {
            txtMaHP.Clear();
            txtTenHP.Clear();
            txtSoTinChi.Clear();
            cbbGVphuTrach.SelectedIndex = -1;
            txtMaHP.Enabled = true;
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            clearInput();
            LoadData();
        }

        void LoadData()
        {
            var data = db.KhoaHocs
                .Include(kh => kh.GiangVien)
                .Select(kh => new
                {
                    MaHP = kh.ma_KH,
                    TenHP = kh.ten_KH,
                    SoTinChi = kh.So_TC,
                    GiangVien = kh.GiangVien.hoTen_GV,
                    MaGV = kh.GiangVien.ma_GV
                })
                .ToList();

            dgvDanhSachKH.DataSource = data;

            dgvDanhSachKH.Columns["MaHP"].HeaderText = "Mã học phần";
            dgvDanhSachKH.Columns["TenHP"].HeaderText = "Tên học phần";
            dgvDanhSachKH.Columns["SoTinChi"].HeaderText = "Số tín chỉ";
            dgvDanhSachKH.Columns["GiangVien"].HeaderText = "Giảng viên phụ trách";

            // Neu khong muon hien ma GV trong grid
            dgvDanhSachKH.Columns["MaGV"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHP.Text == "" ||
                txtTenHP.Text == "" ||
                txtSoTinChi.Text == "" ||
                cbbGVphuTrach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var check = db.KhoaHocs.Find(txtMaHP.Text);
            if (check != null)
            {
                MessageBox.Show("Mã khóa học đã tồn tại!");
                return;
            }
            if (!int.TryParse(txtSoTinChi.Text, out int stc) || stc <= 0)
            {
                MessageBox.Show("Số tín chỉ không hợp lệ!");
                return;
            }

            var hp = new KhoaHoc
            {
                ma_KH = txtMaHP.Text,
                ten_KH = txtTenHP.Text,
                So_TC = int.Parse(txtSoTinChi.Text),
                GiangVien_ma_GV = cbbGVphuTrach.SelectedValue.ToString()
            };
            db.KhoaHocs.Add(hp);
            db.SaveChanges();
            MessageBox.Show("Thêm học phần thành công!");
            LoadData();
            clearInput();
        }

        
        private void fQLKH_Load(object sender, EventArgs e)
        {
            LoadGiangVien();
            LoadData();
        }

        void LoadGiangVien()
        {
            cbbGVphuTrach.DataSource = db.GiangViens
                .Select(gv => new
                {
                    gv.ma_GV,
                    gv.hoTen_GV
                })
                .ToList();

            cbbGVphuTrach.DisplayMember = "hoTen_GV";
            cbbGVphuTrach.ValueMember = "ma_GV";
            cbbGVphuTrach.SelectedIndex = -1;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            f_InKhoaHoc fInKH = new f_InKhoaHoc();
            fInKH.ShowDialog();
        }

        private void dgvDanhSachKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaHP.Text = dgvDanhSachKH.Rows[e.RowIndex].Cells["MaHP"].Value.ToString();
                txtTenHP.Text = dgvDanhSachKH.Rows[e.RowIndex].Cells["TenHP"].Value.ToString();
                txtSoTinChi.Text = dgvDanhSachKH.Rows[e.RowIndex].Cells["SoTinChi"].Value.ToString();

                // Set GV theo ValueMember
                cbbGVphuTrach.SelectedValue =
                    dgvDanhSachKH.Rows[e.RowIndex].Cells["MaGV"].Value.ToString();

                txtMaHP.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var kh = db.KhoaHocs.Find(txtMaHP.Text);
            if (kh == null)
            {
                MessageBox.Show("Không tìm thấy học phần!");
                return;
            }
            if (!int.TryParse(txtSoTinChi.Text, out int stc) || stc <= 0)
            {
                MessageBox.Show("Số tín chỉ không hơp lệ!");
                return;
            }

            kh.ten_KH = txtTenHP.Text;
            kh.So_TC = int.Parse(txtSoTinChi.Text);
            kh.GiangVien_ma_GV = cbbGVphuTrach.SelectedValue.ToString();

            db.SaveChanges();
            MessageBox.Show("Cập nhật học phần thành công!");
            LoadData();
            clearInput();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var kh = db.KhoaHocs
        .Include(x => x.BaiKiemTras)
        .FirstOrDefault(x => x.ma_KH == txtMaHP.Text);

            if (kh == null)
            {
                MessageBox.Show("Không tìm thấy học phần!");
                return;
            }

            if (kh.BaiKiemTras.Any())
            {
                MessageBox.Show("Không thể xóa học phần có bài kiểm tra!");
                return;
            }

            db.KhoaHocs.Remove(kh);
            db.SaveChanges();
            LoadData();
            clearInput();
        }
    }
}
