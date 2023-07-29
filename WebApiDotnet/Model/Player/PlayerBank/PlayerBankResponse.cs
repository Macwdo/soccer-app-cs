namespace WebApiDotnet.Model.Player.PlayerBank;

public class PlayerBankResponse: BaseResponse
{
    public string? PixKey { get; set; }
    public PlayerResponse Player { get; set; } = null!;

}