using System.ComponentModel.DataAnnotations;
namespace WebApiDotnet.Model.Goal;

public class GoalRequest
{
    [Required]
    public int PlayerGameId {get; set;}
}