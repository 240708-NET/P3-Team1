using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]
using System.ComponentModel.DataAnnotations.Schema; //For notation like [ForeignKey()]

namespace UniversityAPI.Models
{
    /// <summary>
    /// Represents a section of a course within the university system.
    /// </summary>
    public class Section : Identified
    {
        /// <summary>
        /// Gets or sets the ID of the course associated with this section.
        /// </summary>
        [Required]
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        
        /// <summary>
        /// Gets or sets the course associated with this section.
        /// </summary>
        public Course Course { get; set; }

        /// <summary>
        /// Gets or sets the ID of the professor assigned to teach this section.
        /// </summary>
        [Required]
        [ForeignKey("Professor")]
        public int ProfessorID { get; set; }

        /// <summary>
        /// Gets or sets the professor assigned to teach this section.
        /// </summary>
        public Professor Professor { get; set; }

        /// <summary>
        /// Gets or sets the start time of the section.
        /// </summary>
        [Required]
        public TimeOnly StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the section.
        /// </summary>
        [Required]
        public TimeOnly EndTime { get; set; }

        /// <summary>
        /// Gets or sets the day of the week when the section is held.
        /// </summary>
        [Required]
        [MaxLength(5)]
        public string Day { get; set; }

        /// <summary>
        /// Gets or sets the list of students registered in this section.
        /// </summary>
        /// <remarks>
        /// This represents the many-to-many relationship between sections and students.
        /// </remarks>
        public ICollection<Student> Students { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Section"/> class.
        /// </summary>
        public Section()
        {
            Course = new Course();
            Professor = new Professor();
            Day = "";
            Students = new List<Student>();
        }

        /// <summary>
        /// Determines whether the current section overlaps with another section.
        /// </summary>
        /// <param name="section">The section to compare with.</param>
        /// <returns><c>true</c> if the sections overlap; otherwise, <c>false</c>.</returns>
        public bool Overlaps(Section section)
        {
            return Day == section.Day && 
                   (StartTime.IsBetween(section.StartTime, section.EndTime) || 
                    section.StartTime.IsBetween(StartTime, EndTime));
        }
    }
}