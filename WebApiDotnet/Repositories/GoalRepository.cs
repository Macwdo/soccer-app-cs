using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Repositories;

public class GoalRepository: BaseRepository<GoalEntity>
{
    public GoalRepository(DbContext dbContext) : base(dbContext)
    {
    }
}