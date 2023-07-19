namespace WebApiDotnet.Entities;


public class PlayerEntity: BaseEntity{
    
    public string? Phone {get; set;}
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public bool IsActive {get; set;}

    // One to One -> Player -> User
    public UserEntity? User {get; set;}
    public int UserId {get; set;}

    // One to Many -> Player -> PlayerBill
    public List<PlayerBillEntity> PlayerBills {get; } = new List<PlayerBillEntity>();
    
    // One to One -> Player -> PlayerBank
    public PlayerBankEntity? PlayerBank {get; set;}
    public int PlayerBankId {get; set;}

    // Many to Many -> Players -> Games
    public List<GameEntity> Games {get;} = new();

}