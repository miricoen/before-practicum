using Mng.Core.Entities;

namespace Mng.Core.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetList();

        public Task<Employee> GetById(int id);

        public Task<bool> Add(Employee employee);

        public Task<bool> Update(Employee employee);

        public Task<bool> Delete(int id);

    }
}
