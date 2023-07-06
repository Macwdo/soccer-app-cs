using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Models;

namespace WebApiDotnet.Repositories;

public class UserRepository: IUserRepository
{
    private readonly WebApiContext _context;
    
    public UserRepository(WebApiContext context)
    {
        _context = context;
    }
    public async Task<List<User>> Find()
    {
        return await _context.User.ToListAsync();
        
    }

    public async Task<User?> Find(Guid guid)
    {
        return await _context.User.FirstOrDefaultAsync(i => i!.Id == guid);
    }

    public async Task<User> Add(User user)
    {
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> Edit(Guid guid, User user)
    {
        var oldUser = await Find(guid);
        if (oldUser == null)
            return null;

        _context.Entry(oldUser).CurrentValues.SetValues(user);
        await _context.SaveChangesAsync();
        return user;


    }

    public async Task<bool> Delete(Guid guid)
    {
        var user = await Find(guid);
        if (user == null)
            return false;

        _context.Remove(user);
        await _context.SaveChangesAsync();
        return true;

    }
}