using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Api.Models;

public class PaymentModel
{
    public Payment Payment { get; set; }
    public Room Room { get; set; }
    public Rent Rent { get; set; }
    public Profile Profile { get; set; }
}
