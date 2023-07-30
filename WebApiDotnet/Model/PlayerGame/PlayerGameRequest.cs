using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDotnet.Model.PlayerGame;

public class PlayerGameRequest
{
    [Required, ForeignKey("PlayerId")]
    public int PlayerId { get; set; }
    
    [Required, ForeignKey("GameId")]
    public int GameId { get; set; }
    
}