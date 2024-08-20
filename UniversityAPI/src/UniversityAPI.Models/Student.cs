using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    public class Student : IIdentified
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


        [MaxLength(50)]
        public string Password { get; set; }


        //Constructor
        public Student()
        {
            FirstName = "";
            LastName = "";
            Password = "";
        }


        public Student(string firstName, string lastName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
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
