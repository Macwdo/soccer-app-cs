using WebApiDotnet.Model.Game;
using WebApiDotnet.Model.Player;

namespace WebApiDotnet.Model.PlayerGame;

public class PlayerGameResponse: BaseResponse
{
    public int PlayerId { get; set; }
    public int GameId { get; set; }
}