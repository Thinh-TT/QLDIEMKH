using HeThong01.data;
using HeThong01.model;
using Microsoft.Reporting.WinForms;
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
    public partial class f_InThongKeHP : Form
    {
        private List<ThongKeHocPhanDTO> _tkHP;
        private string _maMH;
        private string _tenMH;
        
        
        public f_InThongKeHP(List<ThongKeHocPhanDTO> tkHP,string maMH, string tenMH)
        {
            InitializeComponent();
            _tkHP = tkHP;
            _maMH = maMH;
            _tenMH = tenMH;
            
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

                //var diems = (from d in db.Diems
                //             join sv in db.SinhViens on d.ma_SV equals sv.ma_SV
                //             join bkt in db.BaiKiemTras on d.ma_BKT equals bkt.ma_BKT
                //             join kh in db.KhoaHocs on bkt.KhoaHoc_ma_KH equals kh.ma_KH
                //             where kh.ma_KH == _maMH
                //             select new ThongKeHocPhanDTO
                //             {
                //                 MaSV = sv.ma_SV,
                //                 TenSV = sv.hoTen_SV,
                //                 DiemTongKet = d.diem,


                //             }).ToList();




                //// Thiết lập file rdlc cho ReportViewer
                rpvInDiem.LocalReport.ReportPath = "Report_InTheoHocPhan.rdlc";


                string ngayThang = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;
                

                // pass value cho tham số trong báo cáo
                Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
            new Microsoft.Reporting.WinForms.ReportParameter("ngayThang", ngayThang),
            new ReportParameter("tenKhoaHoc", _tenMH)
                };

                rpvInDiem.LocalReport.SetParameters(reportParameters);
                

                rpvInDiem.LocalReport.DataSources.Clear();
                rpvInDiem.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetDiem", _tkHP));


                rpvInDiem.RefreshReport();
            }
        }
    }
}
