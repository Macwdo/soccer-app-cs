using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public class GameRepository: BaseRepository<GameEntity>, IGameRepository
{
    public GameRepository(WebApiDbContext context) : base(context)
    {
    }
}