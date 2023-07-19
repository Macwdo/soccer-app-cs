namespace WebApiDotnet.Entities;


public class GameEntity: BaseEntity
{

    public DateTime GameDate {get; set;}

    // Many to Many -> Games -> Players
    public List<PlayerEntity> Players {get;} = new();
}