using GenericRepositoryPattern.Domain.Entities;
using System.Linq.Expressions;

namespace GenericRepositoryPattern.ServiceLayer
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate);
    }
}
