using Mng.Core.Entities;

namespace Mng.Core.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetList();

        public Task<Employee> GetById(int id);

        public Task<(bool success, string errorMessage)> Add(Employee employee);

        public Task<(bool, string)> Update(Employee employee);

        public Task<bool> Delete(int id);

    }
}
