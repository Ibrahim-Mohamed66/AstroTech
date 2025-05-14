using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AstroTech.DAL.Data;
using AstroTech.DAL.Contracts;

namespace AstroTech.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AstroTechAppContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AstroTechAppContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        // Add a new entity
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        // Add a new entity asynchronously
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        // Count entities based on a predicate (optional)
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _dbSet.Count() : _dbSet.Count(predicate);
        }

        // Delete an entity by ID
        public void Delete(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        // Delete an entity by ID asynchronously
        public async Task DeleteAsync(int id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        // Find entities based on a predicate
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        // Find entities based on a predicate asynchronously
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        // Get all entities
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        // Get all entities asynchronously
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Get an entity by ID
        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        // Get an entity by ID asynchronously
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Update an existing entity
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
