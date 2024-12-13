using HotelManagement_DAL.DBContext;
using System;

namespace HotelManagement_DAL.Repositories
{
    public class CheckOutRepository
    {
        private readonly Prn212hotelManagementContext _context;

        public CheckOutRepository(Prn212hotelManagementContext context)
        {
            _context = context;
        }

        public Booking GetBookingById(int bookingId)
        {
            return _context.Bookings.Find(bookingId);
        }

        public void UpdateBookingStatusToConfirmed(int bookingId)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking != null)
            {
                booking.BookingStatus = "Confirmed";
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Booking with ID {bookingId} not found.");
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}
