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
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Cấu hình quan hệ nhiều-nhiều
        modelBuilder.Entity<SinhVien>()
            .HasMany(u => u.BaiKiemTras)
            .WithMany(r => r.SinhViens)
            .Map(m =>
            {
                m.ToTable("SV_BKT");
                m.MapLeftKey("SinhVien_maSV");
                m.MapRightKey("BaiKiemTra_maBKT");
            });

        base.OnModelCreating(modelBuilder);
    }

        


    }
}
