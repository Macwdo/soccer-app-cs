using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Game;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers;
[Route("api/game")]
[ApiController]
public class GameController : BaseCrudController<GameEntity, GameRequest, GameResponse>
{
    public GameController(IBaseRepository<GameEntity> entityRepository, IMapper mapper) : base(entityRepository, mapper) {}
}
