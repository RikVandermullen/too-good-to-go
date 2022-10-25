using Microsoft.AspNetCore.Mvc;
using DomainServices;
using Domain;

namespace TGTG_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return Ok(_studentRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            return Ok(_studentRepository.GetStudentById(id));
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            return _studentRepository.AddStudent(student);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            _studentRepository.DeleteStudent(student);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public ActionResult<Student> Update(int id, [FromBody] Student student)
        {
            var Student = _studentRepository.GetStudentById(id);

            if (Student == null || id != student.Id)
            {
                return BadRequest();
            }

            return _studentRepository.UpdateStudent(student);
        }
        
    }
}
