using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDotnet.Model.Player;

public class PlayerRequest
{
    [Required, MaxLength(11)]
    public string? Phone { get; set;}
    
    [Required, MaxLength(20)]
    public string? FirstName {get; set;}

    [Required, MaxLength(20)]
    public string? LastName {get; set;}

    [Required]
    public bool IsActive {get; set;}
    
    [ForeignKey("UserId")]
    public string? UserId {get; set;}
    
    [ForeignKey("PlayerBankId")]
    public string? PlayerBankId {get; set;}



}