using GenericRepositoryPattern.DataAccessLayer.Contracts;

namespace GenericRepositoryPattern.UnitOfWorks
{
    public interface IUnitofWork
    {
        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        IEmployeeRepository EmployeeRepository { get; } 
       
    }
}
