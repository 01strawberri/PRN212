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
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using Microsoft.Identity.Client.NativeInterop;

namespace PRN212HotelManagement
{
    /// <summary>
    /// Interaction logic for AdminWPF.xaml
    /// </summary>
    public partial class AdminWPF : Window
    {
        private User currentUser;

        public AdminWPF(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            try
            {
                if (currentUser != null)
                {
                    txt_ProfileName.Text = $"ADMIN: {currentUser.UserName}";
                    txtUsername.Text = currentUser.UserName ?? "N/A";
                    txtEmail.Text = currentUser.UserEmail ?? "N/A";
                    txtPhone.Text = currentUser.UserPhone ?? "N/A";
                    txtRole.Text = "ADMIN";
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
                    if (oldPasswordBox.Password == newPasswordBox.Password)
                    {
                        MessageBox.Show("Duplicate password.", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
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
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_ManageRoom_Click(object sender, RoutedEventArgs e)
        {
            ManageRooms manageRooms = new ManageRooms(currentUser);
            manageRooms.Show();
            this.Close();
        }

        private void btn_Transaction_Click(object sender, RoutedEventArgs e)
        {
            TransactionWindow transactionWindow = new TransactionWindow();
            transactionWindow.Show();
        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            ViewBookingForAdmin viewBookingForAdmin = new ViewBookingForAdmin(currentUser);
            viewBookingForAdmin.Show();
            this.Close();
        }
         
        private void btn_ManageUser_Click(object sender, RoutedEventArgs e)
        {
            ManageUsers manageUsersWindow = new ManageUsers(currentUser);
            manageUsersWindow.Show();
            this.Close();
        }

        private void btn_ChangePhone_Click(object sender, RoutedEventArgs e)
        {
            var phoneDialog = new Window
            {
                Title = "Change Phone Number",
                Width = 300,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                ResizeMode = ResizeMode.NoResize
            };

            var stackPanel = new StackPanel { Margin = new Thickness(10) };
            var newPhoneBox = new TextBox 
            { 
                Margin = new Thickness(0, 5, 0, 5),
                Text = currentUser.UserPhone // Pre-fill with current phone
            };

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

            stackPanel.Children.Add(new TextBlock { Text = "New Phone Number:" });
            stackPanel.Children.Add(newPhoneBox);
            
            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);
            stackPanel.Children.Add(buttonPanel);

            okButton.Click += (s, args) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(newPhoneBox.Text))
                    {
                        MessageBox.Show("Please enter a phone number.", "Validation Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Validate phone number format (you can modify this regex pattern as needed)
                    if (!System.Text.RegularExpressions.Regex.IsMatch(newPhoneBox.Text, @"^\d{10}$"))
                    {
                        MessageBox.Show("Please enter a valid 10-digit phone number.", "Validation Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    using (var context = new Prn212hotelManagementContext())
                    {
                        var user = context.Users.FirstOrDefault(u => u.UserId == currentUser.UserId);
                        if (user != null)
                        {
                            user.UserPhone = newPhoneBox.Text;
                            context.SaveChanges();
                            currentUser.UserPhone = newPhoneBox.Text;
                            txtPhone.Text = newPhoneBox.Text; // Update the display
                            MessageBox.Show("Phone number updated successfully!", "Success",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            phoneDialog.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating phone number: {ex.Message}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            };

            cancelButton.Click += (s, args) => phoneDialog.Close();

            phoneDialog.Content = stackPanel;
            phoneDialog.ShowDialog();
        }

        private void btn_ChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            var emailDialog = new Window
            {
                Title = "Change Email",
                Width = 300,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                ResizeMode = ResizeMode.NoResize
            };

            var stackPanel = new StackPanel { Margin = new Thickness(10) };
            var newEmailBox = new TextBox 
            { 
                Margin = new Thickness(0, 5, 0, 5),
                Text = currentUser.UserEmail 
            };

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

            stackPanel.Children.Add(new TextBlock { Text = "New Email Address:" });
            stackPanel.Children.Add(newEmailBox);
            
            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);
            stackPanel.Children.Add(buttonPanel);

            okButton.Click += (s, args) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(newEmailBox.Text))
                    {
                        MessageBox.Show("Please enter an email address.", "Validation Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // email format
                    if (!System.Text.RegularExpressions.Regex.IsMatch(newEmailBox.Text, 
                        @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    {
                        MessageBox.Show("Please enter a valid email address.", "Validation Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    using (var context = new Prn212hotelManagementContext())
                    {
                        // Check if email already exists for another user
                        var existingUser = context.Users.FirstOrDefault(u => 
                            u.UserEmail == newEmailBox.Text && u.UserId != currentUser.UserId);
                        
                        if (existingUser != null)
                        {
                            MessageBox.Show("This email is already in use by another user.", 
                                "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        var user = context.Users.FirstOrDefault(u => u.UserId == currentUser.UserId);
                        if (user != null)
                        {
                            user.UserEmail = newEmailBox.Text;
                            context.SaveChanges();
                            currentUser.UserEmail = newEmailBox.Text;
                            txtEmail.Text = newEmailBox.Text;
                            MessageBox.Show("Email updated successfully!", "Success",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            emailDialog.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating email: {ex.Message}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            };

            cancelButton.Click += (s, args) => emailDialog.Close();

            emailDialog.Content = stackPanel;
            emailDialog.ShowDialog();
        }

        private void btn_ManageService_Click(object sender, RoutedEventArgs e)
        {
            ManageService manageServiceWindow = new ManageService();
            manageServiceWindow.Show();
            this.Close();
        }
    }
}
