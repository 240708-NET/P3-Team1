using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]
using System.ComponentModel.DataAnnotations.Schema; //For notation like [ForeignKey()]

namespace UniversityAPI.Models
{
    public class Section
    {
        //Attributes
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        //Navigation property with lazy loading
        public virtual Course Course { get; set; }

        [Required]
        [ForeignKey("Professor")]
        public int ProfessorID { get; set; }
        //Navigation property with lazy loading
        public virtual Professor Professor { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        [MaxLength(5)] 
        public string Day { get; set; }

        //Constructor
        public Section()
        {

        }
    }
}