using HeThong01.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong01
{
    public partial class fr_InGiangViencs : Form
    {
        public fr_InGiangViencs()
        {
            InitializeComponent();
        }

        private void fr_InGiangViencs_Load(object sender, EventArgs e)
        {

            using (var db = new CouseContext())
            {
                // Lấy danh sách danh mục từ cơ sở dữ liệu sử dụng Entity Framework lấy chỉ id và tên danh mục
                var giangviens = db.GiangViens
                    .Select(c => new
                    {
                        c.ma_GV,
                        c.hoTen_GV,
                        c.ngaySinh,
                        c.email_GV
                    })
                    .ToList();

                // Thiết lập file rdlc cho ReportViewer
                rpvInGiangVien.LocalReport.ReportPath = "ReportInGiangVien.rdlc";


                string ngayThang = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;
                int soLuongDanhMuc = giangviens.Count;


                // pass value cho tham số trong báo cáo
                Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
            new Microsoft.Reporting.WinForms.ReportParameter("ngayThang", ngayThang),
            new Microsoft.Reporting.WinForms.ReportParameter("soLuong", soLuongDanhMuc.ToString())
                };

                rpvInGiangVien.LocalReport.SetParameters(reportParameters);

                rpvInGiangVien.LocalReport.DataSources.Clear();
                rpvInGiangVien.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetGiangVien", giangviens));


                rpvInGiangVien.RefreshReport();

            }
        }
    }
}
