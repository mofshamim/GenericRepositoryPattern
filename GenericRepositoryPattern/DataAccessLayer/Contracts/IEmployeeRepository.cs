using GenericRepositoryPattern.Domain.Entities;

namespace GenericRepositoryPattern.DataAccessLayer.Contracts
{

    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetByEmail(string email);
    }
}
