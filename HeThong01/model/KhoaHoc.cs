using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01.model
{
    internal class KhoaHoc
    {
        [Key]
        public string ma_KH { get; set; }
        [Required]
        public string ten_KH { get; set; }
        [Required]
        public int So_TC { get; set; }



        //Khoa ngoai
        [ForeignKey("GiangVien")]
        public string GiangVien_ma_GV { get; set; }

        //Navigation
        public virtual GiangVien GiangVien { get; set; }

        //Lien ket
        public virtual ICollection<BaiKiemTra> BaiKiemTras { get; set; } = new List<BaiKiemTra>();



    }
}
