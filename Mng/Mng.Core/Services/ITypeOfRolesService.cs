using Mng.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Services
{
    public interface ITypeOfRolesService
    {
        public IEnumerable<TypesOfRoles> GetList();
    }
}
