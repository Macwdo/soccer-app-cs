using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public class PlayerBillRepository: BaseRepository<PlayerBillEntity>, IPlayerBillRepository
{
    public PlayerBillRepository(WebApiDbContext context) : base(context)
    {
    }
}