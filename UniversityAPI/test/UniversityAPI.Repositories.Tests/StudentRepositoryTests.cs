using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniversityAPI.Models;
using UniversityAPI.Repositories;
using Xunit;

namespace UniversityAPI.Repositories.Tests
{
    public class StudentRepositoryTests
    {
        //Field to hold configuration options
        private readonly DbContextOptions<UniversityContext> _contextOptions;

        public StudentRepositoryTests()
        {
            //For options, use in-memory DB, and ensure a new DB for each test
            _contextOptions = new DbContextOptionsBuilder<UniversityContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        private UniversityContext CreateContext()
        {
            return new UniversityContext(_contextOptions);
        }

        [Fact]
        public async Task Update_UpdatesStudent()
        {
            //ARRANGE
            using var context = CreateContext();
            var student = new Student 
            { 
                ID = 1, 
                FirstName = "Josh", 
                LastName = "Sus", 
                Password = "password123"
            };
            context.Students.Add(student);
            await context.SaveChangesAsync();

            var repository = new StudentRepository(context);

            //ACT
            //Detaching the original entity to simulate an independent update operation
            context.Entry(student).State = EntityState.Detached;
            student.LastName = "Susana";
            var updatedStudent = await repository.Update(student);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that the student was updated correctly
            var resultStudent = await context.Students.FindAsync(1);
            Assert.NotNull(resultStudent);
            Assert.Equal("Susana", resultStudent.LastName);
        }
    }
}