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
    public partial class fThongKeSV : Form
    {
        CouseContext db = new CouseContext();
        private float _gpa;
        private string _xepLoai;
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
                    DiemTongKet = (float)g.Sum(x => x.diem * x.BaiKiemTra.heSo)
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

            _gpa = TinhGPA(data);
            _xepLoai = XepLoai(_gpa);

            lblthongtin.Text = $"GPA: {_gpa:F2} | Xếp loại: {_xepLoai}";
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            cbbSinhVien.SelectedIndex = -1;
            dgvThongKeSV.DataSource = null;
            lblthongtin.Text = "...";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvThongKeSV.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để in");
                return;
            }

            List<ThongKeSinhVienDTO> tkSV = new List<ThongKeSinhVienDTO>();

            foreach (DataGridViewRow row in dgvThongKeSV.Rows)
            {
                if (row.IsNewRow) continue;

                tkSV.Add(new ThongKeSinhVienDTO
                {
                    MaKH = row.Cells["MaKH"].Value.ToString(),
                    TenKH = row.Cells["TenKH"].Value.ToString(),
                    DiemTongKet = Convert.ToSingle(row.Cells["DiemTongKet"].Value),
                    SoTinChi = Convert.ToInt32(row.Cells["SoTinChi"].Value)
                });
            }

            string maSV = cbbSinhVien.SelectedValue.ToString();
            string tenSV = cbbSinhVien.Text;

            f_InTheoSinhVien f = new f_InTheoSinhVien(
                tkSV,
                maSV,
                tenSV,
                _gpa,
                _xepLoai
            );

            f.ShowDialog();
        }

        
    }
}
