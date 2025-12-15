using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01.model
{
    internal class Diem
    {
        [Required]
        public int diem { get; set; }
        public string ghiChu {get;set; }

        
    }
}                                     
