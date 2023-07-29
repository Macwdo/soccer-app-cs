using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories.Player;

public class PlayerRepository : BaseRepository<PlayerEntity>, IPlayerRepository
{

    private readonly IBaseRepository<PlayerBankEntity> _playerBankRepository;
    private readonly UserManager<UserEntity> _userManager;

    public PlayerRepository(
        WebApiDbContext context,
        IBaseRepository<PlayerBankEntity> playerBankRepository,
        UserManager<UserEntity> userManager
    ) : base(context)
    {
        _userManager = userManager;
        _playerBankRepository = playerBankRepository;
    }

    public override async Task<PlayerEntity> Add(PlayerEntity entity)
    {
        if (entity.PlayerBankId != null){
            var playerBank = await _playerBankRepository.GetById((int)entity.PlayerBankId);
            if (playerBank == null)
                throw new Exception($"PlayerBank by id {entity.PlayerBankId} not found.");
        }

        if (entity.UserId != null)
        {
            var user = await _userManager.FindByIdAsync(entity.UserId);
            if (user != null)
                throw new Exception($"User by id {entity.UserId} not found.");
        }
        
        return await base.Add(entity);
    }
}