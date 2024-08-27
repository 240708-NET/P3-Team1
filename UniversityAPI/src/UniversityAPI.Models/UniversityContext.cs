using Microsoft.EntityFrameworkCore;

namespace UniversityAPI.Models
{
    public class UniversityContext : DbContext
    {
        //Includes calling constructor of base class, which is DbContext
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Sections)
                .WithMany(s => s.Students)
                .UsingEntity(j => j.ToTable("StudentSections"));
        }
    }
}
