namespace HeThong01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdatabase : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BaiKiemTras", new[] { "KhoaHoc_ma_KH1" });
            DropColumn("dbo.BaiKiemTras", "KhoaHoc_ma_KH");
            RenameColumn(table: "dbo.BaiKiemTras", name: "KhoaHoc_ma_KH1", newName: "KhoaHoc_ma_KH");
            AlterColumn("dbo.BaiKiemTras", "KhoaHoc_ma_KH", c => c.String(maxLength: 128));
            AlterColumn("dbo.Diems", "diem", c => c.Single(nullable: false));
            CreateIndex("dbo.BaiKiemTras", "KhoaHoc_ma_KH");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BaiKiemTras", new[] { "KhoaHoc_ma_KH" });
            AlterColumn("dbo.Diems", "diem", c => c.Int(nullable: false));
            AlterColumn("dbo.BaiKiemTras", "KhoaHoc_ma_KH", c => c.String());
            RenameColumn(table: "dbo.BaiKiemTras", name: "KhoaHoc_ma_KH", newName: "KhoaHoc_ma_KH1");
            AddColumn("dbo.BaiKiemTras", "KhoaHoc_ma_KH", c => c.String());
            CreateIndex("dbo.BaiKiemTras", "KhoaHoc_ma_KH1");
        }
    }
}
