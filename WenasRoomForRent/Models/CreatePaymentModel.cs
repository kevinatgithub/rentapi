namespace WenasRoomForRent.Api.Models;

public class CreatePaymentModel
{
    public int rentId { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal? Balance { get; set; }
    public DateTime? PeriodStartDate { get; set; }
    public DateTime? PeriodEndDate { get; set; }
    public string? Particulars { get; set; }
    public DateTime? PaidDateTime { get; set; }
    public string PaidBy { get; set; }
    public bool PaymentForRoom { get; set; }
}
