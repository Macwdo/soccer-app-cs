namespace WebApiDotnet.Model.Player.PlayerBank;

public class PlayerBankResponse: BaseResponse
{
    public PlayerResponse Player { get; set; }
    public string? PixKey { get; set; }

}