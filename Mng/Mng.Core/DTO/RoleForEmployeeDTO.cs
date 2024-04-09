using Mng.Core.Entities;

namespace Mng.Core.DTO
{
    public class RoleForEmployeeDTO
    {
        //public int Id { get; set; }
        public int TypesOfRolesId { get; set; }
        public bool IsManagment { get; set; }
        public DateTime DateOfEntryIntoWork { get; set; }
        //public int EmployeeId { get; set; }

    }
}
