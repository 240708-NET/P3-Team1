namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class CourseController : Controller<Course>
{
    public CourseController(ICourseServices courseService) : base(courseService) { }
}
