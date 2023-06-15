using WebApiDotnet.Models;

namespace WebApiDotnet.Repositories;

public interface IUserRepository
{
    Task<UserModel> Create(UserModel user);
    Task<List<UserModel>> Read();
    Task<UserModel> Read(int id);
    Task<UserModel> Update(UserModel user, int id);
    Task<bool> Delete(int id);
}