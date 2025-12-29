using HeThong01.data;
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
    public partial class fThongKeSV : Form
    {
        CouseContext db = new CouseContext();
        public fThongKeSV()
        {
            InitializeComponent();
        }

        private void fThongKeSV_Load(object sender, EventArgs e)
        {
            LoadSinhVien();
        }

        private void LoadSinhVien()
        {
            cbbSinhVien.DataSource = db.SinhViens
                .Select(sv => new
                {
                    sv.ma_SV,
                    sv.hoTen_SV
                })
                .ToList();

            cbbSinhVien.DisplayMember = "hoTen_SV";
            cbbSinhVien.ValueMember = "ma_SV";
            cbbSinhVien.SelectedIndex = -1;
        }

        private List<ThongKeSinhVienDTO> ThongKeTheoSinhVien(string maSV)
        {
            var data = db.Diems
                .Where(d => d.ma_SV == maSV)
                .GroupBy(d => new
                {
                    d.BaiKiemTra.KhoaHoc.ma_KH,
                    d.BaiKiemTra.KhoaHoc.ten_KH,
                    d.BaiKiemTra.KhoaHoc.So_TC
                })
                .Select(g => new ThongKeSinhVienDTO
                {
                    MaKH = g.Key.ma_KH,
                    TenKH = g.Key.ten_KH,
                    SoTinChi = g.Key.So_TC,
                    DiemTongKet = g.Sum(x => x.diem * x.BaiKiemTra.heSo)
                })
                .ToList();

            return data;
        }

        private float TinhGPA(List<ThongKeSinhVienDTO> data)
        {
            if (!data.Any()) return 0;

            float tongDiem = data.Sum(x => x.DiemTongKet * x.SoTinChi);
            int tongTC = data.Sum(x => x.SoTinChi);

            return tongTC == 0 ? 0 : tongDiem / tongTC;
        }

        private string XepLoai(float gpa)
        {
            if (gpa >= 8.5) return "Giỏi";
            if (gpa >= 7.0) return "Khá";
            if (gpa >= 5.0) return "Trung bình";
            return "Yếu";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cbbSinhVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sinh viên");
                return;
            }

            string maSV = cbbSinhVien.SelectedValue.ToString();

            var data = ThongKeTheoSinhVien(maSV);
            dgvThongKeSV.DataSource = data;

            float gpa = TinhGPA(data);
            lblthongtin.Text = $"GPA: {gpa:F2} | Xếp loại: {XepLoai(gpa)}";
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            cbbSinhVien.SelectedIndex = -1;
            dgvThongKeSV.DataSource = null;
            lblthongtin.Text = "...";
        }
    }
}
