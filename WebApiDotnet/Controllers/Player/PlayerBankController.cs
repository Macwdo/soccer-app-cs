using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Player.PlayerBank;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers.Player;

[Route("api/player-bank")]
[ApiController]
public class PlayerBankController : BaseCrudController<PlayerBankEntity, PlayerBankRequest, PlayerBankResponse>
{
    
    public PlayerBankController(IBaseRepository<PlayerBankEntity> playerBankRepository, IMapper mapper) : base(playerBankRepository, mapper){}
    
}
