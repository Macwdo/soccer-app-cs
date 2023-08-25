using Microsoft.Build.Framework;

namespace WebApiDotnet.Entities;


public class PlayerGameEntity: BaseEntity
{

    // Many to Many -> Players -> Games | Intersection Table - PlayerGame
    public int PlayerId {get; set;}
    public PlayerEntity Player {get; set;} = null!;
    public int GameId {get; set;}
    public GameEntity Game {get; set;} = null!;

    // One to Many -> PlayerGame -> Goals
    public IEnumerable<GoalEntity> Goals {get; } = new List<GoalEntity>();
}