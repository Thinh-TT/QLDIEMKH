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
    public partial class f_InDiem : Form
    {
        public f_InDiem()
        {
            InitializeComponent();
        }

        private void f_InDiem_Load(object sender, EventArgs e)
        {

            using (var db = new CouseContext())
            {
                // Lấy danh sách danh mục từ cơ sở dữ liệu sử dụng Entity Framework lấy chỉ id và tên danh mục
                var diems = db.Diems
                    .Select(c => new
                    {
                        SinhVien = c.SinhVien.hoTen_SV,
                        BaiKiemTra = c.BaiKiemTra.ten_BKT,
                        c.diem
                    })
                    .ToList();

                // Thiết lập file rdlc cho ReportViewer
                rpvInDiem.LocalReport.ReportPath = "Report_InDiem.rdlc";


                string ngayThang = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;


                // pass value cho tham số trong báo cáo
                Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
            new Microsoft.Reporting.WinForms.ReportParameter("ngayThang", ngayThang),
                };

                rpvInDiem.LocalReport.SetParameters(reportParameters);

                rpvInDiem.LocalReport.DataSources.Clear();
                rpvInDiem.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetDiem", diems));


                rpvInDiem.RefreshReport();
            }
        }
    }
}
