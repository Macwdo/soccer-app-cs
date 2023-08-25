using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Model.Player.PlayerBill;

public class PlayerBillRequest
{
    [Required, ForeignKey("PlayerId")]
    public int PlayerId {get; set;}
    
    [Required]
    public BillType BillType {get; set;}
    
    [Required]
    public double Value {get; set;}
}