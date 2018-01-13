namespace MyProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Booking", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Booking", "CustomerId");
            AddForeignKey("dbo.Booking", "CustomerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "CustomerId", "dbo.AspNetUsers");
            DropIndex("dbo.Booking", new[] { "CustomerId" });
            AlterColumn("dbo.Booking", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
