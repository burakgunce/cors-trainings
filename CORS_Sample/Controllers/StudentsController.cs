using CORS_Sample.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORS_Sample.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("SubDomainClient")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //[DisableCors]
        //public int GetNumber()
        //{
        //    return 6;
        //}

        List<Student> studentList = new List<Student>
        {
            new Student() {StudentNumber = "10001", FirstName = "aaa", LastName = "bbb", Address = "London", Phone = "111"},
            new Student() {StudentNumber = "10002", FirstName = "ddd", LastName = "eee", Address = "NY", Phone = "222"},
            new Student() {StudentNumber = "10003", FirstName = "fff", LastName = "ggg", Address = "Seul", Phone = "333"},
            new Student() {StudentNumber = "10004", FirstName = "hhh", LastName = "jjj", Address = "İst", Phone = "444"},
        };

        [HttpGet]
        [Route("GetAllStudents")]
        public IEnumerable<Student> GetAllStudents()
        {
            return studentList;
        }

        [HttpPost]
        [Route("GetStudentById")]
        public IActionResult GetStudent(QueryParams query)
        {
            Student student = studentList.FirstOrDefault(x => x.StudentNumber == query.StudentNumber);

            if (student == null)
            {
                return NotFound();
            }

            return Ok();
        }


    }
}
