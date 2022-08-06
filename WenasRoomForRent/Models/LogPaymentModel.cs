namespace WenasRoomForRent.Api.Models
{
    public class LogPaymentModel
    {
        public int rentId { get; set; }
        public int PaidForTheMonthOf { get; set; }
        public int PaidForTheYearOf { get; set; }
    }
}
