using HotelManagement_DAL.Repositories;
using HotelManagement_DAL;
using System;

namespace HotelManagement_BLL
{
    public class CheckOutService
    {
        private readonly CheckOutRepository _checkOutRepository;

        public CheckOutService(CheckOutRepository checkOutRepository)
        {
            _checkOutRepository = checkOutRepository;
        }

        public Booking GetBookingById(int bookingId)
        {
            return _checkOutRepository.GetBookingById(bookingId);
        }

        public void UpdateBooking(Booking booking)
        {
            _checkOutRepository.UpdateBooking(booking);
        }

        public void AddTransaction(Transaction transaction)
        {
            _checkOutRepository.AddTransaction(transaction);
        }
    }
}