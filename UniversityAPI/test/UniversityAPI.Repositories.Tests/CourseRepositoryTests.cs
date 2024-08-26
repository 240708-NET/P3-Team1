using Microsoft.EntityFrameworkCore;        //For DbContextOptions, InMemoryDbContextOptionsBuilder
using UniversityAPI.Models;                 //For models
using Xunit;                                //For [Fact], Assert, etc.

namespace UniversityAPI.Repositories.Tests
{
    public class CourseRepositoryTests
    {
        //Field to hold configuration options
        private readonly DbContextOptions<UniversityContext> _contextOptions;

        public CourseRepositoryTests()
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
        public async Task GetAll_ReturnsAllCourses()
        {
            //ARRANGE
            //Creating 2 courses and adding them to the context
            using var context = CreateContext();
            context.Courses.AddRange(
                new Course { Name = "Course1", Category = "Category1" },
                new Course { Name = "Course2", Category = "Category2" }
            );
            await context.SaveChangesAsync();
            var repository = new CourseRepository(context);

            //ACT
            //Calling GetAll() method
            var courses = await repository.GetAll();

            //ASSERT
            //Verifying there are 2 courses
            Assert.Equal(2, courses.Count);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectCourse()
        {
            //ARRANGE
            //Creating a course and adding it to the context
            using var context = CreateContext();
            context.Courses.Add(new Course { ID = 1, Name = "Course1", Category = "Category1" });
            await context.SaveChangesAsync();
            var repository = new CourseRepository(context);

            //ACT
            //Calling GetById(int id) method
            var course = await repository.GetById(1);

            //ASSERT
            //Verifying that the course returned is not null and matches the created course
            Assert.NotNull(course);
            Assert.Equal("Course1", course.Name);
        }

        [Fact]
        public async Task Insert_AddsCourse()
        {
            //ARRANGE
            using var context = CreateContext();
            var repository = new CourseRepository(context);
            var course = new Course { Name = "NewCourse", Category = "NewCategory" };

            //ACT
            //Calling Insert(TEntity entity)
            await repository.Insert(course);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that there is only 1 course in the context and it matches the inserted course
            var courses = await context.Courses.ToListAsync();
            Assert.Single(courses);
            Assert.Equal("NewCourse", courses[0].Name);
        }

        [Fact]
        public async Task Update_UpdatesCourse()
        {
            //ARRANGE
            //Creating a course, adding it to the context, and then detaching it to simulate a real update scenario
            using var context = CreateContext();
            var course = new Course { ID = 1, Name = "Course1", Category = "Category1" };
            context.Courses.Add(course);
            await context.SaveChangesAsync();
            var repository = new CourseRepository(context);

            //ACT
            //Detaching the entity, modifying it, calling Update(TEntity entity), then saving changes
            context.Entry(course).State = EntityState.Detached;
            course.Name = "UpdatedCourse";
            await repository.Update(course);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that the course was updated in the context
            var updatedCourse = await context.Courses.FindAsync(1);
            Assert.NotNull(updatedCourse);
            Assert.Equal("UpdatedCourse", updatedCourse.Name);
        }

        [Fact]
        public async Task Delete_RemovesCourse()
        {
            //ARRANGE
            //Creating a course and adding it to the context
            using var context = CreateContext();
            context.Courses.Add(new Course { ID = 1, Name = "Course1", Category = "Category1" });
            await context.SaveChangesAsync();
            var repository = new CourseRepository(context);

            //ACT
            //Deleting the course by ID using the repository
            await repository.DeleteById(1);
            await context.SaveChangesAsync();

            //ASSERT
            //Verifying that the context is empty after deletion
            var courses = await context.Courses.ToListAsync();
            Assert.Empty(courses);
        }

        [Fact]
        public async Task GetCoursesByCategory_ReturnsCorrectCourses()
        {
            //ARRANGE
            //Creating 2 courses in different categories and adding them to the context
            using var context = CreateContext();
            context.Courses.AddRange(
                new Course { Name = "Course1", Category = "Category1" },
                new Course { Name = "Course2", Category = "Category2" }
            );
            await context.SaveChangesAsync();
            var repository = new CourseRepository(context);

            //ACT
            //Calling GetCoursesByCategory(string category)
            var courses = await repository.GetCoursesByCategory("Category1");

            //ASSERT
            //Verifying that only the course in the specified category is returned
            Assert.Single(courses);
            Assert.Equal("Course1", courses[0].Name);
        }
    }
}