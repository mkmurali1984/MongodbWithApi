using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongodbWithApi.Model;
using MongodbWithApi.Services;

namespace MongodbWithApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentServices studentServices;
        public StudentController(StudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        [HttpGet]
        public List<Students> GetStudent()
        {
            return studentServices.GetAllStudents();
        }

        [HttpPost]
        public void AddStudent(Students students)
        {
            studentServices.AddStudentDetails(students);
        }

        [HttpDelete]
        public void DeleteStudent(string id)
        {
            studentServices.DeleteStudent(id);
        }

        [HttpPut]
        public void UpdateStudent(string id, Students students)
        {
            var isStudentFound = studentServices.GetStudentById(id);

            if (isStudentFound != null)
            {
                students.Id = isStudentFound.Id;
                studentServices.UpdateStudent(id, students);
            }
        }
    }
}
