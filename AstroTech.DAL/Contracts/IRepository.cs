using System.Linq.Expressions;


namespace AstroTech.Infrastructure.Contracts;

public interface IRepository<TEntity> where TEntity: class
{
    TEntity GetById(int id);
    Task<TEntity> GetByIdAsync(int id);
    IEnumerable<TEntity> GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    int Count(Expression<Func<TEntity, bool>> predicate = null);
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
    Task DeleteAsync(int id);
}
