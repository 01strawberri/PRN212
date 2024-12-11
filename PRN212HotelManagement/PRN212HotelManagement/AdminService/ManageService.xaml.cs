using HotelManagement_DAL;
using HotelManagement_BLL;
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
using System.Collections.ObjectModel;
using PRN212HotelManagement.AdminService;

namespace PRN212HotelManagement
{
    /// <summary>
    /// Interaction logic for ManageService.xaml
    /// </summary>
    public partial class ManageService : Window
    {
        private readonly ServicesService _services; // Service layer to interact with data
        private ObservableCollection<Service> services; // ObservableCollection for binding to DataGrid

        public ManageService()
        {

            InitializeComponent(); 

            services = new ObservableCollection<Service>();
            _services = new ServicesService();

            // Load the services into the ObservableCollection and bind to DataGrid
            LoadServices();
        }

        // Method to load services from database into the ObservableCollection
        private void LoadServices()
        {
            try
            {
                // Clear the existing collection
                services.Clear();

                // Retrieve services from the database
                var loadedServices = _services.GetServices();

                // Add services to the ObservableCollection
                foreach (var service in loadedServices)
                {
                    services.Add(service);
                }

                // Bind the ObservableCollection to the DataGrid
                ServicesDataGrid.ItemsSource = services;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Load Error");
            }
        }

        // Event handler for adding a new service
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            // Open the AddServiceWindow
            var addServiceWindow = new AddServices();

            if (addServiceWindow.ShowDialog() == true) // If the dialog returns true
            {
                var newService = addServiceWindow.NewService;

                if (newService != null)
                {
                    try
                    {
                        // Add the new service to the database
                        _services.AddService(newService);

                        // Add the new service to the ObservableCollection
                        services.Add(newService);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding service: {ex.Message}", "Add Error");
                    }
                }
            }
        }

        private void EditService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem is Service selectedService)
            {
                // Open the EditService window with the selected service
                var editServiceWindow = new EditService(selectedService);

                if (editServiceWindow.ShowDialog() == true) // Wait for Save confirmation
                {
                    try
                    {
                        // Call the UpdateService method with the updated service
                        _services.UpdateService(editServiceWindow.EditedService);

                        // Refresh the DataGrid
                        LoadServices();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating service: {ex.Message}", "Update Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a service to edit.", "Edit Error");
            }
        }

            // Event handler for deleting a service
            private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem is Service selectedService)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the service '{selectedService.ServiceName}'?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Delete the service from the database
                        _services.DeleteService(selectedService.ServiceId);

                        // Remove the service from the ObservableCollection
                        services.Remove(selectedService);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting service: {ex.Message}", "Delete Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a service to delete.", "Delete Error");
            }
        }
    }
}
