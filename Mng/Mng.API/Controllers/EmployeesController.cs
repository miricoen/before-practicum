using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mng.Core.DTO;
using Mng.Core.Entities;
using Mng.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeOutputDTO>> Get()
        {
            var list = await _employeeService.GetList();
            var lDTO = _mapper.Map<IEnumerable<EmployeeOutputDTO>>(list);
            return lDTO;
        }


        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeOutputDTO>> Get(int id)
        {
            Employee emp = await _employeeService.GetById(id);
            if (emp == null)
            {
                return NotFound("Employee not found");
            }
            EmployeeOutputDTO empDTO = _mapper.Map<EmployeeOutputDTO>(emp);
            return empDTO;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeInputDTO emp)
        {
            Employee empToAdd = _mapper.Map<Employee>(emp);
            await _employeeService.Add(empToAdd);

            return Ok("Employee added successfully");
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeInputDTO employeeDTO)
        {
            var existingEmployee = await _employeeService.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            }

            _mapper.Map(employeeDTO, existingEmployee);

            var updated = await _employeeService.Update(existingEmployee);
            if (!updated)
            {
                return StatusCode(500, "Failed to update employee");
            }
            return Ok("Employee updated successfully");
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _employeeService.Delete(id);
            if (!deleted)
            {
                return NotFound("Employee not found");
            }
            return Ok("Employee deleted successfully");
        }
    }
}
