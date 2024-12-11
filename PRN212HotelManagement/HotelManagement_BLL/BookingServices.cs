using HotelManagement_DAL.Repositories;
using HotelManagement_DAL;
using System;
using System.Collections.Generic;

namespace HotelManagement_BLL
{
    public class BookingServices
    {
        private readonly BookingRepository _bookingRepository;
        private readonly UserRepository _userRepository;
        private readonly RoomRepository _roomRepository;

        public BookingServices(BookingRepository bookingRepository, UserRepository userRepository, RoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _roomRepository = roomRepository;
        }

        public BookingServices(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public bool AddBooking(int userId, int roomId, string bookingType, string bookingStatus, DateOnly bookingStartDay, DateOnly bookingEndDay, decimal totalPrice)
        {
            var newBooking = new Booking
            {
                UserId = userId,
                RoomId = roomId,
                BookingType = bookingType,
                BookingStatus = bookingStatus,
                BookingStartDay = bookingStartDay,
                BookingEndDay = bookingEndDay,
                TotalPrice = totalPrice,
                CreatedAt = DateTime.Now,
            };

            return _bookingRepository.AddBooking(newBooking);
        }

        public Booking GetBookingById(int bookingId)
        {
            return _bookingRepository.GetBookingById(bookingId);
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }

        public List<Booking> GetBookingsByStatus(string status)
        {
            return _bookingRepository.GetBookingsByStatus(status);
        }

        public bool UpdateBooking(int bookingId, int userId, int roomId, string bookingType, string bookingStatus, DateOnly bookingStartDay, DateOnly bookingEndDay, decimal totalPrice)
        {
            var booking = new Booking
            {
                BookingId = bookingId,
                UserId = userId,
                RoomId = roomId,
                BookingType = bookingType,
                BookingStatus = bookingStatus,
                BookingStartDay = bookingStartDay,
                BookingEndDay = bookingEndDay,
                TotalPrice = totalPrice,
                CreatedAt = DateTime.Now,
            };

            return _bookingRepository.UpdateBooking(booking);
        }

        public bool DeleteBooking(int bookingId)
        {
            return _bookingRepository.DeleteBooking(bookingId);
        }

        public List<Booking> SearchBookings(string userName = null, string roomName = null, string status = null)
        {
            return _bookingRepository.SearchBookings(userName, roomName, status);
        }
        public User GetUserByUserName(string userName)
        {
            return _userRepository.GetAllUsers().FirstOrDefault(u => u.UserName == userName);
        }

        public Room GetRoomByRoomName(string roomName)
        {
            return _roomRepository.GetAllRooms().FirstOrDefault(r => r.RoomName == roomName);
        }

        public Booking? GetBookingDetails(int bookingId)
        {
            // Gọi repository để lấy thông tin đầy đủ của Booking
            return _bookingRepository.GetBookingById(bookingId);
        }


    }
}
