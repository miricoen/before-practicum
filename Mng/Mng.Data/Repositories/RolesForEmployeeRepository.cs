using Microsoft.EntityFrameworkCore;
using Mng.Core.Entities;
using Mng.Core.Repositories;


namespace Mng.Data.Repositories
{
    public class RolesForEmployeeRepository: IRolesForEmployeeRepository
    {
        private readonly DataContext _context;

        public RolesForEmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<RoleForEmployee> GetList()
        {
            return _context.Roles;
            //return _context.Roles.Include(r=>r.Role).Include(r => r.Employee);
         
        }

        public RoleForEmployee GetById(int id) {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public void Delete(int id)
        {
            var typesOfRoles = _context.Roles.Find(id);
            if (typesOfRoles != null)
            {
                _context.Roles.Remove(typesOfRoles);
                _context.SaveChanges();
            }
        }

        public void Add(RoleForEmployee role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }



    }
}
