using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDotnet.Model.Goal;

public class GoalResponse: BaseResponse
{
    [ForeignKey("PlayerGameId")]
    public int PlayerGameId {get; set;}
}