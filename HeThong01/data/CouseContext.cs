using HeThong01.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong01.data
{
    internal class CouseContext : DbContext
    {

        public CouseContext() : base("name = DefaultConnection") { }

        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<GiangVien> GiangViens { get;set; }
        public DbSet<BaiKiemTra> BaiKiemTras { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<Diem> Diems { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    }
}
