using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    public class Professor : IIdentified
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

        //Constructors
        public Professor()
        {
            FirstName = "";
            LastName = "";
        }

        public Professor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
