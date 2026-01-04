using HeThong01.data;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong01
{
    public partial class f_InTheoSinhVien : Form
    {
        List<ThongKeSinhVienDTO> _tkSV;
        private string _maSV;
        private string _tenSV;
        private float _gpa;
        private string _xepLoai;

        public f_InTheoSinhVien(List<ThongKeSinhVienDTO> tkSV, string maSV, string tenSV, float gpa, string xepLoai)
        {
            InitializeComponent();
            _tkSV = tkSV;
            _maSV = maSV;
            _tenSV = tenSV;
            _gpa = gpa;
            _xepLoai = xepLoai;

        }

        private void f_InTheoSinhVien_Load(object sender, EventArgs e)
        {
            using (var db = new CouseContext())
            {
                var sinhviens = db.Diems
                    .Where(d => d.ma_SV == _maSV)
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
                        DiemTongKet = (float)g.Sum(x => x.diem * x.BaiKiemTra.heSo),
                        XepLoai =
                            g.Sum(x => x.diem * x.BaiKiemTra.heSo) >= 8.5 ? "Giỏi" :
                            g.Sum(x => x.diem * x.BaiKiemTra.heSo) >= 7.0 ? "Khá" :
                            g.Sum(x => x.diem * x.BaiKiemTra.heSo) >= 5.0 ? "Trung bình" :
                            "Yếu"
                    })
                    .ToList();





                // Thiết lập file rdlc cho ReportViewer
                rpvInTKSinhVien.LocalReport.ReportPath = "Report_InTheoSinhVien.rdlc";


                string ngayThang = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;


                // pass value cho tham số trong báo cáo
                Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
            new Microsoft.Reporting.WinForms.ReportParameter("ngayThang", ngayThang),
            new ReportParameter("tenSinhVien",_tenSV),
            new ReportParameter("maSinhVien",_maSV),
            new ReportParameter("GPA", _gpa.ToString("0.00")),
            new ReportParameter("XepLoai", _xepLoai)

                };

                rpvInTKSinhVien.LocalReport.SetParameters(reportParameters);


                rpvInTKSinhVien.LocalReport.DataSources.Clear();
                rpvInTKSinhVien.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetTKSinhVien", sinhviens));


                rpvInTKSinhVien.RefreshReport();
            }
        }
    }
}
