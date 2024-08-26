using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    public class Student : Identified
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }


        [MaxLength(50)]
        public string Password { get; set; }

        //Navigation Property for Sections
        public ICollection<Section> Sections { get; set; }


        //Constructors
        public Student()
        {
            FirstName = "";
            LastName = "";
            Password = "";
            Sections = new List<Section>();
        }


        public Student(string firstName, string lastName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Sections = new List<Section>();
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Student))
            {
                return false;
            }
            return ((Student)obj).ID == ID &&
                   ((Student)obj).FirstName == FirstName &&
                   ((Student)obj).LastName == LastName &&
                   ((Student)obj).Password == Password;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
