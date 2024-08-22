using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models;

public class Identified
{
    [Key]
    public int ID { get; set; }
}