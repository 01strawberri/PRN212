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

        private readonly ServiceRepository _repository;

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


        public bool AddBooking(
                        int userId,
                        int roomId,
                        DateOnly startDate,
                        DateOnly endDate,
                        string bookingType,
                        string bookingStatus,
                        List<Service> selectedServices,
                        out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Lấy giá phòng từ RoomPrice
                var roomPricePerDay = _roomRepository.GetRoomPricePerDay(roomId);
                if (roomPricePerDay == null)
                {
                    errorMessage = "Room price not found.";
                    return false;
                }

                int totalDays = (endDate.ToDateTime(new TimeOnly(0, 0)) - startDate.ToDateTime(new TimeOnly(0, 0))).Days + 1;
                decimal totalPrice = totalDays * roomPricePerDay.Value;

                // Tổng tiền dịch vụ
                decimal totalServicePrice = selectedServices.Sum(service => service.ServicePrice);
                totalPrice += totalServicePrice;

                // Tạo đối tượng Booking
                var booking = new Booking
                {
                    UserId = userId,
                    RoomId = roomId,
                    BookingStartDay = startDate,
                    BookingEndDay = endDate,
                    BookingType = bookingType,
                    BookingStatus = bookingStatus,
                    TotalPrice = totalPrice,
                    CreatedAt = DateTime.Now
                };

                // Thêm booking
                if (!_bookingRepository.AddBooking(booking))
                {
                    errorMessage = "Failed to add booking.";
                    return false;
                }

                // Thêm các dịch vụ vào BookingService
                foreach (var service in selectedServices)
                {
                    var bookingService = new BookingService
                    {
                        BookingId = booking.BookingId,
                        ServiceId = service.ServiceId,
                        ServicePrice = service.ServicePrice,
                        CreatedAt = DateTime.Now
                    };

                    _bookingRepository.AddBookingService(bookingService);
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"An error occurred: {ex.Message}";
                return false;
            }
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

        public bool UpdateBooking(
                        int bookingId,
                        int userId,
                        int roomId,
                        string bookingType,
                        string bookingStatus,
                        DateOnly bookingStartDay,
                        DateOnly bookingEndDay,
                        decimal totalPrice,
                        List<Service> selectedServices, // Thêm tham số dịch vụ đã chọn
                        out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Kiểm tra booking có tồn tại không
                var booking = _bookingRepository.GetBookingById(bookingId);
                if (booking == null)
                {
                    errorMessage = "Booking not found.";
                    return false;
                }

                // Cập nhật thông tin booking
                booking.UserId = userId;
                booking.RoomId = roomId;
                booking.BookingType = bookingType;
                booking.BookingStatus = bookingStatus;
                booking.BookingStartDay = bookingStartDay;
                booking.BookingEndDay = bookingEndDay;
                booking.TotalPrice = totalPrice;

                // Cập nhật thông tin trong cơ sở dữ liệu
                bool isUpdated = _bookingRepository.UpdateBooking(booking);
                if (!isUpdated)
                {
                    errorMessage = "Failed to update booking.";
                    return false;
                }

                // Cập nhật thông tin dịch vụ (nếu có)
                // Đầu tiên, xóa tất cả dịch vụ hiện tại
                _bookingRepository.DeleteBookingServices(bookingId);

                // Sau đó, thêm các dịch vụ mới vào
                foreach (var service in selectedServices)
                {
                    var bookingService = new BookingService
                    {
                        BookingId = booking.BookingId,
                        ServiceId = service.ServiceId,
                        ServicePrice = service.ServicePrice,
                        CreatedAt = DateTime.Now
                    };

                    // Thêm dịch vụ vào cơ sở dữ liệu
                    bool isAdded = _bookingRepository.AddBookingService(bookingService);
                    if (!isAdded)
                    {
                        errorMessage = "Failed to add service to booking.";
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"An error occurred: {ex.Message}";
                return false;
            }
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
