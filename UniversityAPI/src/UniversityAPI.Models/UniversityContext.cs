using Microsoft.EntityFrameworkCore;

namespace UniversityAPI.Models
{
    /// <summary>
    /// Represents the database context for the University API, managing the connection and mapping of entities to the database.
    /// </summary>
    public class UniversityContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the DbSet for courses.
        /// </summary>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for professors.
        /// </summary>
        public DbSet<Professor> Professors { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for students.
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for sections.
        /// </summary>
        public DbSet<Section> Sections { get; set; }

        /// <summary>
        /// Configures the relationships and mappings between entities in the database.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the database schema.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Sections)
                .WithMany(s => s.Students)
                .UsingEntity(j => j.ToTable("StudentSections"));
        }
    }
}