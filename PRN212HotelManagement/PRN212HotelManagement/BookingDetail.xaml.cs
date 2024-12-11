using System.Linq;
using System.Windows;
using HotelManagement_BLL;
using HotelManagement_DAL;

namespace PRN212HotelManagement
{
    public partial class BookingDetail : Window
    {
        private readonly BookingServices _bookingServices;

        public BookingDetail(int bookingId, BookingServices bookingServices)
        {
            InitializeComponent();
            _bookingServices = bookingServices;
            LoadBookingDetails(bookingId);
        }

        private void LoadBookingDetails(int bookingId)
        {
            // Lấy thông tin booking
            var booking = _bookingServices.GetBookingDetails(bookingId);

            if (booking == null)
            {
                MessageBox.Show("Booking not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            // Tạo dữ liệu hiển thị bao gồm Booking và các Service liên quan
            var bookingDetails = booking.BookingServices.Select(bs => new
            {
                BookingId = booking.BookingId,
                UserName = booking.User.UserName,
                RoomName = booking.Room.RoomName,
                BookingType = booking.BookingType,
                BookingStatus = booking.BookingStatus,
                BookingStartDay = booking.BookingStartDay.ToDateTime(new TimeOnly(0, 0)),
                BookingEndDay = booking.BookingEndDay.ToDateTime(new TimeOnly(0, 0)),
                TotalPrice = booking.TotalPrice,
                ServiceName = bs.Service.ServiceName,
                ServicePrice = bs.Service.ServicePrice
            }).ToList();

            // Gán dữ liệu vào DataGrid
            dataGridBookingDetails.ItemsSource = bookingDetails;
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
