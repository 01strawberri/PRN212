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
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;

namespace PRN212HotelManagement
{
    /// <summary>
    /// Interaction logic for ManageService.xaml
    /// </summary>
    public partial class ManageService : Window
    {
        private readonly ServicesService _services; 
        private ObservableCollection<Service> services; 

        public ManageService()
        {

            InitializeComponent(); 

            services = new ObservableCollection<Service>();
            _services = new ServicesService(new ServiceRepository(new Prn212hotelManagementContext()));

            LoadServices();
        }

        private void LoadServices()
        {
            try
            {

                services.Clear();

                var loadedServices = _services.GetServices();

                foreach (var service in loadedServices)
                {
                    services.Add(service);
                }
                ServicesDataGrid.ItemsSource = services;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Load Error");
            }
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            var addServiceWindow = new AddServices();

            if (addServiceWindow.ShowDialog() == true) 
            {
                var newService = addServiceWindow.NewService;

                if (newService != null)
                {
                    try
                    {
                        _services.AddService(newService);

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
                var editServiceWindow = new EditService(selectedService);

                if (editServiceWindow.ShowDialog() == true) 
                {
                    try
                    {
                        _services.UpdateService(editServiceWindow.EditedService);
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
                        _services.DeleteService(selectedService.ServiceId);

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
