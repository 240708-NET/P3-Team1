using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]
using System.ComponentModel.DataAnnotations.Schema; //For notation like [ForeignKey()]

namespace UniversityAPI.Models
{
    public class Section : Identified
    {
        [Required]
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [Required]
        [ForeignKey("Professor")]
        public int ProfessorID { get; set; }

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
            Day = "";
            Students = new List<Student>();
        }

        public Section(int courseID, Course course, int professorID, Professor professor, TimeOnly startTime, TimeOnly endTime, string day)
        {
            CourseID = courseID;
            ProfessorID = professorID;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
            Students = new List<Student>();
        }
    }
}
