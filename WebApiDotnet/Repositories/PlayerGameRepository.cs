using WebApiDotnet.Data;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public class PlayerGameRepository: BaseRepository<PlayerGameRepository>, IPlayerGameRepository
{
    public PlayerGameRepository(WebApiDbContext context) : base(context)
    {
    }
}