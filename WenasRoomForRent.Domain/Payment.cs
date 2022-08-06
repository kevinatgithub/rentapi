namespace WenasRoomForRent.Domain;

public class Payment
{
    public int Id { get; set; }
    public int rentId { get; set; }
    public decimal TotalAmount { get; set; } 
    public decimal PaidAmount { get; set; }
    public decimal Balance { get; set; } 
    public DateTime PaidDateTime { get; set; }
    public int PaidForTheMonthOf { get; set; }
    public int PaidForTheYearOf { get; set; }
    public PaymentStatus Status { get; set; }
}
