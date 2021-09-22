using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;


namespace GitHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        internal object Include()
        {
            throw new NotImplementedException();
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>().HasRequired(a => a.gig).WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}