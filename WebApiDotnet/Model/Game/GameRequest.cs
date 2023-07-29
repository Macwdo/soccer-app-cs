using System.ComponentModel.DataAnnotations;

namespace WebApiDotnet.Model.Game;

public class GameRequest
{
    [Required]
    public DateTime GameDate { get; set; }
}