using Microsoft.EntityFrameworkCore;        //For DbContextOptions, InMemoryDbContextOptionsBuilder
using UniversityAPI.Models;                 //For models
using Xunit;                                //For [Fact], Assert, etc.

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

        //Method to create a new UniversityContext object
        private UniversityContext CreateContext()
        {
            return new UniversityContext(_contextOptions);
        }

        [Fact]
        public async Task GetAll_ReturnsAllStudents()
        {
            //ARRANGE
            //Creating 2 students, then adding to context
            using var context = CreateContext();
            context.Students.AddRange(
                new Student { FirstName = "Joshua", LastName = "Susana" },
                new Student { FirstName = "Nick", LastName = "Wang" }
            );
            await context.SaveChangesAsync();
            var repository = new StudentRepository(context);

            //ACT
            //Calling GetAll() method
            var students = await repository.GetAll();

            //ASSERT
            //Verifying there are 2 students
            Assert.Equal(2, students.Count());
        }

        [Fact]
        public async Task GetById_ReturnsCorrectStudent()
        {
            //ARRANGE
            //Creating 1 student, then adding to context
            using var context = CreateContext();
            context.Students.Add(new Student { ID = 1, FirstName = "Edward", LastName = "Turner" });
            await context.SaveChangesAsync();
            var repository = new StudentRepository(context);

            //ACT
            //Calling GetById(int id) method
            var student = await repository.GetById(1);

            //ASSERT
            //Verifying that student returned is not null, and that it equals the student we created
            Assert.NotNull(student);
            Assert.Equal("Edward", student.FirstName);
        }

        [Fact]
        public async Task Insert_AddsStudent()
        {
            //ARRANGE
            using var context = CreateContext();
            var repository = new StudentRepository(context);
            var student = new Student { FirstName = "Daniel", LastName = "Bellonzi" };

            //ACT
            //Calling Insert(TEntity entity) method
            await repository.Insert(student);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that there is only 1 student, and it is the student we created
            var students = await context.Students.ToListAsync();
            Assert.Single(students);
            Assert.Equal("Daniel", students[0].FirstName);
        }

        [Fact]
        public async Task Update_UpdatesStudent()
        {
            //ARRANGE
            //Creating student then adding to context
            using var context = CreateContext();
            var student = new Student { ID = 1, FirstName = "Ibrahim", LastName = "Houissa" };
            context.Students.Add(student);
            await context.SaveChangesAsync();
            var repository = new StudentRepository(context);

            //ACT
            //Getting student by id, detaching it, changing first name, calling Update(TEntity entity) method, then saving changes
            context.Entry(student).State = EntityState.Detached;
            student.FirstName = "Updated";
            await repository.Update(student);
            await context.SaveChangesAsync();

            //ASSERT
            //Making sure student we created and updated exists as we expect
            var updatedStudent = await context.Students.FindAsync(1);
            Assert.NotNull(updatedStudent);
            Assert.Equal("Updated", updatedStudent.FirstName);
        }

        [Fact]
        public async Task Delete_RemovesStudent()
        {
            //ARRANGE
            //Creating a student then adding to context
            using var context = CreateContext();
            context.Students.Add(new Student { ID = 1, FirstName = "Jae", LastName = "Wong" });
            await context.SaveChangesAsync();
            var repository = new StudentRepository(context);

            //ACT
            //Calling DeleteById(int id) and saving changes
            await repository.DeleteById(1);
            await context.SaveChangesAsync();

            //ASSERT
            //Checking if context is empty as we expect
            var students = await context.Students.ToListAsync();
            Assert.Empty(students);
        }

        [Fact]
        public async Task GetStudentsByLastName_ReturnsCorrectStudents()
        {
            //ARRANGE
            //Creating students then adding to context
            using var context = CreateContext();
            context.Students.AddRange(
                new Student { FirstName = "Harold", LastName = "Ponce" },
                new Student { FirstName = "Robert", LastName = "Considine" }
            );
            await context.SaveChangesAsync();
            var repository = new StudentRepository(context);

            //ACT
            //Calling GetStudentsByLastName(string lastName) method
            var students = await repository.GetStudentsByLastName("Ponce");

            //ASSERT
            //Verifying that only one student with the last name "Doe" is returned
            Assert.Single(students);
            Assert.Equal("Harold", students[0].FirstName);
        }

        [Fact]
        public async Task GetRegisteredSections_ReturnsCorrectSections()
        {
            //ARRANGE
            //Creating student and sections then adding to context
            using var context = CreateContext();
            var student = new Student { ID = 1, FirstName = "Brad", LastName = "Pitt" };
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Richard", LastName = "Hawkins" };

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
                StartTime = new TimeOnly(10, 0), 
                EndTime = new TimeOnly(11, 0), 
                Day = "Tues" 
            };

            student.Sections.Add(section1);
            student.Sections.Add(section2);
            context.Students.Add(student);
            await context.SaveChangesAsync();
            var repository = new StudentRepository(context);

            //ACT
            //Calling GetRegisteredSections(int id) method
            var sections = await repository.GetRegisteredSections(1);

            //ASSERT
            //Verifying that the student is registered in two sections
            Assert.NotNull(sections);
            Assert.Equal(2, sections.Count);
        }

        [Fact]
        public async Task AddSectionToStudent_AddsSectionSuccessfully()
        {
            //ARRANGE
            //Creating student and section then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Kelly", LastName = "Littig" };

            var student = new Student { ID = 1, FirstName = "Bon", LastName = "Jovi" };
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
            
            context.Students.Add(student);
            context.Sections.Add(section);
            await context.SaveChangesAsync();
            var repository = new StudentRepository(context);

            //ACT
            //Calling AddSectionToStudent(int studentId, int sectionId) method
            var updatedStudent = await repository.AddSectionToStudent(1, 1);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that the section was added to the student
            Assert.NotNull(updatedStudent);
            Assert.Single(updatedStudent.Sections);
            Assert.Equal("Mon", updatedStudent.Sections.First().Day);
        }

        [Fact]
        public async Task DeleteSectionFromStudent_RemovesSectionSuccessfully()
        {
            //ARRANGE
            //Creating student and sections then adding to context
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1" };
            var professor = new Professor { ID = 1, FirstName = "Dan", LastName = "Sites" };

            var student = new Student { ID = 1, FirstName = "Patrick", LastName = "Eastridge" };
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
            
            student.Sections.Add(section);
            context.Students.Add(student);
            await context.SaveChangesAsync();
            var repository = new StudentRepository(context);

            //ACT
            //Calling DeleteSectionFromStudent(int studentId, int sectionId) method
            var updatedStudent = await repository.DeleteSectionFromStudent(1, 1);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that the section was removed from the student
            Assert.NotNull(updatedStudent);
            Assert.Empty(updatedStudent.Sections);
        }

        [Fact]
        public async Task DeleteAll_RemovesAllStudents()
        {
            //ARRANGE
            //Creating students with unique IDs and adding to context
            using var context = CreateContext();
            context.Students.AddRange(
                new Student { ID = 1, FirstName = "Peter", LastName = "Parker" },
                new Student { ID = 2, FirstName = "Mary", LastName = "Jane" }
            );
            await context.SaveChangesAsync();

            //Detaching entities to avoid tracking conflicts
            foreach (var entity in context.ChangeTracker.Entries().ToList())
            {
                entity.State = EntityState.Detached;
            }
            var repository = new StudentRepository(context);

            //ACT
            //Calling DeleteAll() method
            await repository.DeleteAll();
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that all students have been removed from the context
            var students = await context.Students.ToListAsync();
            Assert.Empty(students);
        }
    }
}