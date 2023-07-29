using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : class
{
    protected WebApiDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(WebApiDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }


    public virtual async Task<TEntity> Add(TEntity entity)
    {
        try
        {
            var createdEntity = await _dbSet.AddAsync(entity);
            _context.SaveChanges();
            return createdEntity.Entity;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public virtual async Task<TEntity?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual TEntity Update(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public virtual void Remove(TEntity entity)
    {
        try
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
}