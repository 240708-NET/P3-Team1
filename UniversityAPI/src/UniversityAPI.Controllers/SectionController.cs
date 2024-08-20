namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class SectionController : Controller<Section>
{
    public SectionController(ISectionServices studentServices) : base(studentServices) { }

}
