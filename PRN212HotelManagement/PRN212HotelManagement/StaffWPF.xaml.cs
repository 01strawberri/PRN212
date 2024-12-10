using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
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
    /// Interaction logic for StaffWPF.xaml
    /// </summary>
    public partial class StaffWPF : Window
    {
        private User currentUser;

        public StaffWPF(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadProfileData();
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            StaffWPF staffProfile = new StaffWPF(currentUser);
            staffProfile.Show();
            this.Close();
        }

        private void btn_Rooms_Click(object sender, RoutedEventArgs e)
        {
            // Add room management functionality for staff
            // RoomList roomList = new RoomList(currentUser);
            // roomList.Show();
            // this.Close();
        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            Booking bookingWindow = new Booking();
            bookingWindow.Show();
            this.Close();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void LoadProfileData()
        {
            try
            {
                if (currentUser != null)
                {
                    txt_ProfileName.Text = $"STAFF: {currentUser.UserName}";
                    txtUsername.Text = currentUser.UserName ?? "N/A";
                    txtEmail.Text = currentUser.UserEmail ?? "N/A";
                    txtPhone.Text = currentUser.UserPhone ?? "N/A";
                    txtRole.Text = "STAFF";
                }
                else
                {
                    MessageBox.Show("Error: Unable to load user profile data.", "Profile Error", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading profile: {ex.Message}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var passwordDialog = new Window
            {
                Title = "Change Password",
                Width = 300,
                Height = 250,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                ResizeMode = ResizeMode.NoResize
            };

            var stackPanel = new StackPanel { Margin = new Thickness(10) };
            var oldPasswordBox = new PasswordBox { Margin = new Thickness(0, 5, 0, 5) };
            var newPasswordBox = new PasswordBox { Margin = new Thickness(0, 5, 0, 5) };
            var confirmPasswordBox = new PasswordBox { Margin = new Thickness(0, 5, 0, 5) };

            var buttonPanel = new StackPanel 
            { 
                Orientation = Orientation.Horizontal, 
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };

            var okButton = new Button
            {
                Content = "OK",
                Width = 80,
                Margin = new Thickness(0, 0, 10, 0),
                Padding = new Thickness(5)
            };

            var cancelButton = new Button
            {
                Content = "Cancel",
                Width = 80,
                Padding = new Thickness(5)
            };

            stackPanel.Children.Add(new TextBlock { Text = "Current Password:" });
            stackPanel.Children.Add(oldPasswordBox);
            stackPanel.Children.Add(new TextBlock { Text = "New Password:" });
            stackPanel.Children.Add(newPasswordBox);
            stackPanel.Children.Add(new TextBlock { Text = "Confirm New Password:" });
            stackPanel.Children.Add(confirmPasswordBox);
            
            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);
            stackPanel.Children.Add(buttonPanel);

            okButton.Click += (s, args) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(oldPasswordBox.Password) ||
                        string.IsNullOrEmpty(newPasswordBox.Password) ||
                        string.IsNullOrEmpty(confirmPasswordBox.Password))
                    {
                        MessageBox.Show("Please fill in all password fields.", "Validation Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (newPasswordBox.Password != confirmPasswordBox.Password)
                    {
                        MessageBox.Show("New passwords do not match.", "Validation Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    using (var context = new Prn212hotelManagementContext())
                    {
                        var user = context.Users.FirstOrDefault(u => u.UserId == currentUser.UserId);
                        if (user != null && user.UserPassword == oldPasswordBox.Password)
                        {
                            user.UserPassword = newPasswordBox.Password;
                            context.SaveChanges();
                            currentUser.UserPassword = newPasswordBox.Password;
                            MessageBox.Show("Password changed successfully!", "Success",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            passwordDialog.Close();
                        }
                        else
                        {
                            MessageBox.Show("Current password is incorrect.", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while changing password: {ex.Message}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            };

            cancelButton.Click += (s, args) => passwordDialog.Close();

            passwordDialog.Content = stackPanel;
            passwordDialog.ShowDialog();
        }

        private void btn_ChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            // Copy the email change implementation from AdminWPF
        }

        private void btn_ChangePhone_Click(object sender, RoutedEventArgs e)
        {
            // Copy the phone change implementation from AdminWPF
        }
    }
}
