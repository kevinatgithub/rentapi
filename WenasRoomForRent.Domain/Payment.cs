using System.ComponentModel.DataAnnotations;

namespace WenasRoomForRent.Domain;

public class Payment
{
    [Key]
    public int Id { get; set; }
    public int rentId { get; set; }
    public decimal TotalAmount { get; set; } 
    public decimal PaidAmount { get; set; }
    public bool PaymentForRoom { get; set; } = true;
    public decimal Balance { get; set; } 
    public DateTime? PeriodCoveredStartDate { get; set; }
    public DateTime? PeriodCoveredEndDate { get; set; }
    public DateTime PaidDateTime { get; set; }
    public PaymentStatus Status { get; set; }
    public string? Particulars { get; set; }
    public string PaidBy { get; set; }
    public DateTime? LastPrintDate { get; set; }
    public int PrintedTime { get; set; } = 0;
}
