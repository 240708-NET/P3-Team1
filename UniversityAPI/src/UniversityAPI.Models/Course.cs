using System.ComponentModel.DataAnnotations;        //For notation like [Key] and [Required]

namespace UniversityAPI.Models
{
    public class Course : Identified
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        //Constructors
        public Course()
        {
            Name = "";
            Description = "";
            Category = "";
        }

        public Course(string name, string description, string category)
        {
            Name = name;
            Description = description;
            Category = category;
        }
    }
}
