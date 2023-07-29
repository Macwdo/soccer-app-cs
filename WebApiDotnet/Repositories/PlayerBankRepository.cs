using WebApiDotnet.Data;

namespace WebApiDotnet.Repositories;

public class PlayerBankRepository: BaseRepository<PlayerBankRepository>
{
    public PlayerBankRepository(WebApiDbContext context) : base(context)
    {
    }
}