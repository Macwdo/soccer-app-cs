using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class BaseRepository<TEntity> where TEntity : class
{
    private readonly DbContext _dbContext;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
    }

    public List<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().ToList();
    }

    public TEntity GetById(int id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _dbContext.Set<TEntity>().Find(id);
        if (entity == null) return;
        _dbContext.Set<TEntity>().Remove(entity);
        _dbContext.SaveChanges();
    }
}