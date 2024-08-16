using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    public class Student
    {
        //Attributes
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        //Constructor
        public Student()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Student))
            {
                return false;
            }
            return ((Student)obj).ID == ID &&
                   ((Student)obj).FirstName == FirstName &&
                   ((Student)obj).LastName == LastName;
        }
    }
}