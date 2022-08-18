namespace WenasRoomForRent.Api.Models;

public class CreatePaymentModel
{
    public int rentId { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PeriodStartDateTime { get; set; }
    public DateTime PeriodEndDateTime { get; set; }
}
