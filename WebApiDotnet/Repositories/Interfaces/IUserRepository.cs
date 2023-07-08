using WebApiDotnet.Entities;

namespace WebApiDotnet.Repositories;

public interface IUserRepository
{
    public Task<List<User>> Find();
    public Task<User?> Find(Guid guid);
    public Task<User> Add(User user);
    public Task<User?> Edit(Guid guid, User user);
    public Task<bool> Delete(Guid guid);
}