using GenericRepositoryPattern.Domain.Entities;
using GenericRepositoryPattern.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            _employeeService.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            _employeeService.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return NoContent();
        }



        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = _employeeService.GetById(id);
            return Ok(employee);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }
    }
}
