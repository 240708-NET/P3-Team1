using Microsoft.EntityFrameworkCore;        //For DbContextOptions, InMemoryDbContextOptionsBuilder
using UniversityAPI.Models;                 //For models
using Xunit;                                //For [Fact], Assert, etc.

namespace UniversityAPI.Repositories.Tests
{
    public class SectionRepositoryTests
    {
        //Field to hold configuration options
        private readonly DbContextOptions<UniversityContext> _contextOptions;

        public SectionRepositoryTests()
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
        public async Task GetAll_ReturnsAllSections()
        {
            //ARRANGE
            //Creating 2 sections, then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Antonio", LastName = "Dominguez" };

            var section1 = new Section 
            { 
                ID = 1, 
                CourseID = 1, 
                Course = course, 
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
                Course = course, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(11, 0), 
                EndTime = new TimeOnly(12, 0), 
                Day = "Tue" 
            };

            context.Sections.AddRange(section1, section2);
            await context.SaveChangesAsync();
            var repository = new SectionRepository(context);

            //ACT
            //Calling GetAll() method
            var sections = await repository.GetAll();

            //ASSERT
            //Verifying there are 2 sections
            Assert.Equal(2, sections.Count());
        }

        [Fact]
        public async Task GetById_ReturnsCorrectSection()
        {
            //ARRANGE
            //Creating 1 section, then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Jesse", LastName = "White" };

            var section = new Section 
            { 
                ID = 1, 
                CourseID = 1, 
                Course = course, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Fri" 
            };

            context.Sections.Add(section);
            await context.SaveChangesAsync();
            var repository = new SectionRepository(context);

            //ACT
            //Calling GetById(int id) method
            var result = await repository.GetById(1);

            //ASSERT
            //Verifying that section returned is not null, and that it equals the section we created
            Assert.NotNull(result);
            Assert.Equal("Fri", result.Day);
        }

        [Fact]
        public async Task Insert_AddsSection()
        {
            //ARRANGE
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Daniel", LastName = "Hara" };

            var repository = new SectionRepository(context);
            var section = new Section 
            { 
                CourseID = 1, 
                Course = course, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Wed" 
            };

            //ACT
            //Calling Insert(TEntity entity) method
            await repository.Insert(section);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that there is only 1 section, and it is the section we created
            var sections = await context.Sections.ToListAsync();
            Assert.Single(sections);
            Assert.Equal("Wed", sections[0].Day);
        }

        [Fact]
        public async Task Update_UpdatesSection()
        {
            //ARRANGE
            //Creating section then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Anton", LastName = "Moskalenko" };

            var section = new Section 
            { 
                ID = 1, 
                CourseID = 1, 
                Course = course, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Thu" 
            };

            context.Sections.Add(section);
            await context.SaveChangesAsync();
            var repository = new SectionRepository(context);

            //ACT
            //Getting section by id, detaching it, changing day, calling Update(TEntity entity) method, then saving changes
            context.Entry(section).State = EntityState.Detached;
            section.Day = "Mon";
            await repository.Update(section);
            await context.SaveChangesAsync();

            //ASSERT
            //Making sure section we created and updated exists as we expect
            var updatedSection = await context.Sections.FindAsync(1);
            Assert.NotNull(updatedSection);
            Assert.Equal("Mon", updatedSection.Day);
        }

        [Fact]
        public async Task Delete_RemovesSection()
        {
            //ARRANGE
            //Creating a section then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Ben", LastName = "Savage" };

            var section = new Section 
            { 
                ID = 1, 
                CourseID = 1, 
                Course = course, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Mon" 
            };

            context.Sections.Add(section);
            await context.SaveChangesAsync();
            var repository = new SectionRepository(context);

            //ACT
            //Calling DeleteById(int id) and saving changes
            await repository.DeleteById(1);
            await context.SaveChangesAsync();

            //ASSERT
            //Checking if context is empty as we expect
            var sections = await context.Sections.ToListAsync();
            Assert.Empty(sections);
        }

        [Fact]
        public async Task GetSectionsByCourseID_ReturnsCorrectSections()
        {
            //ARRANGE
            //Creating 2 sections with same CourseID then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Carson", LastName = "Panduku" };

            context.Courses.Add(course);
            await context.SaveChangesAsync();

            var section1 = new Section 
            { 
                ID = 1,
                CourseID = course.ID, 
                Course = course, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Tue" 
            };

            var section2 = new Section 
            { 
                ID = 2,
                CourseID = course.ID, 
                Course = course, 
                ProfessorID = 1, 
                Professor = professor, 
                StartTime = new TimeOnly(11, 0), 
                EndTime = new TimeOnly(12, 0), 
                Day = "Thu" 
            };
            context.Sections.AddRange(section1, section2);
            await context.SaveChangesAsync();

            var repository = new SectionRepository(context);

            //ACT
            //Calling GetSectionsByCourseID(int courseID)
            var sections = await repository.GetSectionsByCourseID(course.ID);

            //ASSERT
            //Checking we have 2 sections and they are the sections we just created
            Assert.NotNull(sections);
            Assert.Equal(2, sections.Count); 
            Assert.Contains(sections, s => s.Day == "Tue"); 
            Assert.Contains(sections, s => s.Day == "Thu"); 
        }

        [Fact]
        public async Task GetRegisteredStudents_ReturnsCorrectStudents()
        {
            //ARRANGE
            //Creating section and students then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Tim", LastName = "Gillespie" };

            var section = new Section 
            { 
                ID = 1, 
                CourseID = course.ID, 
                Course = course, 
                ProfessorID = professor.ID, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Mon" 
            };

            var student1 = new Student { ID = 1, FirstName = "Rohit", LastName = "Kalra" };
            var student2 = new Student { ID = 2, FirstName = "Pranam", LastName = "Acharya" };
            section.Students.Add(student1);
            section.Students.Add(student2);
            context.Sections.Add(section);
            await context.SaveChangesAsync();
            var repository = new SectionRepository(context);

            //ACT
            //Calling GetRegisteredStudents(int id) method
            var students = await repository.GetRegisteredStudents(1);

            //ASSERT
            //Verifying that the section has two registered students
            Assert.NotNull(students);
            Assert.Equal(2, students.Count);
        }

        [Fact]
        public async Task AddStudentToSection_AddsStudentSuccessfully()
        {
            //ARRANGE
            //Creating section and student then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Clark", LastName = "Kent" };

            var section = new Section 
            { 
                ID = 1, 
                CourseID = course.ID, 
                Course = course, 
                ProfessorID = professor.ID, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Mon" 
            };

            var student = new Student { ID = 1, FirstName = "Kelly", LastName = "Clarkson" };
            context.Sections.Add(section);
            context.Students.Add(student);
            await context.SaveChangesAsync();
            var repository = new SectionRepository(context);

            //ACT
            //Calling AddStudentToSection(int sectionId, int studentId) method
            var updatedSection = await repository.AddStudentToSection(1, 1);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that the student was added to the section
            Assert.NotNull(updatedSection);
            Assert.Single(updatedSection.Students);
            Assert.Equal("Kelly", updatedSection.Students.First().FirstName);
        }

        [Fact]
        public async Task DeleteStudentFromSection_RemovesStudentSuccessfully()
        {
            //ARRANGE
            //Creating section and student then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Gary", LastName = "Ng" };

            var section = new Section 
            { 
                ID = 1, 
                CourseID = course.ID, 
                Course = course, 
                ProfessorID = professor.ID, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Mon" 
            };

            var student = new Student { ID = 1, FirstName = "Jaymee", LastName = "Stout" };
            section.Students.Add(student);
            context.Sections.Add(section);
            await context.SaveChangesAsync();
            var repository = new SectionRepository(context);

            //ACT
            //Calling DeleteStudentFromSection(int sectionId, int studentId) method
            var updatedSection = await repository.DeleteStudentFromSection(1, 1);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that the student was removed from the section
            Assert.NotNull(updatedSection);
            Assert.Empty(updatedSection.Students);
        }

        [Fact]
        public async Task DeleteAll_RemovesAllSections()
        {
            //ARRANGE
            //Creating sections with unique IDs and adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Anish", LastName = "Shankar" };

            var section1 = new Section 
            { 
                ID = 1, 
                CourseID = course.ID, 
                Course = course, 
                ProfessorID = professor.ID, 
                Professor = professor, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(10, 0), 
                Day = "Mon" 
            };
            var section2 = new Section 
            { 
                ID = 2, 
                CourseID = course.ID, 
                Course = course, 
                ProfessorID = professor.ID, 
                Professor = professor, 
                StartTime = new TimeOnly(11, 0), 
                EndTime = new TimeOnly(12, 0), 
                Day = "Fri" 
            };

            context.Sections.AddRange(section1, section2);
            await context.SaveChangesAsync();

            //Detaching entities to avoid tracking conflicts
            foreach (var entity in context.ChangeTracker.Entries().ToList())
            {
                entity.State = EntityState.Detached;
            }
            var repository = new SectionRepository(context);

            //ACT
            //Calling DeleteAll() method
            await repository.DeleteAll();
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that all sections have been removed from the context
            var sections = await context.Sections.ToListAsync();
            Assert.Empty(sections);
        }
    }
}