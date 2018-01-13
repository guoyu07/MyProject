using Microsoft.AspNet.Identity.EntityFramework;
using MyProject.ENT.IdendityModel;
using MyProject.ENT.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
        : base("name=MyCon")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.RequireUniqueEmail = true;
        }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genres> Genre { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieShowing> MovieShowings { get; set; }
        public virtual DbSet<Players> Player { get; set; }
        public virtual DbSet<Seats> Seat { get; set; }
    }
}
