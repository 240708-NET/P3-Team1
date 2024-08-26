using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;
using UniversityAPI.Repositories;
using UniversityAPI.Services;

namespace UniversityAPI;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.WebHost.UseUrls("http://[::]:80");

        //Adding connection string
        builder.Services.AddDbContext<UniversityContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("AzureCloud")));

        builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
        builder.Services.AddScoped<ISectionRepository, SectionRepository>();
        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();

        builder.Services.AddScoped<IProfessorServices, ProfessorService>();
        builder.Services.AddScoped<ISectionServices, SectionService>();
        builder.Services.AddScoped<ICourseServices, CourseService>();
        builder.Services.AddScoped<IStudentServices, StudentService>();
        builder.Services.AddControllers();
        //You can add other services like Authentication, Swagger, etc., here

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Handle CORS
        app.UseCors(options => options.AllowAnyHeader()
                    .SetIsOriginAllowed(hostName => true)
                    .AllowAnyMethod()
                    .AllowCredentials()
                    );

        // app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}