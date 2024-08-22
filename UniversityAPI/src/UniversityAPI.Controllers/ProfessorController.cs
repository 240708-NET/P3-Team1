namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : Controller<Professor>
{
    public ProfessorController(IProfessorServices professorService) : base(professorService) { }

}
