using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mng.Core.DTO;
using Mng.Core.Services;
using Mng.Services;
using System.ComponentModel.Design;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesOfRolesController : ControllerBase
    {

        private readonly ITypeOfRolesService _typeOfRolesService;
        readonly IMapper _mapper;

        public TypesOfRolesController(ITypeOfRolesService typeOfRolesService, IMapper mapper)
        {
            _typeOfRolesService = typeOfRolesService;
            _mapper = mapper;

        }


        // GET: api/<TypesOfRolesController>
        [HttpGet]
        public IEnumerable<TypesOfRolesDTO> Get()
        {
            var list=_typeOfRolesService.GetList();
            var lDTO= _mapper.Map<IEnumerable<TypesOfRolesDTO>>(list);
            return lDTO;
        }

        // GET api/<TypesOfRolesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TypesOfRolesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TypesOfRolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TypesOfRolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
