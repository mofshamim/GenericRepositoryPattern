using System.Linq.Expressions;

namespace GenericRepositoryPattern.DataAccessLayer
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
       
        IEnumerable<T> ExecuteSqlQuery(string sql, params object[] parameters);
        int ExecuteSqlCommand(string sql, params object[] parameters);
        IEnumerable<T> ExecuteStoredProcedure(string storedProcedureName, params object[] parameters);
    }
}
