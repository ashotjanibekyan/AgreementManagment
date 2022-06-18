using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AgreementManagment.Models;

public class Agreement
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    public Group Group { get; set; }
    public Product Product { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal NewPrice { get; set; }
    public bool IsActive { get; set; }
}
