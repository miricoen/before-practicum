using AutoMapper;
using Mng.Core.DTO;
using Mng.Core.Entities;
using Mng.Core.Repositories;
using Mng.Core.Services;


namespace Mng.Services
{
    public class RolesForEmployeeService:IRolesForEmployeeService
    {
        private readonly IRolesForEmployeeRepository _rolesForEmployeeRepository;
        readonly IMapper _mapper;

        public RolesForEmployeeService(IRolesForEmployeeRepository rolesForEmployeeRepository, IMapper mapper)
        {
            _rolesForEmployeeRepository = rolesForEmployeeRepository;
            _mapper = mapper;

        }

        public IEnumerable<RoleForEmployeeDTO> GetList()
        {
            var list=_rolesForEmployeeRepository.GetList();
            var lDTO = _mapper.Map<IEnumerable<RoleForEmployeeDTO>>(list);

            return lDTO;
        }

    }
}
