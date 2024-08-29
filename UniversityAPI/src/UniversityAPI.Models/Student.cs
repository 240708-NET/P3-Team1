using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    /// <summary>
    /// Represents a student within the university system.
    /// </summary>
    public class Student : Identified
    {
        /// <summary>
        /// Gets or sets the first name of the student.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the student.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password for the student.
        /// </summary>
        [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the list of sections the student is registered in.
        /// </summary>
        /// <remarks>
        /// This represents the many-to-many relationship between students and sections.
        /// </remarks>
        public ICollection<Section> Sections { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        public Student()
        {
            FirstName = "";
            LastName = "";
            Password = "";
            Sections = new List<Section>();
        }
    }
}