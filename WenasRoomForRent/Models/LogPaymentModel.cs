namespace WenasRoomForRent.Api.Models
{
    public class LogPaymentModel
    {
        public int rentId { get; set; }
        public DateTime PeriodStartDateTime { get; set; }
        public DateTime PeriodEndDateTime { get; set; }
    }
}
