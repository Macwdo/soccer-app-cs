using System.ComponentModel.DataAnnotations.Schema;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Model.Player;

public class PlayerResponse: BaseResponse
{
    public string Phone { get; set;} = null!;
    
    public string FirstName {get; set;} = null!;

    public string LastName {get; set;} = null!;

    public bool? IsActive {get; set;}
    
    [ForeignKey("UserId")]
    public int? UserId { get; set; }
    
    [ForeignKey("PlayerBankId")]
    public int? PlayerBank { get; set; }
    
    public IEnumerable<PlayerGameEntity>? PlayerGames { get; set; }

}