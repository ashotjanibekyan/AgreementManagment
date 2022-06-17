using System.ComponentModel;

namespace AgreementManagment.ViewModels;

public class AgreementCreateOrEditViewModel
{
    public int? Id { get; set; }
    public int GroupId { get; set; }
    
    [DisplayName("Product")]
    public int ProductId { get; set; }
    
    [DisplayName("Effective date")]
    public DateTime EffectiveDate { get; set; }
    
    [DisplayName("Expiration date")]
    public DateTime ExpirationDate { get; set; }
    
    [DisplayName("New price")]
    public decimal NewPrice { get; set; }
    
    [DisplayName("Product")]
    public bool IsActive { get; set; }
}
