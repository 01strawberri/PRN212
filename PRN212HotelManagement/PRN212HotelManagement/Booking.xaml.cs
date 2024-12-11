using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PRN212HotelManagement
{
    public partial class Booking : Window
    {
        private readonly BookingServices _bookingService;
        private readonly UserService _userService;
        private readonly RoomService _roomService;
        private User currentUser;

        private Booking _currentBooking;
        private List<User> _users;
        private List<Room> _rooms;

        public Booking(User user)
        {
            InitializeComponent();
            currentUser = user;
            cboSearchBookingStatus.SelectedIndex = 0; 
            LoadBookings(); 
        }

        private void LoadBookings()
        {
            try
            {
                using (var context = new Prn212hotelManagementContext())
                {
                    var query = context.Bookings
                        .Include(b => b.User)
                        .Include(b => b.Room)
                        .AsQueryable();

                    if (!string.IsNullOrWhiteSpace(txtSearchUserName.Text))
                    {
                        query = query.Where(b => b.User.UserName.ToLower().Contains(txtSearchUserName.Text.ToLower()));
                    }

                    if (!string.IsNullOrWhiteSpace(txtSearchRoomName.Text))
                    {
                        query = query.Where(b => b.Room.RoomName.ToLower().Contains(txtSearchRoomName.Text.ToLower()));
                    }

                    if (cboSearchBookingStatus.SelectedIndex > 0)
                    {
                        string selectedStatus = ((ComboBoxItem)cboSearchBookingStatus.SelectedItem).Content.ToString();
                        query = query.Where(b => b.BookingStatus == selectedStatus);
                    }

                    var bookings = query.ToList();
                    dataGridBookings.ItemsSource = bookings;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtSearchUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadBookings();
        }

        private void txtSearchRoomName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadBookings();
        }

        private void cboSearchBookingStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadBookings();
        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            _currentBooking = null;
            popupGrid.Visibility = Visibility.Visible;
        }

        private void btnEditBooking_Click(object sender, RoutedEventArgs e)
        {
            //if (dataGridBookings.SelectedItem is Booking selectedBooking)
            //{
            //    _currentBooking = selectedBooking;

            //    comboUserName.SelectedValue = _currentBooking.comboUserName.Text;

            //}
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            StaffWPF staffProfile = new StaffWPF(currentUser);
            staffProfile.Show();
            this.Close();
        }

        private void btn_Rooms_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            Booking bookingWindow = new Booking(currentUser);
            bookingWindow.Show();
            this.Close();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridBookings.SelectedItem is HotelManagement_DAL.Booking selectedBooking)
            {
                // Tạo các repository cần thiết
                var context = new Prn212hotelManagementContext();
                var bookingRepository = new BookingRepository(context);
                var userRepository = new UserRepository(context);
                var roomRepository = new RoomRepository(context);

                // Tạo BookingServices với các repository
                var bookingServices = new BookingServices(bookingRepository, userRepository, roomRepository);

                // Truyền BookingId và BookingServices vào BookingDetail
                BookingDetail detailWindow = new BookingDetail(selectedBooking.BookingId, bookingServices);
                detailWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a booking to view details.", "No Booking Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
