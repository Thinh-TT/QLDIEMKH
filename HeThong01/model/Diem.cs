using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01.model
{
    internal class Diem
    {
        [Key, Column(Order  = 0)]
        public string ma_SV { get; set; }
        [Key, Column(Order = 1)]
        public string ma_BKT { get; set; }

        //[Required]
        //public int diem { get; set; }
        [Range(0, 10)]
        public float diem { get; set; }
        public string ghiChu {get;set; }

        //public virtual SinhVien SinhVien { get; set; }
        //public virtual BaiKiemTra BaiKiemTra { get; set; }

        [ForeignKey("ma_SV")]
        public virtual SinhVien SinhVien { get; set; }

        [ForeignKey("ma_BKT")]
        public virtual BaiKiemTra BaiKiemTra { get; set; }
    }
}                                     
