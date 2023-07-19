namespace WebApiDotnet.Entities;


public class PlayerGameEntity: BaseEntity
{

    // Many to Many -> Players -> Games | Intersection Table - PlayerGame
    public int PlayerId {get; set;}
    public PlayerEntity? Player {get; set;}
    public int GameId {get; set;}
    public GameEntity? Game {get; set;}

    // One to Many -> PlayerGame -> Goals
    public List<GoalEntity> Goals {get; } = new List<GoalEntity>();
}