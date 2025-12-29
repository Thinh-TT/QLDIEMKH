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
    public partial class fQLBaiKT : Form
    {
        CouseContext db = new CouseContext();
        public fQLBaiKT()
        {
            InitializeComponent();
        }

        private void fQLBaiKT_Load(object sender, EventArgs e)
        {
            LoadHocPhan();
            LoadData();
        }

        private void LoadData()
        {
            if (cbbChonHP.SelectedValue == null) return;

            string maKH = cbbChonHP.SelectedValue.ToString();

            var data = db.BaiKiemTras
                .Where(b => b.KhoaHoc_ma_KH == maKH)
                .Select(b => new
                {
                    MaBKT = b.ma_BKT,
                    TenBKT = b.ten_BKT,
                    HeSo = b.heSo,
                    NgayKT = b.ngayKT,
                    HocPhan = b.KhoaHoc.ten_KH
                })
                .ToList();

            dgvDanhSachBKT.DataSource = data;

            dgvDanhSachBKT.Columns["MaBKT"].HeaderText = "Mã BKT";
            dgvDanhSachBKT.Columns["TenBKT"].HeaderText = "Tên bài kiểm tra";
            dgvDanhSachBKT.Columns["HeSo"].HeaderText = "Hệ số";
            dgvDanhSachBKT.Columns["NgayKT"].HeaderText = "Ngày kiểm tra";
            dgvDanhSachBKT.Columns["HocPhan"].HeaderText = "Học phần";
        }

        private void LoadHocPhan()
        {
            cbbChonHP.DataSource = db.KhoaHocs
                    .Select(kh => new
                    {
                        kh.ma_KH,
                        kh.ten_KH
                    })
                    .ToList();

            cbbChonHP.DisplayMember = "ten_KH";
            cbbChonHP.ValueMember = "ma_KH";
            cbbChonHP.SelectedIndex = -1;
        }
        bool KiemTraHeSo(string maKH, float heSoMoi)
        {
            float tong = db.BaiKiemTras
                .Where(b => b.KhoaHoc_ma_KH == maKH)
                .Sum(b => (float?)b.heSo) ?? 0;

            return tong + heSoMoi <= 1.0f;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbChonHP.SelectedValue == null ||
                txtMaBKT.Text == "" ||
                txtTenBKT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            float heSo = float.Parse(nudHeSo.Text);
            string maKH = cbbChonHP.SelectedValue.ToString();

            if (!KiemTraHeSo(maKH, heSo))
            {
                MessageBox.Show("Tổng hệ số vược quá 1.0!");
                return;
            }

            if (db.BaiKiemTras.Find(txtMaBKT.Text) != null)
            {
                MessageBox.Show("Mã bài kiểm tra đã tồn tại!");
                return;
            }

            var bkt = new BaiKiemTra
            {
                ma_BKT = txtMaBKT.Text,
                ten_BKT = txtTenBKT.Text,
                heSo = heSo,
                ngayKT = dtpNgayKT.Value,
                KhoaHoc_ma_KH = maKH
            };

            db.BaiKiemTras.Add(bkt);
            db.SaveChanges();
            LoadData();
            ClearInput();
        }

        private void ClearInput()
        {
            txtMaBKT.Clear();
            txtTenBKT.Clear();
            nudHeSo.Value = 0;
            dtpNgayKT.Value = DateTime.Now;
            txtMaBKT.Enabled = true;
        }

        private void dgvDanhSachBKT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaBKT.Text = dgvDanhSachBKT.Rows[e.RowIndex].Cells["MaBKT"].Value.ToString();
                txtTenBKT.Text = dgvDanhSachBKT.Rows[e.RowIndex].Cells["TenBKT"].Value.ToString();
                nudHeSo.Text = dgvDanhSachBKT.Rows[e.RowIndex].Cells["HeSo"].Value.ToString();
                dtpNgayKT.Value = Convert.ToDateTime(
                    dgvDanhSachBKT.Rows[e.RowIndex].Cells["NgayKT"].Value);

                txtMaBKT.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaBKT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bài kiểm tra để sửa!");
                return;
            }
            var bkt = db.BaiKiemTras.Find(txtMaBKT.Text);
            if (bkt != null)
            {
                float heSoMoi = float.Parse(nudHeSo.Text);
                string maKH = cbbChonHP.SelectedValue.ToString();
                float tongHeSoKhac = db.BaiKiemTras
                    .Where(b => b.KhoaHoc_ma_KH == maKH && b.ma_BKT != bkt.ma_BKT)
                    .Sum(b => (float?)b.heSo) ?? 0;
                if (tongHeSoKhac + heSoMoi > 1.0001f)
                {
                    MessageBox.Show("Tổng hệ số vượt quá 1.0!");
                    return;
                }
                bkt.ten_BKT = txtTenBKT.Text;
                bkt.heSo = heSoMoi;
                bkt.ngayKT = dtpNgayKT.Value;
                db.SaveChanges();
                LoadData();
                ClearInput();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaBKT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bài kiểm tra để xóa!");
                return;
            }
            var bkt = db.BaiKiemTras.Find(txtMaBKT.Text);
            if (bkt.Diems.Any())
            {
                MessageBox.Show("Bai kiem tra da co diem, khong the xoa!");
                return;
            }
            if (bkt != null)
            {
                db.BaiKiemTras.Remove(bkt);
                db.SaveChanges();
                LoadData();
                ClearInput();
            }
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInput();
        }
    }
}
