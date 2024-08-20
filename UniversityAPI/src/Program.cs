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