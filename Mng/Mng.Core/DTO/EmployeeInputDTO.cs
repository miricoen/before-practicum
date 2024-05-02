

namespace Mng.Core.DTO
{
    public class EmployeeInputDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Tz { get; set; }

        public DateTime BornDate { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsMale { get; set; }//האם גבר

        public List<RoleForEmployeeDTO> Roles { get; set; }

        public bool Status { get; set; }// האם פעיל//לבדוק
    }
}
