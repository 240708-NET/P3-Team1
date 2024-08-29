using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    /// <summary>
    /// Represents a course offered at the university.
    /// </summary>
    public class Course : Identified
    {
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the course.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the category to which the course belongs.
        /// </summary>
        [MaxLength(50)]
        public string Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        public Course()
        {
            Name = "";
            Description = "";
            Category = "";
        }
    }
}