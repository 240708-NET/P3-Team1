using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    public class Course
    {
        //Attributes
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        //Constructor
        public Course()
        {

        }
    }
}