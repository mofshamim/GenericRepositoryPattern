using GenericRepositoryPattern.DataAccessLayer.Contracts;
using GenericRepositoryPattern.DataAccessLayer.Implementations;
using GenericRepositoryPattern.DataContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace GenericRepositoryPattern.UnitOfWorks
{

    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _transaction;

        //public UnitofWork(ApplicationDbContext context)
        //{
        //    _context = context;
        //    EmployeeRepository = new EmployeeRepository(context);
        //}

        public UnitofWork(ApplicationDbContext context, IDbContextTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
            EmployeeRepository = new EmployeeRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
        }

        public void RollbackTransaction()
        {
           _transaction?.Rollback();
        }

        public IEmployeeRepository EmployeeRepository { get; private set; }


    }
}
