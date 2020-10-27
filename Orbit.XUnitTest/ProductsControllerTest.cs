using Orbit.Controllers;
using Orbit.Data.Entities;
using Orbit.Services.Core;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Orbit.XUnitTest
{
    public class studentsControllerTest
    {
        [Fact]
        public void GetStudents()
        {
            var mockService = new Mock<IEntityService<Student>>();
            mockService.Setup(s => s.GetAllAsync());
            var controller = new StudentController(mockService.Object);
            var result = controller.Get();
        }

        [Fact]
        public void Create_ReturnsViewResultWithModel()
        {
            var student = new Student
            {
                Id = 0,
                Username = "Test.Username",
                FirstName = "Test.FirstName",
                LastName = "Test.LastName",
                Age = 18,
                Career = "Test.Career"
            };

            var mockService = new Mock<IEntityService<Student>>();
            var controller = new StudentController(mockService.Object);
            var result = controller.Save(student);
        }

        [Theory(DisplayName = "Edit student item")]
        [InlineData("Keyboard")]
        public void Edit_ReturnsViewResultWithModel()
        {
            var student = new Student
            {
                Id = 5,
                Username = "Test.Username",
                FirstName = "Test.FirstName",
                LastName = "Test.LastName",
                Age = 18,
                Career = "Test.Career"
            };

            var mockService = new Mock<IEntityService<Student>>();
            mockService.Setup(s => s.GetByIdAsync(student.Id)).Returns(Task.FromResult(student));
            var controller = new StudentController(mockService.Object);
            var result = controller.Update(student);
        }

        [Fact]
        public void Delete_ReturnsNotFoundResult()
        {
            var student = new Student
            {
                Id = 5,
                Username = "Test.Username",
                FirstName = "Test.FirstName",
                LastName = "Test.LastName",
                Age = 18,
                Career = "Test.Career"
            };

            var mockService = new Mock<IEntityService<Student>>();
            var controller = new StudentController(mockService.Object);
            controller.Delete(student.Id);
        }
    }
}