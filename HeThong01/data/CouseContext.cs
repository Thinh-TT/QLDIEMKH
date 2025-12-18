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
        public DbSet<User> Users { get; set; }  
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            modelBuilder.Entity<User>()
           .HasMany(u => u.Roles)
           .WithMany(r => r.Users)
           .Map(m =>
           {
               m.ToTable("UserRoles");
               m.MapLeftKey("UserId");
               m.MapRightKey("RoleId");
           });
            base.OnModelCreating(modelBuilder);
    }

    }
}
