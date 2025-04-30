namespace lr9.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
