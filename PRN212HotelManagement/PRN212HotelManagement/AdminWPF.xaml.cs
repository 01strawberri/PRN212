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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadProfileData();
        }

        private void btn_ManageRoom_Click(object sender, RoutedEventArgs e)
        {
            // Handle Manage Room button click
            // Add your room management page navigation here
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

       
    }
}
