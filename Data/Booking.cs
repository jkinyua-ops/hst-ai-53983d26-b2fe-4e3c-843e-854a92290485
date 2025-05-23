using System;

namespace TicketingApp.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public int TicketCount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
    }
}