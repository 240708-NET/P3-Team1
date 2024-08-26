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
        public ICollection<Section> Sections { get; set; } = new List<Section>();


        //Constructors
        public Student()
        {
            FirstName = "";
            LastName = "";
            Password = "";
            Sections = new List<Section>();
        }
    }
}
