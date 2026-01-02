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
    public partial class fNhapDiem : Form
    {
        CouseContext db = new CouseContext();
        public fNhapDiem()
        {
            InitializeComponent();
        }

        private void fNhapDiem_Load(object sender, EventArgs e)
        {
            lblThongTin.Text = "";
            LoadKhoaHoc();
        }

        private void LoadKhoaHoc()
        {
            cbbHocPhan.DataSource = db.KhoaHocs
                .Select(k => new
                {
                    k.ma_KH,
                    k.ten_KH
                })
                .ToList();

            cbbHocPhan.DisplayMember = "ten_KH";
            cbbHocPhan.ValueMember = "ma_KH";
            cbbHocPhan.SelectedIndex = -1;
        }

        private void cbbHocPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbHocPhan.SelectedIndex == -1) return;

            string maKH = cbbHocPhan.SelectedValue.ToString();

            cbbBaiKT.DataSource = db.BaiKiemTras
                .Where(b => b.KhoaHoc_ma_KH == maKH)
                .Select(b => new
                {
                    b.ma_BKT,
                    b.ten_BKT,
                    b.heSo,
                    b.ngayKT
                })
                .ToList();

            cbbBaiKT.DisplayMember = "ten_BKT";
            cbbBaiKT.ValueMember = "ma_BKT";
            cbbBaiKT.SelectedIndex = -1;
        }

        private void cbbBaiKT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBaiKT.SelectedIndex == -1) return;

            string maBKT = cbbBaiKT.SelectedValue.ToString();

            // hiển thị hệ số + ngày KT
            var bkt = db.BaiKiemTras.Find(maBKT);
            lblThongTin.Text = $"Hệ số: {bkt.heSo} | Ngày KT: {bkt.ngayKT:dd/MM/yyyy}";

            LoadDanhSachNhapDiem(maBKT);
        }

        private void LoadDanhSachNhapDiem(string maBKT)
        {
            var data = (from sv in db.SinhViens
                        join d in db.Diems.Where(x => x.ma_BKT == maBKT)
                        on sv.ma_SV equals d.ma_SV into temp
                        from diem in temp.DefaultIfEmpty()
                        select new DiemNhapDTO
                        {
                            MaSV = sv.ma_SV,
                            TenSV = sv.hoTen_SV,
                            Diem = diem != null ? diem.diem : (float?)null,
                            GhiChu = diem != null ? diem.ghiChu : ""
                        }).ToList();

            //dgvDanhSachDiem.AutoGenerateColumns = true;
            dgvDanhSachDiem.DataSource = data;


            dgvDanhSachDiem.Columns["MaSV"].HeaderText = "Mã SV";
            dgvDanhSachDiem.Columns["TenSV"].HeaderText = "Tên sinh viên";
            dgvDanhSachDiem.Columns["Diem"].HeaderText = "Điểm";
            dgvDanhSachDiem.Columns["GhiChu"].HeaderText = "Ghi chú";

            dgvDanhSachDiem.Columns["MaSV"].ReadOnly = true;
            dgvDanhSachDiem.Columns["TenSV"].ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbbBaiKT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn bài kiểm tra!");
                return;
            }

            string maBKT = cbbBaiKT.SelectedValue.ToString();

            foreach (DataGridViewRow row in dgvDanhSachDiem.Rows)
            {
                if (row.IsNewRow) continue;

                string maSV = row.Cells["MaSV"].Value.ToString();
                float? diemNhap = row.Cells["Diem"].Value == null
                    ? (float?)null
                    : float.Parse(row.Cells["Diem"].Value.ToString());

                string ghiChu = row.Cells["GhiChu"].Value?.ToString();

                var diem = db.Diems.Find(maSV, maBKT);

                if (diem == null)
                {
                    if (diemNhap == null) continue;

                    db.Diems.Add(new Diem
                    {
                        ma_SV = maSV,
                        ma_BKT = maBKT,
                        diem = diemNhap.Value,
                        ghiChu = ghiChu
                    });
                }
                else
                {
                    diem.diem = diemNhap ?? diem.diem;
                    diem.ghiChu = ghiChu;
                }
            }

            db.SaveChanges();
            MessageBox.Show("Lưu điểm thành công!");
            LoadDanhSachNhapDiem(maBKT);
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            cbbHocPhan.SelectedIndex = -1;
            cbbBaiKT.DataSource = null;
            dgvDanhSachDiem.DataSource = null;
            lblThongTin.Text = "";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cbbBaiKT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn bài kiểm tra!");
                return;
            }

            string maBKT = cbbBaiKT.SelectedValue.ToString();
            f_InDiem f = new f_InDiem(maBKT); 
            f.ShowDialog();
        }
    }
}
