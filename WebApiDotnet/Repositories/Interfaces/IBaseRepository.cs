using WebApiDotnet.Entities;

namespace WebApiDotnet.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
{
    public Task Add(TEntity entity);
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<TEntity?> GetById(int id);
    public TEntity Update(TEntity entity);
    public void Remove(TEntity entity);

}