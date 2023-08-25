namespace WebApiDotnet.Entities;


public class PlayerEntity: BaseEntity{
    
    public string Phone {get; set;} = null!;
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;
    public bool? IsActive {get; set;}

    // One to One -> Player -> User
    public UserEntity User { get; set; } = null!;
    public string UserId { get; set; } = null!;

    // One to Many -> Player -> PlayerBill
    public IEnumerable<PlayerBillEntity> PlayerBills {get; } = new List<PlayerBillEntity>();
    
    // One to One -> Player -> PlayerBank
    public PlayerBankEntity? PlayerBank {get; set;}
    public int? PlayerBankId {get; set;}

    // Many to Many -> Players -> Games
    public IEnumerable<PlayerGameEntity> PlayerGames { get; } = new List<PlayerGameEntity>();

}