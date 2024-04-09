using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Entities
{
    public class TypesOfRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RoleForEmployee> Employees { get; set; }
    }
}
