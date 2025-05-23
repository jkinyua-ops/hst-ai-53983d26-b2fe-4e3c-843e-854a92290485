using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.Data;

namespace TicketingApp.Services
{
    public class EventService
    {
        private List<Event> _events;
        private List<Booking> _bookings;

        public EventService()
        {
            _events = new List<Event>
            {
                new Event { Id = 1, Name = "Summer Concert", Description = "A night of great music", Date = DateTime.Now.AddDays(30), Price = 50.00m, AvailableTickets = 100 },
                new Event { Id = 2, Name = "Comedy Show", Description = "Laugh out loud with top comedians", Date = DateTime.Now.AddDays(45), Price = 35.00m, AvailableTickets = 50 }
            };

            _bookings = new List<Booking>();
        }

        public Task<List<Event>> GetEventsAsync()
        {
            return Task.FromResult(_events);
        }

        public Task<Event> GetEventAsync(int id)
        {
            return Task.FromResult(_events.FirstOrDefault(e => e.Id == id));
        }

        public Task<Booking> CreateBookingAsync(int eventId, string userId, int ticketCount)
        {
            var evt = _events.FirstOrDefault(e => e.Id == eventId);
            if (evt == null || evt.AvailableTickets < ticketCount)
            {
                return Task.FromResult<Booking>(null);
            }

            var booking = new Booking
            {
                Id = _bookings.Count + 1,
                EventId = eventId,
                UserId = userId,
                TicketCount = ticketCount,
                TotalPrice = evt.Price * ticketCount,
                IsPaid = false
            };

            _bookings.Add(booking);
            evt.AvailableTickets -= ticketCount;

            return Task.FromResult(booking);
        }

        public Task<List<Booking>> GetUserBookingsAsync(string userId)
        {
            return Task.FromResult(_bookings.Where(b => b.UserId == userId).ToList());
        }

        public Task<bool> MarkBookingAsPaidAsync(int bookingId)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                booking.IsPaid = true;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}