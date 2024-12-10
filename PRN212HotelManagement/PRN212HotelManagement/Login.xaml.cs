using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;
using Microsoft.Win32;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly UserService _userService;

        public Login()
        {
            InitializeComponent();
            var context = new Prn212hotelManagementContext();
            var userRepository = new UserRepository(context);
            _userService = new UserService(userRepository);
        }

        private void textAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtAccount.Focus();
        }

        private void txtAccount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccount.Text) && txtAccount.Text.Length > 0)
            {
                textAccount.Visibility = Visibility.Visible;
            }
            else
            {
                textAccount.Visibility = Visibility.Collapsed;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }


        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtAccount.Text;
            string password = txtPassword.Password;

            string role = _userService.Login(username, password);

            if (role == "Invalid")
            {
                MessageBox.Show("Invalid username or password.", "Login Fail !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show($"Signed in as {role}.", "Login Success", MessageBoxButton.OK, MessageBoxImage.Information);
                switch (role)
                {
                    case "Admin":
                        //Open Admin WPF
                        User currentUser = _userService.GetUserByUsername(username);
                        AdminWPF adminWPF = new AdminWPF(currentUser);
                        ManageRooms manageRooms = new ManageRooms(currentUser);
                        ManageUsers manageUsers = new ManageUsers(currentUser); 
                        adminWPF.Show();
                        break;
                    case "Staff":
                        //Open Staff WPF
                        StaffWPF staffWPF = new StaffWPF();
                        staffWPF.Show();
                        break;
                }
            }

            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register(_userService);
            registerWindow.Show();
            this.Close();
        }
        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, new RoutedEventArgs());
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, new RoutedEventArgs());
            }
        }

    }
}
