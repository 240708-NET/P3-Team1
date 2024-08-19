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

        }
    }
}