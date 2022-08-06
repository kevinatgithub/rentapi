namespace WenasRoomForRent.Domain;

public class Rent
{
    public int Id { get; set; }
    public int profileId { get; set; }
    public int roomId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string Remarks { get; set; }
    public RentStatus Status { get; set; }
}
