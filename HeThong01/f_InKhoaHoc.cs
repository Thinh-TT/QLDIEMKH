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
    public partial class f_InKhoaHoc : Form
    {
        public f_InKhoaHoc()
        {
            InitializeComponent();
        }

        private void f_InKhoaHoc_Load(object sender, EventArgs e)
        {

            using (var db = new CouseContext())
            {
                // Lấy danh sách danh mục từ cơ sở dữ liệu sử dụng Entity Framework lấy chỉ id và tên danh mục
                var khoahocs = db.KhoaHocs
                    .Select(c => new
                    {
                        c.ma_KH,
                        c.ten_KH,
                        c.So_TC
                    })
                    .ToList();

                // Thiết lập file rdlc cho ReportViewer
                rpvInKhoaHoc.LocalReport.ReportPath = "Report_InKhoaHoc.rdlc";


                string ngayThang = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;



                // pass value cho tham số trong báo cáo
                Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
            new Microsoft.Reporting.WinForms.ReportParameter("ngayThang", ngayThang),

                };

                rpvInKhoaHoc.LocalReport.SetParameters(reportParameters);

                rpvInKhoaHoc.LocalReport.DataSources.Clear();
                rpvInKhoaHoc.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetKhoaHoc", khoahocs));


                rpvInKhoaHoc.RefreshReport();
            }
        }
    }
}
