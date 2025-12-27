using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("KhoaHoc_ma_KH")]
        public virtual KhoaHoc KhoaHoc { get; set; }

        //Lien ket
        public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

       
    }
}
