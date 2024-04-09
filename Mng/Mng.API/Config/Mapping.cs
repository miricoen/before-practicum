using AutoMapper;
using Mng.Core.DTO;
using Mng.Core.Entities;

namespace Mng.Core
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<TypesOfRoles, TypesOfRolesDTO>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<RoleForEmployee, RoleForEmployeeDTO>().ReverseMap();//.ForMember(dest => dest.Id, opt => opt.Ignore()); 
            CreateMap<Employee, EmployeeInputDTO>().ReverseMap();
            CreateMap<Employee, EmployeeOutputDTO>().ReverseMap();
        }
    }
}
