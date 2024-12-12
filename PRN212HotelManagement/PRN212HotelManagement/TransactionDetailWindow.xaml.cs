using System;
using System.Linq;
using System.Windows;
using HotelManagement_BLL;
using HotelManagement_DAL.Repositories;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;

namespace PRN212HotelManagement
{
    public partial class TransactionDetailWindow : Window
    {
        private readonly TransactionService _transactionService;
        private readonly BookingServices _bookingService;
        private readonly UserService _userService;
        private readonly RoomService _roomService;

        public TransactionDetailWindow(int transactionId)
        {
            InitializeComponent();
            _transactionService = new TransactionService(new TransactionRepository(new Prn212hotelManagementContext()));
            _bookingService = new BookingServices(new BookingRepository(new Prn212hotelManagementContext()));
            _userService = new UserService(new UserRepository(new Prn212hotelManagementContext()));
            _roomService = new RoomService(new RoomRepository(new Prn212hotelManagementContext()));
            LoadTransactionDetails(transactionId);
        }

        private void LoadTransactionDetails(int transactionId)
        {
            var transaction = _transactionService.GetAllTransactions()
                .FirstOrDefault(t => t.TransactionId == transactionId);

            if (transaction != null)
            {
                // Transaction Details
                txtTransactionId.Text = $"ID: {transaction.TransactionId}, Type: {transaction.TransactionType}, Status: {transaction.TransactionStatus}";

                // Booking Details
                var booking = _bookingService.GetAllBookings()
                    .FirstOrDefault(b => b.BookingId == transaction.BookingId);
                if (booking != null)
                {
                    txtBookingDetails.Text = $"Booking ID: {booking.BookingId}, Start: {booking.BookingStartDay}, End: {booking.BookingEndDay}, Total Price: {booking.TotalPrice}";
                }

                // User Details
                var user = _userService.GetAllUsers()
                    .FirstOrDefault(u => u.UserId == transaction.UserId);
                if (user != null)
                {
                    txtUserDetails.Text = $"Name: {user.UserName}, Email: {user.UserEmail}, Phone: {user.UserPhone}";
                }

                // Room Details
                var room = _roomService.GetAllRooms()
                    .FirstOrDefault(r => r.RoomId == booking.RoomId);
                if (room != null)
                {
                    txtRoomDetails.Text = $"Room Name: {room.RoomName}, Type: {room.RoomType}, Status: {room.RoomStatus}";
                }
            }
            else
            {
                MessageBox.Show("Transaction not found.");
                this.Close();
            }
        }
    }
}
