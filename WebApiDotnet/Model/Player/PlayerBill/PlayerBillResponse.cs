using WebApiDotnet.Entities;

namespace WebApiDotnet.Model.Player.PlayerBill;

public class PlayerBillResponse: BaseResponse
{
    public PlayerResponse Player {get; set;}
    public BillType BillType {get; set;}
    public double Value {get; set;}
    
}
