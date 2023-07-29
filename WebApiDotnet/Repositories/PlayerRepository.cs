using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Repositories;

public class PlayerRepository : BaseRepository<PlayerEntity>, IPlayerRepository
{
    public PlayerRepository(WebApiDbContext context) : base(context) {}
}