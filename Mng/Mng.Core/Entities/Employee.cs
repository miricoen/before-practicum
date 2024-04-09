using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Tz { get; set; }

        public DateTime BornDate { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsMale { get; set; }//האם גבר

        public List<RoleForEmployee> Roles { get; set; }

        public bool Status { get; set; }// האם פעיל

    }
}
