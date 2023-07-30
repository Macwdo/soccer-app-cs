using WebApiDotnet.Entities;

namespace WebApiDotnet.Model.Player;

public class PlayerResponse: BaseResponse
{
    public string Phone { get; set;} = null!;
    
    public string FirstName {get; set;} = null!;

    public string LastName {get; set;} = null!;

    public bool? IsActive {get; set;}
    
    public UserResponse? User { get; set; }
    
    public PlayerBankEntity? PlayerBank { get; set; }
    
    public IEnumerable<PlayerGameEntity>? PlayerGames { get; set; }

}