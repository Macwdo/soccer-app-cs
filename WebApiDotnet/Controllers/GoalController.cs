using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Entities;
using WebApiDotnet.Model.Goal;
using WebApiDotnet.Repositories.Interfaces;

namespace WebApiDotnet.Controllers;
[Route("api/goal")]
[ApiController]
public class GoalController : BaseCrudController<GoalEntity, GoalRequest, GoalResponse>
{
    public GoalController(IBaseRepository<GoalEntity> entityRepository, IMapper mapper) : base(entityRepository, mapper) {}
}
