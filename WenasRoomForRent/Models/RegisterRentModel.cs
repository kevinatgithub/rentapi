namespace WenasRoomForRent.Api.Models;

public class RegisterRentModel
{
    public int profileId { get; set; }
    public int roomId { get; set; }
    public DateTime startDate { get; set; }
    public string Remarks { get; set; }
}
