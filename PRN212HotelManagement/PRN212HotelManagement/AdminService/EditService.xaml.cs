using HotelManagement_DAL;
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

namespace PRN212HotelManagement.AdminService
{
    /// <summary>
    /// Interaction logic for EditService.xaml
    /// </summary>
    public partial class EditService : Window
    {
        public Service EditedService { get; private set; }
        public EditService(Service serviceToEdit)
        {
            InitializeComponent();

            // Populate fields with existing data
            ServiceTypeTextBox.Text = serviceToEdit.ServiceType;
            ServiceNameTextBox.Text = serviceToEdit.ServiceName;
            ServiceDescriptionTextBox.Text = serviceToEdit.ServiceDescription;
            ServicePriceTextBox.Text = serviceToEdit.ServicePrice.ToString();
            ServiceStatusComboBox.SelectedItem = serviceToEdit.ServiceStatus;
            
            // Set the EditedService as a clone to avoid direct changes
            EditedService = new Service
            {
                ServiceId = serviceToEdit.ServiceId,
                ServiceType = serviceToEdit.ServiceType,
                ServiceName = serviceToEdit.ServiceName,
                ServiceDescription = serviceToEdit.ServiceDescription,
                ServicePrice = serviceToEdit.ServicePrice,
                ServiceStatus = serviceToEdit.ServiceStatus
            };
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Update EditedService with changes
                EditedService.ServiceType = ServiceTypeTextBox.Text;
                EditedService.ServiceName = ServiceNameTextBox.Text;
                EditedService.ServiceDescription = ServiceDescriptionTextBox.Text;
                EditedService.ServicePrice = decimal.Parse(ServicePriceTextBox.Text);
                EditedService.ServiceStatus = (ServiceStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                DialogResult = true; // Mark operation as successful
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}", "Save Error");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Cancel operation
            Close();
        }


    }
}
