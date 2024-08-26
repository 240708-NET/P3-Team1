using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]
using System.ComponentModel.DataAnnotations.Schema; //For notation like [ForeignKey()]

namespace UniversityAPI.Models
{
    public class Section : Identified
    {
        [Required]
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        //Navigation property
        public Course Course { get; set; }

        [Required]
        [ForeignKey("Professor")]
        public int ProfessorID { get; set; }
        //Navigation property
        public Professor Professor { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        [MaxLength(5)]
        public string Day { get; set; }

        //Navigation Property for Students
        public ICollection<Student> Students { get; set; }

        //Constructor
        public Section()
        {
            Course = new Course();
            Professor = new Professor();
            Day = "";
            Students = new List<Student>();
        }
    }
}
