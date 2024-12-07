using System;
using System.Linq;
using System.Windows;
using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;

namespace PRN212HotelManagement
{
    public partial class Booking : Window
    {
        private readonly BookingServices _bookingService;
        private readonly UserService _userService;
        private readonly RoomService _roomService;

        private Booking _currentBooking;
        private List<User> _users;
        private List<Room> _rooms;

        public Booking()
        {
            InitializeComponent();
            _bookingService = new BookingServices(new BookingRepository(new Prn212hotelManagementContext()), new UserRepository(new Prn212hotelManagementContext()), new RoomRepository(new Prn212hotelManagementContext()));
            _userService = new UserService(new UserRepository(new Prn212hotelManagementContext()));
            _roomService = new RoomService(new RoomRepository(new Prn212hotelManagementContext()));
            LoadData();
        }

        private void LoadData()
        {
            var bookings = _bookingService.GetAllBookings();
            dataGridBookings.ItemsSource = bookings;

            _users = _userService.GetAllUsers();
            comboUserName.ItemsSource = _users;
            comboUserName.DisplayMemberPath = "UserName"; 
            comboUserName.SelectedValuePath = "UserId";

            _rooms = _roomService.GetAllRooms();
            comboRoomName.ItemsSource = _rooms;
            comboRoomName.DisplayMemberPath = "RoomName"; 
            comboRoomName.SelectedValuePath = "RoomId";
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
    }
}
