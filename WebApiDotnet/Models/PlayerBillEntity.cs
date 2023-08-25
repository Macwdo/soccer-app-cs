namespace WebApiDotnet.Entities;


public enum BillType {

    Monthly = 35,
    Game = 15

}


public class PlayerBillEntity: BaseEntity
{
    public PlayerEntity Player {get; set;} = null!;
    public int PlayerId {get; set;}
    public BillType BillType {get; set;}
    public double Value {get; set;}
}
