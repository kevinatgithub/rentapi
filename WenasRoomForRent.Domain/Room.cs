using System.ComponentModel.DataAnnotations;

namespace WenasRoomForRent.Domain;

public class Room
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal PricePerMonth { get; set; }
    public string Remarks { get; set; }
}
