using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Player;
using WebApiDotnet.Model.PlayerGame;
using WebApiDotnet.Repositories.Interfaces;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApiDotnet.Controllers;

[Route("api/player-game")]
[ApiController]
public class PlayerGameController: BaseCrudController<PlayerGameEntity, PlayerGameRequest, PlayerGameResponse>
{
    public PlayerGameController(IBaseRepository<PlayerGameEntity> playerGameEntity, IMapper mapper) : base(playerGameEntity, mapper) {}
}