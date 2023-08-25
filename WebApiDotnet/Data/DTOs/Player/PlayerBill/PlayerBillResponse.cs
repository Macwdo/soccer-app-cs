using System.ComponentModel.DataAnnotations.Schema;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Model.Player.PlayerBill;

public class PlayerBillResponse: BaseResponse
{
    [ForeignKey("PlayerId")]
    public int PlayerId {get; set;}
    
    public BillType BillType {get; set;}
    
    public double Value {get; set;}
    
}
