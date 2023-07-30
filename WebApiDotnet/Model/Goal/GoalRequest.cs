using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDotnet.Model.Goal;

public class GoalRequest
{
    [Required, ForeignKey("PlayerGameId")]
    public int PlayerGameId {get; set;}
}