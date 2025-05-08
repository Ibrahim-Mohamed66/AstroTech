using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AstroTech.Infrastructure.Contracts;
using AstroTech.Infrastructure.Data;

namespace AstroTech.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AstroTechAppContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AstroTechAppContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public int Count(Expression<Func<TEntity, bool>> predicate = null)
    {
        return _dbSet.Count(predicate);
    }

    public void Delete(int id)
    {
        TEntity _entityToDelet = _dbSet.Find(id);
        if (_entityToDelet != null)
        {
            _dbSet.Remove(_entityToDelet);
        }
    }

    public async Task DeleteAsync(int id)
    {
        TEntity _entityToDelet = await _dbSet.FindAsync(id);
        if (_entityToDelet != null)
        {
            _dbSet.Remove(_entityToDelet);
        }
    }
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public TEntity GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }
}
