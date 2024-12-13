using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PRN212HotelManagement
{
    public partial class ViewRoom : Window
    {
        private readonly RoomService _roomService;
        private List<Room> _rooms;
        private User currentUser;

        public ViewRoom()
        {
            InitializeComponent();
            _roomService = new RoomService(new RoomRepository(new Prn212hotelManagementContext()));
            LoadData();
        }

        private void LoadData()
        {
            _rooms = _roomService.getAllRoomsByPrices();
            dataGridRooms.ItemsSource = _rooms;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var roomName = txtSearchRoomName.Text;
            var roomType = txtSearchRoomType.Text;
            var roomStatus = (cmbSearchRoomStatus.SelectedItem as ComboBoxItem)?.Content.ToString();

            var filteredRooms = _rooms.Where(r =>
                (string.IsNullOrEmpty(roomName) || r.RoomName.Contains(roomName)) &&
                (string.IsNullOrEmpty(roomType) || r.RoomType.Contains(roomType)) &&
                (roomStatus == "All" || string.IsNullOrEmpty(roomStatus) || r.RoomStatus == roomStatus)
            ).ToList();

            dataGridRooms.ItemsSource = filteredRooms;
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            StaffWPF staffProfile = new StaffWPF(currentUser);
            staffProfile.Show();
            this.Close();
        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            BookingView viewBookingForStaff = new BookingView(currentUser);
            viewBookingForStaff.Show();
            this.Close();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
