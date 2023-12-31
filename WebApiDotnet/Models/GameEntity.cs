namespace WebApiDotnet.Entities;


public class GameEntity: BaseEntity
{
    public DateTime GameDate {get; set;}

    // Many to Many -> Games -> Players
    public IEnumerable<PlayerGameEntity> PlayerGames {get;} = new List<PlayerGameEntity>();
}