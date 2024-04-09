using Microsoft.EntityFrameworkCore;
using Mng.Core.Entities;
using Mng.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Data.Repositories
{
    public class TypesOfRolesRepository:ITypesOfRolesRepository
    {
        private readonly DataContext _context;

        public TypesOfRolesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TypesOfRoles> GetList()
        {
            return _context.TypesOfRoles;
        }


    }
}
