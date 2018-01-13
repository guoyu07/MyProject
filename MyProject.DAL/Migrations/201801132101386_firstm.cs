namespace MyProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MovieShowingId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieShowing", t => t.MovieShowingId, cascadeDelete: true)
                .Index(t => t.MovieShowingId);
            
            CreateTable(
                "dbo.MovieShowing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MovieId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DirectorId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Country = c.String(),
                        Lang = c.String(),
                        Subtitle = c.String(),
                        GenresId = c.Int(nullable: false),
                        Production = c.String(),
                        Runtime = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Director", t => t.DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenresId, cascadeDelete: true)
                .Index(t => t.DirectorId)
                .Index(t => t.GenresId);
            
            CreateTable(
                "dbo.Director",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.String(maxLength: 2),
                        SeatNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 25),
                        SurName = c.String(maxLength: 35),
                        RegisterDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        DepartmentId = c.Int(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivationCode = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SeatsBookings",
                c => new
                    {
                        Seats_Id = c.Int(nullable: false),
                        Booking_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seats_Id, t.Booking_Id })
                .ForeignKey("dbo.Seats", t => t.Seats_Id, cascadeDelete: true)
                .ForeignKey("dbo.Booking", t => t.Booking_Id, cascadeDelete: true)
                .Index(t => t.Seats_Id)
                .Index(t => t.Booking_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SeatsBookings", "Booking_Id", "dbo.Booking");
            DropForeignKey("dbo.SeatsBookings", "Seats_Id", "dbo.Seats");
            DropForeignKey("dbo.Booking", "MovieShowingId", "dbo.MovieShowing");
            DropForeignKey("dbo.MovieShowing", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Players", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.Movie", "GenresId", "dbo.Genres");
            DropForeignKey("dbo.Movie", "DirectorId", "dbo.Director");
            DropIndex("dbo.SeatsBookings", new[] { "Booking_Id" });
            DropIndex("dbo.SeatsBookings", new[] { "Seats_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Players", new[] { "Movie_Id" });
            DropIndex("dbo.Movie", new[] { "GenresId" });
            DropIndex("dbo.Movie", new[] { "DirectorId" });
            DropIndex("dbo.MovieShowing", new[] { "MovieId" });
            DropIndex("dbo.Booking", new[] { "MovieShowingId" });
            DropTable("dbo.SeatsBookings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Seats");
            DropTable("dbo.Players");
            DropTable("dbo.Genres");
            DropTable("dbo.Director");
            DropTable("dbo.Movie");
            DropTable("dbo.MovieShowing");
            DropTable("dbo.Booking");
        }
    }
}
