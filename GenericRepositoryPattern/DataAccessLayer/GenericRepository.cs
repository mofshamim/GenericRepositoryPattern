
using GenericRepositoryPattern.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace GenericRepositoryPattern.DataAccessLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
     
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public  IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IEnumerable<T> ExecuteSqlQuery(string sql, params object[] parameters)
        {
            return _dbSet.FromSqlRaw(sql, parameters).ToList();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public IEnumerable<T> ExecuteStoredProcedure(string storedProcedureName, params object[] parameters)
        {
            return _dbSet.FromSqlInterpolated($"EXEC {storedProcedureName} {CreateSqlParameterString(parameters)}").ToList();
        }

        private string CreateSqlParameterString(object[] parameters)
        {
            var parameterString = new StringBuilder();
            for (int i = 0; i < parameters.Length; i++)
            {
                var parameterName = $"@p{i}";
                parameterString.Append($"{parameterName}, ");

                var parameter = new SqlParameter(parameterName, parameters[i]);
                _context.Entry(parameter).Property("Value").CurrentValue = parameters[i];
            }

            return parameterString.ToString().TrimEnd(',', ' ');
        }
    }
}
