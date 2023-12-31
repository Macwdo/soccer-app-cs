using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories.Player;

public class PlayerBillRepository: BaseRepository<PlayerBillEntity>, IPlayerBillRepository
{
    private readonly IBaseRepository<PlayerEntity> _playerRepository;

    public PlayerBillRepository(
        WebApiDbContext context,
        IBaseRepository<PlayerEntity> playerRepository
        ) : base(context)
    {
        _playerRepository = playerRepository;
    }

    public override async Task<PlayerBillEntity> Add(PlayerBillEntity entity)
    {
        var player = await _playerRepository.GetById(entity.PlayerId);
        if (player == null)
            throw new Exception($"Player by id {entity.PlayerId} not found.");
        return await base.Add(entity);
    }
}