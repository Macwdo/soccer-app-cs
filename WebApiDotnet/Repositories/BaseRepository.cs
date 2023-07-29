using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : class
{
    private readonly WebApiDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(WebApiDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task Add(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<TEntity?> GetById(int id)
    {
        return await _dbSet.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            return entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void Remove(TEntity entity)
    {
        try
        {
            _dbSet.Remove(entity);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
}