namespace WebApiDotnet.Entities;

public class PlayerBankEntity: BaseEntity
{
    public PlayerEntity Player {get; set;} = null!;
    public int PlayerId {get; set;}
    public string? PixKey;
}
