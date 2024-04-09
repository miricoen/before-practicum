namespace Mng.Core.Entities
{
    public class RoleForEmployee
    {
        public int Id { get; set; }

        public int TypesOfRolesId { get; set; }
        public TypesOfRoles Role { get; set; }//FK

        public bool IsManagment { get; set; }

        public DateTime DateOfEntryIntoWork { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }//FK
    }
}
