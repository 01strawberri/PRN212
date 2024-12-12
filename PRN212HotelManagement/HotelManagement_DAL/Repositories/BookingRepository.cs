using HotelManagement_DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagement_DAL.Repositories
{
    public class BookingRepository
    {
        private readonly Prn212hotelManagementContext _prn212hotelManagementContext;

        public BookingRepository(Prn212hotelManagementContext prn212hotelManagementContext)
        {
            _prn212hotelManagementContext = prn212hotelManagementContext;
        }

        public List<Booking> GetAllBookings()
        {
            return _prn212hotelManagementContext.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .ToList();
        }

        public Booking? GetBookingById(int id)
        {
            return _prn212hotelManagementContext.Bookings
                .Include(b => b.User) // Tải thông tin User
                .Include(b => b.Room) // Tải thông tin Room
                .Include(b => b.BookingServices) // Tải các dịch vụ liên quan
                    .ThenInclude(bs => bs.Service) // Tải thông tin chi tiết từng Service
                .FirstOrDefault(b => b.BookingId == id);
        }

        public List<Booking> GetBookingsByStatus(string status)
        {
            return _prn212hotelManagementContext.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .Where(b => b.BookingStatus == status)
                .ToList();
        }

        public bool AddBooking(Booking booking)
        {
            var existingBooking = _prn212hotelManagementContext.Bookings
                .FirstOrDefault(b => b.BookingId == booking.BookingId);
            if (existingBooking != null)
            {
                return false;
            }

            _prn212hotelManagementContext.Bookings.Add(booking);
            _prn212hotelManagementContext.SaveChanges();
            return true;
        }

        public bool UpdateBooking(Booking booking)
        {
            var existingBooking = _prn212hotelManagementContext.Bookings
                .FirstOrDefault(b => b.BookingId == booking.BookingId);
            if (existingBooking == null)
            {
                return false;
            }

            existingBooking.UserId = booking.UserId;
            existingBooking.RoomId = booking.RoomId;
            existingBooking.BookingType = booking.BookingType;
            existingBooking.BookingStatus = booking.BookingStatus;
            existingBooking.BookingStartDay = booking.BookingStartDay;
            existingBooking.BookingEndDay = booking.BookingEndDay;
            existingBooking.TotalPrice = booking.TotalPrice;

            _prn212hotelManagementContext.SaveChanges();
            return true;
        }

        public bool DeleteBooking(int bookingId)
        {
            var booking = _prn212hotelManagementContext.Bookings
                .FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                return false;
            }

            _prn212hotelManagementContext.Bookings.Remove(booking);
            _prn212hotelManagementContext.SaveChanges();
            return true;
        }

        public List<Booking> SearchBookings(string userName = null, string bookingType = null, string status = null)
        {
            var query = _prn212hotelManagementContext.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .AsQueryable();

            if (!string.IsNullOrEmpty(userName))
            {
                query = query.Where(b => b.User.UserName.Contains(userName));
            }

            if (!string.IsNullOrEmpty(bookingType))
            {
                query = query.Where(b => b.BookingType.Contains(bookingType));
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(b => b.BookingStatus.Contains(status));
            }

            return query.ToList();
        }
        public bool AddBookingService(BookingService bookingService)
        {
            try
            {
                _prn212hotelManagementContext.BookingServices.Add(bookingService);
                _prn212hotelManagementContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding BookingService: {ex.Message}");
                return false;
            }
        }
        public bool DeleteBookingServices(int bookingId)
        {
            var bookingServices = _prn212hotelManagementContext.BookingServices
                .Where(bs => bs.BookingId == bookingId)
                .ToList();

            if (bookingServices.Any())
            {
                _prn212hotelManagementContext.BookingServices.RemoveRange(bookingServices);
                _prn212hotelManagementContext.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
