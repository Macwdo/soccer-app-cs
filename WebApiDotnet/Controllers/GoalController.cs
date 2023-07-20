using Microsoft.AspNetCore.Mvc;
using WebApiDotnet.Repositories;

namespace WebApiDotnet.Controllers;

public class GoalController: Controller
{
    private readonly GoalRepository _goalRepository;

    public GoalController(GoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }
    
    
}