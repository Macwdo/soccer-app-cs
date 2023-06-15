using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Models;

namespace WebApiDotnet.Repositories;

public class UserRepository: IUserRepository
{
    private readonly WebApiDotnetDBContext _dbContext;

    public UserRepository(WebApiDotnetDBContext webApiDotnetDbContext)
    {
        _dbContext = webApiDotnetDbContext;
    }
    
    
    public async Task<UserModel> Create(UserModel user)
    {
         await _dbContext.User.AddAsync(user);
         await _dbContext.SaveChangesAsync();

         return user;
    }

    public async Task<List<UserModel>> Read()
    {
        return await _dbContext.User.ToListAsync();
    }

    public async Task<UserModel> Read(int id)
    {
        return await _dbContext.User.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<UserModel> Update(UserModel user, int id)
    {
        UserModel userById = await Read(id);

        if (userById == null)
        {
            throw new Exception($"User by id equal {id} not found");
        }

        userById.Id = user.Id;
        userById.Name = user.Name;
        userById.Email = user.Email;

        _dbContext.User.Update(userById);
        await _dbContext.SaveChangesAsync();
        return userById;

    }

    public async Task<bool> Delete(int id)
    {
        UserModel userById = await Read(id);

        if (userById == null)
        {
            throw new Exception($"User by equal {id} not found");
        }

        _dbContext.User.Remove(userById);
        await _dbContext.SaveChangesAsync();
        return true;
        
        throw new NotImplementedException();
    }
}