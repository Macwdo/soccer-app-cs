namespace WebApiDotnet.Entities;

public class PlayerBankEntity: BaseEntity
{
    public PlayerEntity Player {get; set;} = null!;
    public string PixKey { get; set; } = null!;
}
