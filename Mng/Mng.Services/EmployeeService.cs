
using Mng.Core.Entities;
using Mng.Core.Repositories;
using Mng.Core.Services;
using System.Data;
using System.Text.RegularExpressions;


namespace Mng.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetList()
        {
            return await _employeeRepository.GetList();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public (bool IsValid, string ErrorMessage) IsEmployeeValid(Employee employee)
        {
            // בדיקת תקינות ת.ז.
            if (!Regex.IsMatch(employee.Tz, @"^\d{9}$"))
            {
                return (false, "Invalid ID number");
            }

            // בדיקת גיל
            if (employee.BornDate < DateTime.Today.AddYears(-70))
            {
                return (false, "It is not possible to add an employee who is over 70 years old");
            }

            // בדיקת גיל מינימלי
            if (employee.StartDate < employee.BornDate.AddYears(18))
            {
                return (false, "It is not possible to add an employee under the age of 18");
            }

            // בדיקת תאריך תקין של תחילת עבודה
            foreach (RoleForEmployee role in employee.Roles)
            {
                if (role.DateOfEntryIntoWork < employee.StartDate)
                {
                    return (false, "Date of entry to work cannot be less than date of start of work");
                }
            }

            // בדיקת כפילויות בתפקידים
            foreach (var role1 in employee.Roles)
            {
                foreach (var role2 in employee.Roles)
                {
                    if (role1.TypesOfRolesId == role2.TypesOfRolesId && !ReferenceEquals(role1, role2))
                    {
                        return (false, "It is not possible to add a job to an employee twice");
                    }
                }
            }

            // אם כל הבדיקות עברו בהצלחה, מחזירים תוצאה חיובית כי העובד חוקי
            return (true, null);
        }


        public async Task<(bool success, string errorMessage)> Add(Employee employee)
        {
            var validationResult = IsEmployeeValid(employee);
            if (!validationResult.IsValid)
            {
                // אם העובד לא תקין, יש להחזיר ערך שלילי ואת השגיאה המתאימה
                return (false, validationResult.ErrorMessage);
            }

            // קריאה לפונקציה להוספת העובד
            if (await _employeeRepository.Add(employee))
            {
                return (true, ""); // הוספה הצליחה
            }
            else
            {
                return (false, "Failed to add employee"); // הוספה נכשלה
            }
        }


        public async Task<(bool, string)> Update(Employee employee)
        {
            var validationResult = IsEmployeeValid(employee);
            if (!validationResult.IsValid)
            {
                // אם העובד לא תקין, יש להחזיר ערך שלילי ואת השגיאה המתאימה
                return (false, validationResult.ErrorMessage);
            }

            // קריאה לפונקציה לעדכון העובד
            if (await _employeeRepository.Update(employee))
            {
                return (true, ""); // עדכון הצליח
            }
            else
            {
                return (false, "Failed to update employee"); // כישלון בעדכון העובד
            }
        }



        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.Delete(id);
        }
    }
}
