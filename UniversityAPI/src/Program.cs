<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;
=======
using UniversityAPI.Models;
using UniversityAPI.Services;
>>>>>>> cd30c7e2a1b2a151c68e3a8a65ad4f84f8d91761

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Adding connection string
        builder.Services.AddDbContext<UniversityContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("AzureCloud")));

<<<<<<< HEAD
=======
        builder.Services.AddScoped<IStudentServices, FakeStudentSertices>();
        builder.Services.AddScoped<IProfessorServices, ProfessorService>();
        builder.Services.AddScoped<ISectionServices, SectionService>();
        builder.Services.AddScoped<ICourseServices, CourseService>();
>>>>>>> cd30c7e2a1b2a151c68e3a8a65ad4f84f8d91761
        builder.Services.AddControllers();
        //You can add other services like Authentication, Swagger, etc., here

        var app = builder.Build();

        //Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}