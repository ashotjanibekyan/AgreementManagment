using System.ComponentModel;

namespace AgreementManagment.ViewModels;

public class AgreementReadViewModel
{
    public int Id { get; set; }
    [DisplayName("Username")]
    public string Username { get; set; }

    [DisplayName("Group code")]
    public string GroupCode { get; set; }

    [DisplayName("Group description")]
    public string GroupDescription { get; set; }

    [DisplayName("Number")]
    public int Number { get; set; }

    [DisplayName("Product description")]
    public string ProductDescription { get; set; }

    [DisplayName("Effective date")] 
    public DateTime EffectiveDate { get; set; }

    [DisplayName("Expiration date")] 
    public DateTime ExpirationDate { get; set; }

    [DisplayName("Product price")] 
    public decimal ProductPrice { get; set; }

    [DisplayName("New price")] 
    public decimal NewPrice { get; set; }

    [DisplayName("Active")]
    public bool IsActive { get; set; }
}
