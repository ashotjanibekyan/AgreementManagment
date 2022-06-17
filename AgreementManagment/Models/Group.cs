using System.ComponentModel.DataAnnotations;

namespace AgreementManagment.Models;

public class Group
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public bool Active { get; set; }
}
