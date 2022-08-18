using System.ComponentModel.DataAnnotations;

namespace WenasRoomForRent.Domain;

public class Profile
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string ContactNumber { get; set; }
}
