using System;

namespace TicketingApp.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }
    }
}