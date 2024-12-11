using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PRN212HotelManagement
{
    /// <summary>
    /// Interaction logic for ManageRooms.xaml
    /// </summary>
    public partial class ManageRooms : Window
    {
        private RoomService _roomService;
        private List<Room> _rooms;
        private User currentUser;

        public ManageRooms(User user)
        {
            InitializeComponent();
            currentUser = user;
            InitializeComponent();
            _roomService = new RoomService(new RoomRepository(new Prn212hotelManagementContext()));
            LoadRooms();
        }
        

        private void LoadRooms()
        {
            _rooms = _roomService.GetAllRooms();
            dataGridRooms.ItemsSource = _rooms;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string roomName = txtSearchRoomName.Text.Trim();
            string roomType = txtSearchRoomType.Text.Trim();
            string roomStatus = txtSearchRoomStatus.Text.Trim();

            var filteredRooms = _roomService.SearchRooms(roomName, roomType, roomStatus); //Search room by 3 fields
            dataGridRooms.ItemsSource = filteredRooms; //Show rooms
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            popupGrid.Visibility = Visibility.Visible;
            ClearPopupFields(); //Clear all fields in popup
        }
        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRooms.SelectedItem is Room selectedRoom)
            {
                txtRoomName.Text = selectedRoom.RoomName;
                txtRoomType.Text = selectedRoom.RoomType;
                txtRoomDescription.Text = selectedRoom.RoomDescription;
                txtRoomStatus.Text = selectedRoom.RoomStatus;

                popupGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please select a room to edit.");
            }
        }
        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRooms.SelectedItem is Room selectedRoom)
            {
                var result = MessageBox.Show($"Are you sure you want to delete room {selectedRoom.RoomName}?", "Delete Room", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    bool isDeleted = _roomService.DeleteRoom(selectedRoom.RoomId); // Delete room
                    if (isDeleted)
                    {
                        MessageBox.Show("Room deleted successfully.");
                        LoadRooms(); //Update list of rooms
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete room.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to delete.");
            }
        }
        private void btnSaveRoom_Click(object sender, RoutedEventArgs e)
        {
            string roomName = txtRoomName.Text.Trim();
            string roomType = txtRoomType.Text.Trim();
            string roomDescription = txtRoomDescription.Text.Trim();
            string roomStatus = txtRoomStatus.Text.Trim();

            if (string.IsNullOrEmpty(roomName) || string.IsNullOrEmpty(roomType) || string.IsNullOrEmpty(roomStatus))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (txtRoomName.Tag == null)  //Check if the do not have value, so it is Add room
            {
                bool isAdded = _roomService.AddRoom(roomName, roomType, roomStatus, roomDescription);
                if (isAdded)
                {
                    MessageBox.Show("Room added successfully.");
                    LoadRooms();
                    popupGrid.Visibility = Visibility.Collapsed; //Hide popup
                }
                else
                {
                    MessageBox.Show("Failed to add room.");
                }
            }
            else  //If has value, it is update
            {
                int roomId = (int)txtRoomName.Tag;
                bool isUpdated = _roomService.UpdateRoom(roomId, roomName, roomType, roomStatus, roomDescription);

                if (isUpdated)
                {
                    MessageBox.Show("Room updated successfully.");
                    LoadRooms();
                    popupGrid.Visibility = Visibility.Collapsed; //Hide popup
                }
                else
                {
                    MessageBox.Show("Failed to update room.");
                }
            }
        }

        private void btn_Account_Click(object sender, RoutedEventArgs e)
        {
            AdminWPF account = new AdminWPF(currentUser);
            account.Show();
            this.Close();
        }
        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void btn_ManageRoom_Click(object sender, RoutedEventArgs e)
        {
            ManageRooms manageRooms = new ManageRooms(currentUser);
            manageRooms.Show();
            this.Close();
        }


        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_ManageUser_Click(object sender, RoutedEventArgs e)
        {
            ManageUsers manageUsersWindow = new ManageUsers(currentUser);
            manageUsersWindow.Show();
            this.Close();
        }

        //Cancel in popup
        private void btnCancelRoom_Click(object sender, RoutedEventArgs e)
        {
            popupGrid.Visibility = Visibility.Collapsed; //Hide popup
        }
        private void ClearPopupFields()
        {
            txtRoomName.Clear();
            txtRoomType.Clear();
            txtRoomDescription.Clear();
            txtRoomStatus.Clear();
            txtRoomName.Tag = null; 
        }
    }
}
