using Microsoft.AspNetCore.Mvc;
using Mng.Core.DTO;
using Mng.Core.Entities;
using Mng.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesForEmployeeController : ControllerBase
    {

        private readonly IRolesForEmployeeService _rolesForEmployeeService;

        public RolesForEmployeeController(IRolesForEmployeeService rolesForEmployeeService)
        {
            _rolesForEmployeeService = rolesForEmployeeService;
        }


        // GET: api/<RolesForUser>
        [HttpGet]
        public IEnumerable<RoleForEmployeeDTO> Get()
        {
            return _rolesForEmployeeService.GetList();
                //new string[] { "value1", "value2" };
        }

        // GET api/<RolesForEmployee>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RolesForEmployee>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RolesForEmployee>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolesForEmployee>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
