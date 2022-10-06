using System.ComponentModel.DataAnnotations;

namespace KevApp.Domain;

public class City
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}
