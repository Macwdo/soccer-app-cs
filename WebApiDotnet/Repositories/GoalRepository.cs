using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public class GoalRepository: BaseRepository<GoalEntity>, IGoalRepository
{
    public GoalRepository(WebApiDbContext context) : base(context)
    {
    }
}