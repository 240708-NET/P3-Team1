using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models
{
    /// <summary>
    /// Serves as a base class for entities that have a unique identifier.
    /// </summary>
    public class Identified
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        [Key]
        public int ID { get; set; }
    }
}