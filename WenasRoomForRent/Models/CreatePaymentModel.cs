namespace WenasRoomForRent.Api.Models;

public class CreatePaymentModel
{
    public int rentId { get; set; }
    public decimal PaidAmount { get; set; }
    public int PaidForTheMonthOf { get; set; }
    public int PaidForTheYearOf { get; set; }
}
