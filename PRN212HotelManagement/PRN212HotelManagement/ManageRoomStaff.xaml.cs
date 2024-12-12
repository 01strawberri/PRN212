using HotelManagement_BLL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;
using HotelManagement_DAL;
using System.Windows;
using System.Windows.Controls;
namespace PRN212HotelManagement
{
    public partial class ManageRoomStaff : Window
    {
        private readonly RoomService _roomService;
        private List<Room> _rooms;
        private User currentUser;

        public ManageRoomStaff(User user)
        {
            InitializeComponent();
            currentUser = user;
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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridRooms.SelectedItem is Room selectedRoom)
            {
                ComboBox comboBox = sender as ComboBox;
                if (comboBox != null && comboBox.SelectedItem is ComboBoxItem selectedItem)
                {
                    string newStatus = selectedItem.Content.ToString();

                    // Confirm before updating status
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to update room status?", "Confirmation", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    selectedRoom.RoomStatus = newStatus;

                    bool resultUp = _roomService.UpdateRoom(selectedRoom.RoomId, selectedRoom.RoomName, selectedRoom.RoomType, selectedRoom.RoomStatus, selectedRoom.RoomDescription);

                    if (resultUp)
                    {
                        MessageBox.Show("Room status updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update room status");
                    }

                    // Refresh the data grid
                    LoadData();
                }
            }
        }


        private void btnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRooms.SelectedItem is Room selectedRoom)
            {
                // Change the status of the selected room
                selectedRoom.RoomStatus = selectedRoom.RoomStatus == "Available" ? "Occupied" : "Available";

                // Update the room status in the database

                //Confirm before update status
                MessageBoxResult result = MessageBox.Show("Are you sure you want to update room status?", "Confirmation", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.No)
                {
                    return;
                }

                bool resultUp = _roomService.UpdateRoom(selectedRoom.RoomId, selectedRoom.RoomName, selectedRoom.RoomType, selectedRoom.RoomStatus, selectedRoom.RoomDescription);

                if (resultUp)
                {
                    MessageBox.Show("Room status updated successfully");
                }
                else
                {
                    MessageBox.Show("Failed to update room status");
                }
                // Refresh the data grid
                LoadData();
            }
        }

        private void btn_Account_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Profile
        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Bookings
        }

        private void btn_ManageRoom_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Manage Rooms
        }

        private void btn_ManageUser_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Manage Users
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            // Handle logout
        }

        private void dataGridRooms_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle selection changed logic if needed
        }

        private void txtSearchRoomStatus_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}