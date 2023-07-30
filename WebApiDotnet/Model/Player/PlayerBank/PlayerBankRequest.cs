using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace WebApiDotnet.Model.Player.PlayerBank;

public class PlayerBankRequest
{
   
    [Required]
    public string PixKey { get; set; }
}