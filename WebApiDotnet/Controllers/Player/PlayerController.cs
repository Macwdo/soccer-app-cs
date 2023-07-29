using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Player;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers.Player;
[Route("api/player")]
[ApiController]
public class PlayerController : BaseCrudController<PlayerEntity, PlayerRequest, PlayerResponse>
{
    public PlayerController(IBaseRepository<PlayerEntity> entityRepository, IMapper mapper) : base(entityRepository, mapper) {}
}
