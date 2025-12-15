using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01.model
{
    internal class SinhVien
    {
        [Key]
        public string ma_SV { get; set; }

        [Required]
        [MaxLength(100)]
        public string hoTen_SV { get; set; }
        public bool gioiTinh { get; set; }
        public string email_SV { get; set; }
        public string diaChi_SV { get; set; }
        public string SDT_SV { get; set; }
        public DateTime ngaySinh {  get; set; }

        //Lien ket
        public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();


        //Quan he n-n voi BaiKiemTra
        public virtual ICollection<BaiKiemTra> BaiKiemTras { get; set; } 

        public SinhVien()
        {
            BaiKiemTras = new HashSet<BaiKiemTra>();
        }
    }
}
