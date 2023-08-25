namespace WebApiDotnet.Entities;


public class GoalEntity: BaseEntity
{
    public PlayerGameEntity PlayerGame {get; set;} = null!;
    public int PlayerGameId {get; set;}

}