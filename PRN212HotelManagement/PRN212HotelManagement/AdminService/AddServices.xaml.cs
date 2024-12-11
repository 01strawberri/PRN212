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

namespace PRN212HotelManagement
{
    public partial class AddServices : Window
    {
        public Service NewService { get; private set; }

        public AddServices()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ServiceTypeTextBox.Text) ||
                    string.IsNullOrWhiteSpace(ServiceNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(ServicePriceTextBox.Text) ||
                    string.IsNullOrWhiteSpace(ServiceStatusComboBox.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error");
                    return;
                }

                NewService = new Service
                {
                    ServiceType = ServiceTypeTextBox.Text,
                    ServiceName = ServiceNameTextBox.Text,
                    ServiceDescription = ServiceDescriptionTextBox.Text,
                    ServicePrice = decimal.Parse(ServicePriceTextBox.Text),
                    ServiceStatus = ServiceStatusComboBox.Text
                };

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Add Service Error");
            }
        }
    }
}
