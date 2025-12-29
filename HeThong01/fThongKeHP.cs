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
using System.Windows.Forms.DataVisualization.Charting;

namespace HeThong01
{
    public partial class fThongKeHP : Form
    {
        CouseContext db = new CouseContext();
        public fThongKeHP()
        {
            InitializeComponent();
        }

        private void fThongKeHP_Load(object sender, EventArgs e)
        {
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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cbbHocPhan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn học phần!");
                return;
            }

            string maKH = cbbHocPhan.SelectedValue.ToString();
            var service = new ThongKeService();

            var dsSV = db.SinhViens
                .Select(sv => new
                {
                    sv.ma_SV,
                    sv.hoTen_SV
                })
                .ToList();
            var result = new List<ThongKeHocPhanDTO>();

            foreach (var sv in dsSV)
            {
                float diem = service.TinhDiemTongKet(sv.ma_SV, maKH);

                result.Add(new ThongKeHocPhanDTO
                {
                    MaSV = sv.ma_SV,
                    TenSV = sv.hoTen_SV,
                    DiemTongKet = diem,
                    XepLoai = service.XepLoai(diem)
                });
            }

            dgvThongKeHP.DataSource = result;

            dgvThongKeHP.Columns["DiemTongKet"].DefaultCellStyle.Format = "0.00";

            dgvThongKeHP.ReadOnly = true;

            VeBieuDoHocPhan(result);
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            dgvThongKeHP.DataSource = null;
            cbbHocPhan.SelectedIndex = -1;
            chartThongKe.Series.Clear();
        }

        private void VeBieuDoHocPhan(List<ThongKeHocPhanDTO> data)
        {
            chartThongKe.Series.Clear();

            var series = new Series("Số lượng sinh viên");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            // Group theo xếp loại
            var thongKe = data
                .GroupBy(x => x.XepLoai)
                .Select(g => new
                {
                    XepLoai = g.Key,
                    SoLuong = g.Count()
                })
                .OrderBy(x =>
                        x.XepLoai == "Gioi" ? 1 :
                        x.XepLoai == "Kha" ? 2 :
                        x.XepLoai == "Trung binh" ? 3 : 4)
                .ToList();

            foreach (var item in thongKe)
            {
                series.Points.AddXY(item.XepLoai, item.SoLuong);
            }

            chartThongKe.Series.Add(series);

            chartThongKe.ChartAreas[0].AxisX.Title = "Xếp loại";
            chartThongKe.ChartAreas[0].AxisY.Title = "Số lượng sinh viên";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }
    }
}
