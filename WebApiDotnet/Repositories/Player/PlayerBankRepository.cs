using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories.Player;

public class PlayerBankRepository : BaseRepository<PlayerBankEntity>, IPlayerBankRepository
{
    public PlayerBankRepository(WebApiDbContext context) : base(context) {}
}