using System.Linq;
using System.Windows;
using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;

namespace PRN212HotelManagement
{
    public partial class ViewBookingForStaff : Window
    {
        private readonly BookingServices _bookingService;
        private readonly User currentUser;

        public ViewBookingForStaff(User user)
        {
            currentUser = user;
            InitializeComponent();
            _bookingService = new BookingServices(
                new BookingRepository(new Prn212hotelManagementContext()),
                new UserRepository(new Prn212hotelManagementContext()),
                new RoomRepository(new Prn212hotelManagementContext())
            );
            LoadBookings();
        }

        private void LoadBookings()
        {
            // Load all bookings
            var bookings = _bookingService.GetAllBookings();
            dataGridBookings.ItemsSource = bookings;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string status = txtSearchStatus.Text.Trim();

            if (!string.IsNullOrEmpty(status))
            {
                var filteredBookings = _bookingService.GetBookingsByStatus(status);
                dataGridBookings.ItemsSource = filteredBookings;
            }
            else
            {
                LoadBookings();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the previous window
            StaffWPF staffProfile = new StaffWPF(currentUser);
            staffProfile.Show();
            this.Close();
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            StaffWPF staffProfile = new StaffWPF(currentUser);
            staffProfile.Show();
            this.Close();
        }

        private void btn_Rooms_Click(object sender, RoutedEventArgs e)
        {
            ManageRooms roomWindow = new ManageRooms(currentUser);
            roomWindow.Show();
            this.Close();
        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            Booking bookingWindow = new Booking(currentUser);
            bookingWindow.Show();
            this.Close();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
