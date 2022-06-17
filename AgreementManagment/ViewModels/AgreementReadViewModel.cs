﻿using System.ComponentModel;

namespace AgreementManagment.ViewModels;

public class AgreementReadViewModel
{
    public int Id { get; set; }
    [DisplayName("Username")]
    public string Username { get; set; }

    [DisplayName("Group code")]
    public string GroupCode { get; set; }

    [DisplayName("Number")]
    public int Number { get; set; }

    [DisplayName("Effective date")] 
    public DateTime EffectiveDate { get; set; }

    [DisplayName("Expiration date")] 
    public DateTime ExpirationDate { get; set; }

    [DisplayName("Product price")] 
    public decimal ProductPrice { get; set; }

    [DisplayName("New price")] 
    public decimal NewPrice { get; set; }
}