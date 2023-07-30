using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public class GoalRepository: BaseRepository<GoalEntity>, IGoalRepository
{
    private readonly IBaseRepository<PlayerGameEntity> _playerGameRepository;

    public GoalRepository(
        WebApiDbContext context,
        IBaseRepository<PlayerGameEntity> playerGameRepository
            ) : base(context)
    {
        _playerGameRepository = playerGameRepository;
    }

    public override async Task<GoalEntity> Add(GoalEntity entity)
    {
        var playerGame = await _playerGameRepository.GetById(entity.PlayerGameId);
        if (playerGame == null)
            throw new Exception($"PlayerGame by id {entity.PlayerGameId} not found.");
            
        return await base.Add(entity);
    }
}