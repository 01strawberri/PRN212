using System.Linq;
using System.Windows;
using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;

namespace PRN212HotelManagement
{
    public partial class ViewBookingForAdmin : Window
    {
        private readonly BookingServices _bookingService;
        private readonly User currentUser;

        public ViewBookingForAdmin(User user)
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

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            AdminWPF account = new AdminWPF(currentUser);
            account.Show();
            this.Close();
        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            ViewBookingForAdmin bookingWindow = new ViewBookingForAdmin(currentUser);
            bookingWindow.Show();
            this.Close();
        }

        private void btn_ManageRoom_Click(object sender, RoutedEventArgs e)
        {
            ManageRooms manageRoomsWindow = new ManageRooms(currentUser);
            manageRoomsWindow.Show();
            this.Close();
        }

        private void btn_ManageUser_Click(object sender, RoutedEventArgs e)
        {
            ManageUsers manageUsersWindow = new ManageUsers(currentUser);
            manageUsersWindow.Show();
            this.Close();
        }

        private void btn_ManageService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Transaction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWPF account = new AdminWPF(currentUser);
            account.Show();
            this.Close();
        }
    }
}
