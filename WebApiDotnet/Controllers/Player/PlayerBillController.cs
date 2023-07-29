using AutoMapper;
using MassTransit.Futures.Contracts;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Player.PlayerBill;
using WebApiDotnet.Repositories;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers.Player;

[Route("api/player-bill")]
[ApiController]
public class PlayerBillController : BaseCrudController<PlayerBillEntity, PlayerBillRequest, PlayerBillResponse>
{
    public PlayerBillController(IBaseRepository<PlayerBillEntity> playerBillRepository, IMapper mapper) : base(playerBillRepository, mapper) {}
}
