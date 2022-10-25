using Domain;
using DomainServices;
using Microsoft.AspNetCore.Mvc;
using TGTG_WebAPI.Models;

namespace TGTG_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            return Ok(_employeeRepository.GetEmployeeById(id));
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee(NewEmployeeDTO employee)
        {
            var Employee = new Employee { Name = employee.Name, EmailAddress = employee.EmailAddress, EmployeeNumber = employee.EmployeeNumber, CanteenId = employee.CanteenId };
            return _employeeRepository.AddEmployee(Employee);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            _employeeRepository.DeleteEmployee(employee);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Update(int id, [FromBody] NewEmployeeDTO employee)
        {
            var Employee = _employeeRepository.GetEmployeeById(id);

            if (Employee == null || id != employee.Id)
            {
                return BadRequest();
            }

            var NewEmployee = new Employee { Id = employee.Id, Name = employee.Name, EmailAddress = employee.EmailAddress, EmployeeNumber = employee.EmployeeNumber, CanteenId = employee.CanteenId };

            return _employeeRepository.UpdateEmployee(NewEmployee);
        }
    }
}
