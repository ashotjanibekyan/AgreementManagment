using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgreementManagment.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    public string Description { get; set; }

    public int Number { get; set; }

    public decimal Price { get; set; }

    public bool Active { get; set; }
}
