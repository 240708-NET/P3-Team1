using Microsoft.EntityFrameworkCore;        //For DbContextOptions, InMemoryDbContextOptionsBuilder
using UniversityAPI.Models;                 //For models
using Xunit;                                //For [Fact], Assert, etc.

namespace UniversityAPI.Repositories.Tests
{
    public class ProfessorRepositoryTests
    {
        //Field to hold configuration options
        private readonly DbContextOptions<UniversityContext> _contextOptions;

        public ProfessorRepositoryTests()
        {
            //For options, use in-memory DB, and ensure a new DB for each test
            _contextOptions = new DbContextOptionsBuilder<UniversityContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        //Method to create a new UniversityContext object
        private UniversityContext CreateContext()
        {
            return new UniversityContext(_contextOptions);
        }

        [Fact]
        public async Task GetAll_ReturnsAllProfessors()
        {
            //ARRANGE
            //Creating 2 professors, then adding to context
            using var context = CreateContext();
            context.Professors.AddRange(
                new Professor { FirstName = "Brian", LastName = "Bartley" },
                new Professor { FirstName = "Jon", LastName = "Bradley" }
            );
            await context.SaveChangesAsync();
            var repository = new ProfessorRepository(context);

            //ACT
            //Calling GetAll() method
            var professors = await repository.GetAll();

            //ASSERT
            //Verifying there are 2 professors
            Assert.Equal(2, professors.Count);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectProfessor()
        {
            //ARRANGE
            //Creating 1 professor, then adding to context
            using var context = CreateContext();
            context.Professors.Add(new Professor { ID = 1, FirstName = "Luke", LastName = "Gillespie" });
            await context.SaveChangesAsync();
            var repository = new ProfessorRepository(context);

            //ACT
            //Calling GetById(int id) method
            var professor = await repository.GetById(1);

            //ASSERT
            //Verifying that professor returned is not null, and that it equals the professor we created
            Assert.NotNull(professor);
            Assert.Equal("Luke", professor.FirstName);
        }

        [Fact]
        public async Task Insert_AddsProfessor()
        {
            //ARRANGE
            using var context = CreateContext();
            var repository = new ProfessorRepository(context);
            var professor = new Professor { FirstName = "Wale", LastName = "Wahab" };

            //ACT
            //Calling Insert(TEntity entity)
            await repository.Insert(professor);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that there is only 1 professor, and it is the professor we created
            var professors = await context.Professors.ToListAsync();
            Assert.Single(professors);
            Assert.Equal("Wale", professors[0].FirstName);
        }

        [Fact]
        public async Task Update_UpdatesProfessor()
        {
            //ARRANGE
            //Creating professor then adding to context
            using var context = CreateContext();
            var professor = new Professor { ID = 1, FirstName = "Seun", LastName = "Guiganfode" };
            context.Professors.Add(professor);
            await context.SaveChangesAsync();

            var repository = new ProfessorRepository(context);

            //ACT
            //Getting professor by id, detaching it, changing FirstName, calling Update(TEntity entity), then saving changes
            context.Entry(professor).State = EntityState.Detached;
            professor.FirstName = "Updated";
            await repository.Update(professor);
            await context.SaveChangesAsync();

            //ASSERT
            //Making sure professor we created and updated exists as we expect
            var updatedProfessor = await context.Professors.FindAsync(1);
            Assert.NotNull(updatedProfessor);
            Assert.Equal("Updated", updatedProfessor.FirstName);
        }

        [Fact]
        public async Task Delete_RemovesProfessor()
        {
            //ARRANGE
            //Creating a professor then adding to context
            using var context = CreateContext();
            context.Professors.Add(new Professor { ID = 1, FirstName = "Jian", LastName = "Tan" });
            await context.SaveChangesAsync();
            var repository = new ProfessorRepository(context);

            //ACT
            //Calling DeleteById(object id) and saving changes
            await repository.DeleteById(1);
            await context.SaveChangesAsync();

            //ASSERT
            //Checking if context is empty as we expect
            var professors = await context.Professors.ToListAsync();
            Assert.Empty(professors);
        }

        [Fact]
        public async Task GetProfessorsByLastName_ReturnsCorrectProfessors()
        {
            //ARRANGE
            //Creating 2 professors with different last names, then adding to context
            using var context = CreateContext();
            context.Professors.AddRange(
                new Professor { FirstName = "Sixing", LastName = "Zheng" },
                new Professor { FirstName = "Patrick", LastName = "Engel" }
            );
            await context.SaveChangesAsync();
            var repository = new ProfessorRepository(context);

            //ACT
            //Calling GetProfessorsByLastName(string lastName) method
            var professors = await repository.GetProfessorsByLastName("Zheng");

            //ASSERT
            //Verifying that only the professor with the specified last name is returned
            Assert.Single(professors);
            Assert.Equal("Sixing", professors[0].FirstName);
        }

        [Fact]
        public async Task GetSectionsByProfessorID_ReturnsCorrectSections()
        {
            //ARRANGE
            //Creating a professor and sections, then adding to context
            using var context = CreateContext();
            var professor = new Professor { ID = 1, FirstName = "Enos", LastName = "Washington" };

            //Adding professor to the context
            context.Professors.Add(professor);
            await context.SaveChangesAsync();

            var course1 = new Course { ID = 1, Name = "Course1" };

            var section1 = new Section 
            { 
                ID = 1, 
                CourseID = 1, 
                Course = course1, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Mon" 
            };

            var section2 = new Section 
            { 
                ID = 2, 
                CourseID = 1, 
                Course = course1, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(11, 0), 
                EndTime = new TimeOnly(12, 0), 
                Day = "Tue" 
            };

            //Adding sections to context
            context.Sections.Add(section1);
            context.Sections.Add(section2);
            await context.SaveChangesAsync();

            var repository = new ProfessorRepository(context);

            //ACT
            //Calling GetSectionsByProfessorID(int professorID) method
            var sections = await repository.GetSectionsByProfessorID(1);

            //ASSERT
            //Verifying that there are 2 sections and they belong to the professor
            Assert.Equal(2, sections.Count);
            Assert.All(sections, section => Assert.Equal(1, section.ProfessorID));
        }
    }
}