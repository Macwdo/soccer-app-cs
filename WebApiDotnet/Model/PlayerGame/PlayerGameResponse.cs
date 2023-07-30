using System.ComponentModel.DataAnnotations.Schema;
using WebApiDotnet.Model.Game;
using WebApiDotnet.Model.Player;

namespace WebApiDotnet.Model.PlayerGame;

public class PlayerGameResponse: BaseResponse
{
    
    [ForeignKey("PlayerId")]
    public int PlayerId { get; set; }
    
    [ForeignKey("GameId")]
    public int GameId { get; set; }
}