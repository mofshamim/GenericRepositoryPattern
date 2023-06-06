using GenericRepositoryPattern.DataAccessLayer.Contracts;
using GenericRepositoryPattern.DataContext;
using GenericRepositoryPattern.Domain.Entities;

namespace GenericRepositoryPattern.DataAccessLayer.Implementations
{
 

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Employee GetByEmail(string email)
        { 
            return base.GetById(1);
        }

    }

}
