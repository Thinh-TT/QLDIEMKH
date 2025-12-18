using HeThong01.data;
using HeThong01.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong01
{
    public partial class fQLKH : Form
    {
        CouseContext db = new CouseContext();

        public fQLKH()
        {
            InitializeComponent();
        }

        private void clearInput()
        {
            txtMaHP.Clear();
            txtTenHP.Clear();
            txtSoTinChi.Clear();
            cbbGVphuTrach.SelectedIndex = -1;
            LoadData();
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        void LoadData()
        {
            dgvDanhSachKH.DataSource = db.KhoaHocs.ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHP.Text == "" ||
                txtTenHP.Text == "" ||
                txtSoTinChi.Text == "" ||
                cbbGVphuTrach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var check = db.KhoaHocs.Find(txtMaHP.Text);
            if (check != null)
            {
                MessageBox.Show("Mã khóa học đã tồn tại!");
                return;
            }

            var hp = new KhoaHoc
            {
                ma_KH = txtMaHP.Text,
                ten_KH = txtTenHP.Text,
                So_TC = int.Parse(txtSoTinChi.Text),
                GiangVien_ma_GV = cbbGVphuTrach.SelectedValue.ToString()
            };
            db.KhoaHocs.Add(hp);
            db.SaveChanges();
            LoadData();
            clearInput();
        }

        

        private void fQLKH_Load(object sender, EventArgs e)
        {
            using (var db = new CouseContext())
            {
                var categories = db.GiangViens
                                   .Select(c => new
                                   {
                                       c.ma_GV,
                                       c.hoTen_GV
                                   })
                                   .ToList();

                cbbGVphuTrach.DataSource = categories;
                cbbGVphuTrach.DisplayMember = "hoTen_GV"; // hiển thị
                cbbGVphuTrach.ValueMember = "ma_GV";     // giá trị ngầm
            }
            cbbGVphuTrach.SelectedIndex = -1;

        }
    }
}
