using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    /// <summary>
    /// Represents a professor within the university system.
    /// </summary>
    public class Professor : Identified
    {
        /// <summary>
        /// Gets or sets the first name of the professor.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the professor.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password for the professor.
        /// </summary>
        [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Professor"/> class.
        /// </summary>
        public Professor()
        {
            FirstName = "";
            LastName = "";
            Password = "";
        }
    }
}