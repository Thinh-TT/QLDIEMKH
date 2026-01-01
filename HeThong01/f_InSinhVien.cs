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
    public partial class f_InSinhVien : Form
    {
        public f_InSinhVien()
        {
            InitializeComponent();
        }

        private void f_InSinhVien_Load(object sender, EventArgs e)
        {

            using (var db = new CouseContext())
            {
                // Lấy danh sách danh mục từ cơ sở dữ liệu sử dụng Entity Framework lấy chỉ id và tên danh mục
                var sinhviens = db.SinhViens
                    .Select(c => new
                    {
                        c.ma_SV,
                        c.hoTen_SV,
                        c.gioiTinh,
                        c.ngaySinh,
                        c.email_SV,
                        c.diaChi_SV
                    })
                    .ToList();

                // Thiết lập file rdlc cho ReportViewer
                rpvInSinhVien.LocalReport.ReportPath = "Report_InSinhVien.rdlc";


                string ngayThang = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;
                int soLuong = sinhviens.Count;


                // pass value cho tham số trong báo cáo
                Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
            new Microsoft.Reporting.WinForms.ReportParameter("ngayThang", ngayThang),
            new Microsoft.Reporting.WinForms.ReportParameter("soLuong", soLuong.ToString())
                };

                rpvInSinhVien.LocalReport.SetParameters(reportParameters);

                rpvInSinhVien.LocalReport.DataSources.Clear();
                rpvInSinhVien.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetSinhVien", sinhviens));


                rpvInSinhVien.RefreshReport();
            }
        }
    }
}
