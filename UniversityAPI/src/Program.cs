using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;
using UniversityAPI.Services;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Adding connection string
        builder.Services.AddDbContext<UniversityContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("AzureCloud")));

        builder.Services.AddScoped<IProfessorServices, ProfessorService>();
        builder.Services.AddScoped<ISectionServices, SectionService>();
        builder.Services.AddScoped<ICourseServices, CourseService>();
        builder.Services.AddScoped<IStudentServices, StudentService>();
        builder.Services.AddControllers();
        //You can add other services like Authentication, Swagger, etc., here

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}