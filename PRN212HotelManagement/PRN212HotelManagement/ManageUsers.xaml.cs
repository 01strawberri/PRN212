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
    /// Interaction logic for ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : Window
    {
        private UserService _userService;
        private User _currentUser;
        private User currentUser;
        public ManageUsers(User user)
        {
            InitializeComponent();
            currentUser = user;
            var context = new Prn212hotelManagementContext();
            var userRepository = new UserRepository(context);
            _userService = new UserService(userRepository);
            LoadUsers();
        }
        private void LoadUsers()
        {
            var users = _userService.GetAllUsers();
            dataGridUsers.ItemsSource = users;
        }
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            _currentUser = null;
            ShowPopup();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsers.SelectedItem is User selectedUser)
            {
                _currentUser = selectedUser;
                ShowPopup();
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "Edit User", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsers.SelectedItem is User selectedUser)
            {
                if (MessageBox.Show($"Are you sure you want to delete {selectedUser.UserName}?", "Delete User", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _userService.DeleteUser(selectedUser.UserId);
                    LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Delete User", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ShowPopup()
        {
            if (_currentUser != null)
            {
                txtUsername.Text = _currentUser.UserName;
                txtEmail.Text = _currentUser.UserEmail;
                txtPhone.Text = _currentUser.UserPhone;
                txtPassword.Password = _currentUser.UserPassword;
            }
            else
            {
                txtUsername.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtPassword.Clear();
            }
            popupGrid.Visibility = Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser == null)
            {
                _currentUser = new User
                {
                    UserName = txtUsername.Text,
                    UserEmail = txtEmail.Text,
                    UserPassword = txtPassword.Password,
                    UserPhone = txtPhone.Text,
                    UserRole = 2, // Default role for new users
                    CreatedAt = DateTime.Now
                };

                if (_userService.Register(_currentUser.UserEmail, _currentUser.UserName, _currentUser.UserPassword, _currentUser.UserPhone))
                {
                    MessageBox.Show("User added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadUsers();
                    popupGrid.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("User already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                _currentUser.UserName = txtUsername.Text;
                _currentUser.UserEmail = txtEmail.Text;
                _currentUser.UserPassword = txtPassword.Password;
                _currentUser.UserPhone = txtPhone.Text;

                if (_userService.UpdateUser(_currentUser))
                {
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadUsers();
                    popupGrid.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Error updating user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            Booking manageRooms = new Booking();
            manageRooms.Show();
            this.Close();
        }

        private void btn_ManageUser_Click(object sender, RoutedEventArgs e)
        {
            ManageUsers manageUsersWindow = new ManageUsers(currentUser);
            manageUsersWindow.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            popupGrid.Visibility = Visibility.Collapsed;
        }
    }
}
