using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public class PlayerGameRepository: BaseRepository<PlayerGameEntity>, IPlayerGameRepository
{
    private readonly IBaseRepository<PlayerEntity> _playerRepository;
    private readonly IBaseRepository<GameEntity> _gameRepository;
    public PlayerGameRepository(
        WebApiDbContext context,
        IBaseRepository<PlayerEntity> playerRepository,
        IBaseRepository<GameEntity> gameRepository
        ) : base(context)
    {
        _playerRepository = playerRepository;
        _gameRepository = gameRepository;
    }

    public override async Task<PlayerGameEntity> Add(PlayerGameEntity entity)
    {
        var player = await _playerRepository.GetById(entity.PlayerId);
        var game = await _gameRepository.GetById(entity.GameId);
        
        if (player == null)
            throw new Exception($"Player by id {entity.PlayerId} not found.");
        
        if (game == null)
            throw new Exception($"Game by id {entity.GameId} not found.");

        return await base.Add(entity);
    }
}