using HeThong01.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01
{
    public class ThongKeService
    {
        CouseContext db = new CouseContext();

        // Tính điểm tổng kết 1 SV trong 1 học phần
        public float TinhDiemTongKet(string maSV, string maKH)
        {
            var dsDiem = db.Diems
                .Where(d => d.ma_SV == maSV &&
                            d.BaiKiemTra.KhoaHoc_ma_KH == maKH)
                .Select(d => d.diem * d.BaiKiemTra.heSo)
                .ToList();

            return dsDiem.Any() ? dsDiem.Sum() : 0;
        }

        // Xếp loại học lực
        public string XepLoai(float diem)
        {
            if (diem >= 8.5) return "Giỏi";
            if (diem >= 7.0) return "Khá";
            if (diem >= 5.0) return "Trung bình";
            return "Yếu";
        }
    }
}
