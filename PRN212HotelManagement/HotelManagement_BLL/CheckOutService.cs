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

        public void UpdateBookingStatusToConfirmed(int bookingId)
        {
            _checkOutRepository.UpdateBookingStatusToConfirmed(bookingId);
        }

        public void AddTransaction(Transaction transaction)
        {
            _checkOutRepository.AddTransaction(transaction);
        }

        public void PerformCheckOut(int bookingId, decimal totalAmount, string paymentMethod, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Lấy thông tin booking
                var booking = _checkOutRepository.GetBookingById(bookingId);
                if (booking == null)
                {
                    errorMessage = "Booking not found.";
                    return;
                }

                // Cập nhật trạng thái booking thành "Confirmed"
                _checkOutRepository.UpdateBookingStatusToConfirmed(bookingId);

                // Tạo giao dịch
                var transaction = new Transaction
                {
                    BookingId = bookingId,
                    TransactionAmount = totalAmount,
                    TransactionType = paymentMethod,
                    EventDate = DateTime.Now
                };
                _checkOutRepository.AddTransaction(transaction);
            }
            catch (Exception ex)
            {
                errorMessage = $"An error occurred: {ex.Message}";
            }
        }
    }
}
