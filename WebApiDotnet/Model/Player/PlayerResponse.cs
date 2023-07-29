using System.ComponentModel;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Model.Player;

public class PlayerResponse
{
    public string? Phone { get; set;}
    
    public string? FirstName {get; set;}

    public string? LastName {get; set;}

    public bool IsActive {get; set;}
    
    public string? UserId {get; set;}
    
    public string? PlayerBankId {get; set;}
    
}