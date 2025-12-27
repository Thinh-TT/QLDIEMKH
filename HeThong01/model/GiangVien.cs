using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01.model
{
    internal class GiangVien
    {
        [Key]
        public string ma_GV { get; set; }
        [Required]
        [MaxLength(100)]
        public string hoTen_GV { get; set; }
        [EmailAddress]
        public string email_GV { get; set; }
        
        public string diaChi_GV { get; set; }
        [Phone]
        public string SDT_GV { get; set; }
        [DataType(DataType.Date)]
        public DateTime ngaySinh { get; set; }

        //Lien ket
        public virtual ICollection<KhoaHoc> khoaHocs { get; set; } = new List<KhoaHoc>();
    }
}
