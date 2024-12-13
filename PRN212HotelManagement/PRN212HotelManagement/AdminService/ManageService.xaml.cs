using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PRN212HotelManagement
{
    public partial class ManageService : Window
    {
        private readonly ServicesService _serviceService;
        private List<Service> _services;
        private Service _selectedServiceForEdit;
        private User currentUser;


        public ManageService()
        {
            InitializeComponent();
            _serviceService = new ServicesService(new ServiceRepository(new Prn212hotelManagementContext()));
            LoadData();
        }

        private void LoadData()
        {
            _services = _serviceService.GetServices();
            dataGridServices.ItemsSource = _services;
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            // Clear popup fields
            txtServiceName.Text = "";
            txtServiceType.Text = "";
            txtServiceDescription.Text = "";
            txtServicePrice.Text = "";
            cmbServiceStatus.SelectedIndex = 0; // Default to "Available"
            _selectedServiceForEdit = null; // Reset edit object

            popupGrid.Visibility = Visibility.Visible;
        }

        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridServices.SelectedItem is Service selectedService)
            {
                _selectedServiceForEdit = selectedService;

                // Fill popup fields with the selected service's data
                txtServiceName.Text = selectedService.ServiceName;
                txtServiceType.Text = selectedService.ServiceType;
                txtServiceDescription.Text = selectedService.ServiceDescription;
                txtServicePrice.Text = selectedService.ServicePrice.ToString("F2");
                cmbServiceStatus.SelectedItem = selectedService.ServiceStatus;

                popupGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please select a service to edit.", "No Service Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridServices.SelectedItem is Service selectedService)
            {
                var result = MessageBox.Show("Are you sure you want to delete this service?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    bool isDeleted = _serviceService.DeleteService(selectedService.ServiceId);
                    if (isDeleted)
                    {
                        MessageBox.Show("Service deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the service.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a service to delete.", "No Service Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSaveService_Click(object sender, RoutedEventArgs e)
        {
            // Validate fields
            if (string.IsNullOrWhiteSpace(txtServiceName.Text) ||
                string.IsNullOrWhiteSpace(txtServiceType.Text) ||
                string.IsNullOrWhiteSpace(txtServiceDescription.Text) ||
                string.IsNullOrWhiteSpace(txtServicePrice.Text) ||
                cmbServiceStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(txtServicePrice.Text, out decimal servicePrice))
            {
                MessageBox.Show("Invalid price format.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string serviceName = txtServiceName.Text.Trim();
            string serviceType = txtServiceType.Text.Trim();
            string serviceDescription = txtServiceDescription.Text.Trim();
            string serviceStatus = (cmbServiceStatus.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (_selectedServiceForEdit == null) // Add new service
            {
                var newService = new Service
                {
                    ServiceName = serviceName,
                    ServiceType = serviceType,
                    ServiceDescription = serviceDescription,
                    ServicePrice = servicePrice,
                    ServiceStatus = serviceStatus
                };

                bool isAdded = _serviceService.AddService(newService);
                if (isAdded)
                {
                    MessageBox.Show("Service added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    popupGrid.Visibility = Visibility.Collapsed;
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to add service.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else // Update existing service
            {
                _selectedServiceForEdit.ServiceName = serviceName;
                _selectedServiceForEdit.ServiceType = serviceType;
                _selectedServiceForEdit.ServiceDescription = serviceDescription;
                _selectedServiceForEdit.ServicePrice = servicePrice;
                _selectedServiceForEdit.ServiceStatus = serviceStatus;

                bool isUpdated = _serviceService.UpdateService(_selectedServiceForEdit);
                if (isUpdated)
                {
                    MessageBox.Show("Service updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    popupGrid.Visibility = Visibility.Collapsed;
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to update service.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void btnCancelService_Click(object sender, RoutedEventArgs e)
        {
            // Close the popup without saving changes
            popupGrid.Visibility = Visibility.Collapsed;
        }

        private void btn_Account_Click(object sender, RoutedEventArgs e)
        {
            AdminWPF account = new AdminWPF(currentUser);
            account.Show();
            this.Close();
        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            ViewBookingForAdmin viewBookingForAdmin = new ViewBookingForAdmin(currentUser);
            viewBookingForAdmin.Show();
            this.Close();
        }

        private void btn_ManageRoom_Click(object sender, RoutedEventArgs e)
        {
            ManageRooms manageRooms = new ManageRooms(currentUser);
            manageRooms.Show();
            this.Close();
        }

        private void btn_ManageUser_Click(object sender, RoutedEventArgs e)
        {
            ManageUsers manageUsersWindow = new ManageUsers(currentUser);
            manageUsersWindow.Show();
            this.Close();
        }

        private void btn_Transaction_Click(object sender, RoutedEventArgs e)
        {
            TransactionWindow transactionWindow = new TransactionWindow();
            transactionWindow.Show();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
    }
}
