using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01.model
{
    internal class BaiKiemTra
    {
        [Key]
        public string ma_BKT { get; set; }
        [Required]
        [MaxLength(100)]
        public string ten_BKT { get; set; }
        [Range(0.1,1.0)]
        public float heSo { get; set; }
        public DateTime ngayKT { get; set; }

        //Khoa ngoai
        public string KhoaHoc_ma_KH { get; set; }
        public string SinhVien_ma_SV { get; set; }

        //Lien ket
        public virtual ICollection<Diem> diems { get; set; } = new List<Diem>();

        //Quan he n-n voi SinhVien
        public virtual ICollection<SinhVien> SinhViens { get; set; }

        public BaiKiemTra()
        {
            SinhViens = new HashSet<SinhVien>();
        }

    }
}
