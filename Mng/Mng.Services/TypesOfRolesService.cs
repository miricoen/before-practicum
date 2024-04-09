using AutoMapper;
using Mng.Core.Entities;
using Mng.Core.Repositories;
using Mng.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Services
{
    public class TypesOfRolesService:ITypeOfRolesService
    {
        private readonly ITypesOfRolesRepository _typesOfRolesRepository;

        public TypesOfRolesService(ITypesOfRolesRepository typesOfRolesRepository)
        {
            _typesOfRolesRepository = typesOfRolesRepository;

        }

        public IEnumerable<TypesOfRoles> GetList()
        {
            return _typesOfRolesRepository.GetList();
        }

    }
}
