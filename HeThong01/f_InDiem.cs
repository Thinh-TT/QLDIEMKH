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
        private string _maBKT;
        public f_InDiem()
        {
            InitializeComponent();
        }
        public f_InDiem(string maBKT)
        {
            InitializeComponent();
            _maBKT = maBKT;
        }

        private void f_InDiem_Load(object sender, EventArgs e)
        {

            using (var db = new CouseContext())
            {
                // Lấy danh sách danh mục từ cơ sở dữ liệu sử dụng Entity Framework lấy chỉ id và tên danh mục
                //var diems = db.Diems
                //    .Select(c => new
                //    {
                //        SinhVien = c.SinhVien.hoTen_SV,
                //        BaiKiemTra = c.BaiKiemTra.ten_BKT,
                //        c.diem
                //    })
                //    .ToList();

                var diems = (from d in db.Diems
                             join sv in db.SinhViens
                             on d.ma_SV equals sv.ma_SV
                             where d.ma_BKT == _maBKT
                             select new DiemNhapDTO
                             {
                                 MaSV = sv.ma_SV,
                                 TenSV = sv.hoTen_SV,
                                 Diem = d.diem,
                                 GhiChu = d.ghiChu,
                                 MaBKT = d.ma_BKT
                             }).ToList();


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
