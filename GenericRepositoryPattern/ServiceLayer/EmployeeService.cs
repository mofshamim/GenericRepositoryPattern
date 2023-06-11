using GenericRepositoryPattern.DataAccessLayer;
using GenericRepositoryPattern.Domain.Entities;
using GenericRepositoryPattern.UnitOfWorks;
using System.Linq.Expressions;

namespace GenericRepositoryPattern.ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitofWork _unitofWork;
        public EmployeeService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public void Add(Employee employee)
        {
            _unitofWork.BeginTransaction();
            _unitofWork.EmployeeRepository.Add(employee);
            _unitofWork.Save();
            throw new Exception();
            _unitofWork.CommitTransaction();
        }
        public void Update(Employee employee)
        {
            _unitofWork.EmployeeRepository.Update(employee);
        }

        public void Delete(int id)
        {
            var employee = _unitofWork.EmployeeRepository.GetById(id);
            _unitofWork.EmployeeRepository.Delete(employee);
        }

        public Employee GetById(int id)
        {
            return _unitofWork.EmployeeRepository.GetById(id);
            //return _unitofWork.EmployeeRepository.GetByEmail("");
        }

        public IEnumerable<Employee> GetAll()
        {
            return _unitofWork.EmployeeRepository.GetAll();
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            return _unitofWork.EmployeeRepository.Find(predicate);
        }
    }
}
