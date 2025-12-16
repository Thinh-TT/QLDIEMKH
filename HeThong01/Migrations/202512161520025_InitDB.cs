namespace HeThong01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiKiemTras",
                c => new
                    {
                        ma_BKT = c.String(nullable: false, maxLength: 128),
                        ten_BKT = c.String(nullable: false, maxLength: 100),
                        heSo = c.Single(nullable: false),
                        ngayKT = c.DateTime(nullable: false),
                        KhoaHoc_ma_KH = c.String(),
                        KhoaHoc_ma_KH1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ma_BKT)
                .ForeignKey("dbo.KhoaHocs", t => t.KhoaHoc_ma_KH1)
                .Index(t => t.KhoaHoc_ma_KH1);
            
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        ma_SV = c.String(nullable: false, maxLength: 128),
                        ma_BKT = c.String(nullable: false, maxLength: 128),
                        diem = c.Int(nullable: false),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => new { t.ma_SV, t.ma_BKT })
                .ForeignKey("dbo.BaiKiemTras", t => t.ma_BKT, cascadeDelete: true)
                .ForeignKey("dbo.SinhViens", t => t.ma_SV, cascadeDelete: true)
                .Index(t => t.ma_SV)
                .Index(t => t.ma_BKT);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        ma_SV = c.String(nullable: false, maxLength: 128),
                        hoTen_SV = c.String(nullable: false, maxLength: 100),
                        gioiTinh = c.Boolean(nullable: false),
                        email_SV = c.String(),
                        diaChi_SV = c.String(),
                        SDT_SV = c.String(),
                        ngaySinh = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ma_SV);
            
            CreateTable(
                "dbo.GiangViens",
                c => new
                    {
                        ma_GV = c.String(nullable: false, maxLength: 128),
                        hoTen_GV = c.String(nullable: false, maxLength: 100),
                        email_GV = c.String(),
                        diaChi_GV = c.String(),
                        SDT_GV = c.String(),
                        ngaySinh = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ma_GV);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        ma_KH = c.String(nullable: false, maxLength: 128),
                        ten_KH = c.String(nullable: false),
                        So_TC = c.Int(nullable: false),
                        GiangVien_ma_GV = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ma_KH)
                .ForeignKey("dbo.GiangViens", t => t.GiangVien_ma_GV)
                .Index(t => t.GiangVien_ma_GV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhoaHocs", "GiangVien_ma_GV", "dbo.GiangViens");
            DropForeignKey("dbo.BaiKiemTras", "KhoaHoc_ma_KH1", "dbo.KhoaHocs");
            DropForeignKey("dbo.Diems", "ma_SV", "dbo.SinhViens");
            DropForeignKey("dbo.Diems", "ma_BKT", "dbo.BaiKiemTras");
            DropIndex("dbo.KhoaHocs", new[] { "GiangVien_ma_GV" });
            DropIndex("dbo.Diems", new[] { "ma_BKT" });
            DropIndex("dbo.Diems", new[] { "ma_SV" });
            DropIndex("dbo.BaiKiemTras", new[] { "KhoaHoc_ma_KH1" });
            DropTable("dbo.KhoaHocs");
            DropTable("dbo.GiangViens");
            DropTable("dbo.SinhViens");
            DropTable("dbo.Diems");
            DropTable("dbo.BaiKiemTras");
        }
    }
}
