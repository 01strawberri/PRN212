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

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}