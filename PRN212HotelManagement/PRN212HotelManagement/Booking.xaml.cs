using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;

namespace PRN212HotelManagement
{
    public partial class Booking : Window
    {
        private readonly BookingServices _bookingService;
        private readonly UserService _userService;
        private readonly RoomService _roomService;
        private readonly ServicesService _serviceService;
        private User currentUser;
        private HotelManagement_DAL.Booking selectedBookingForUpdate; 


        public Booking(User user)
        {
            InitializeComponent();
            currentUser = user;

            var context = new Prn212hotelManagementContext();
            _bookingService = new BookingServices(
                new BookingRepository(context),
                new UserRepository(context),
                new RoomRepository(context));
            _userService = new UserService(new UserRepository(context));
            _roomService = new RoomService(new RoomRepository(context));
            _serviceService = new ServicesService(new ServiceRepository(context));

            LoadData();
            LoadBookings();
        }

        private void LoadData()
        {
            comboUserName.ItemsSource = _userService.GetAllUsers();
            comboRoomName.ItemsSource = _roomService.GetAllRooms();
        }

        private void LoadBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            dataGridBookings.ItemsSource = bookings;
        }

        private void UpdateTotalPrice()
        {
            if (comboRoomName.SelectedValue == null || dateStart.SelectedDate == null || dateEnd.SelectedDate == null)
            {
                txtTotalPrice.Text = "0";
                return;
            }

            int roomId = (int)comboRoomName.SelectedValue;
            DateOnly startDate = DateOnly.FromDateTime(dateStart.SelectedDate.Value);
            DateOnly endDate = DateOnly.FromDateTime(dateEnd.SelectedDate.Value);

            // Get room price per day
            decimal? roomPricePerDay = _roomService.GetRoomPricePerDay(roomId);
            if (roomPricePerDay == null)
            {
                txtTotalPrice.Text = "0";
                return;
            }

            int totalDays = (endDate.ToDateTime(new TimeOnly(0, 0)) - startDate.ToDateTime(new TimeOnly(0, 0))).Days + 1;
            decimal roomCost = totalDays * roomPricePerDay.Value;

            // Get selected services price
            var selectedServices = listBoxSelectedServices.Items.Cast<Service>().ToList();
            decimal serviceCost = selectedServices.Sum(service => service.ServicePrice);

            // Update total price
            txtTotalPrice.Text = (roomCost + serviceCost).ToString("F2");
        }



        private void comboRoomName_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateTotalPrice();

        private void DateSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateTotalPrice();

        private void listBoxServices_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateTotalPrice();

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            // Reset popup fields
            comboUserName.SelectedItem = null;
            comboRoomName.SelectedItem = null;
            dateStart.SelectedDate = null;
            dateEnd.SelectedDate = null;
            txtTotalPrice.Text = "0";

            // Show popup
            popupGrid.Visibility = Visibility.Visible;
            selectedBookingForUpdate = null; // Reset the update object
        }

        private void btnUpdateBooking_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridBookings.SelectedItem is HotelManagement_DAL.Booking selectedBooking)
            {
                selectedBookingForUpdate = selectedBooking;

                // Fill in the popup with the selected booking's details
                comboUserName.SelectedValue = selectedBooking.UserId;
                comboRoomName.SelectedValue = selectedBooking.RoomId;
                dateStart.SelectedDate = selectedBooking.BookingStartDay.ToDateTime(new TimeOnly(0, 0));
                dateEnd.SelectedDate = selectedBooking.BookingEndDay.ToDateTime(new TimeOnly(0, 0));
                // Assuming selected services are stored in a related list or something

                // Show popup for updating booking
                popupGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please select a booking to update.", "No Booking Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSaveBooking_Click(object sender, RoutedEventArgs e)
        {
            if (comboUserName.SelectedValue == null || comboRoomName.SelectedValue == null || dateStart.SelectedDate == null || dateEnd.SelectedDate == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int userId = (int)comboUserName.SelectedValue;
            int roomId = (int)comboRoomName.SelectedValue; // Lấy roomId
            DateOnly startDate = DateOnly.FromDateTime(dateStart.SelectedDate.Value);
            DateOnly endDate = DateOnly.FromDateTime(dateEnd.SelectedDate.Value);

            // Lấy danh sách dịch vụ đã chọn từ listboxSelectedServices
            var selectedServices = listBoxSelectedServices.Items.Cast<Service>().ToList();
            string errorMessage;

            // Kiểm tra nếu là thêm mới hay cập nhật
            if (selectedBookingForUpdate == null) // Thêm mới booking
            {
                bool isAdded = _bookingService.AddBooking(userId, roomId, startDate, endDate, "ByDay", "Pending", selectedServices, out errorMessage);

                if (isAdded)
                {
                    MessageBox.Show("Booking added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    popupGrid.Visibility = Visibility.Collapsed;
                    LoadBookings();
                }
                else
                {
                    MessageBox.Show($"Failed to add booking: {errorMessage}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else // Cập nhật booking
            {
                // Cập nhật các thông tin của bookingForUpdate
                selectedBookingForUpdate.UserId = userId;
                selectedBookingForUpdate.RoomId = roomId; // Đảm bảo roomId được cập nhật
                selectedBookingForUpdate.BookingStartDay = startDate;
                selectedBookingForUpdate.BookingEndDay = endDate;

                // Cập nhật danh sách dịch vụ (BookingService -> Service)
                List<Service> serviceList = listBoxSelectedServices.Items.Cast<Service>().ToList();

                decimal totalPrice = selectedBookingForUpdate.TotalPrice.GetValueOrDefault();

                // Gọi phương thức UpdateBooking với đủ tất cả tham số cần thiết
                bool isUpdated = _bookingService.UpdateBooking(
                    selectedBookingForUpdate.BookingId, // bookingId
                    userId, // userId
                    roomId, // roomId
                    selectedBookingForUpdate.BookingType, // bookingType
                    selectedBookingForUpdate.BookingStatus, // bookingStatus
                    startDate, // bookingStartDay
                    endDate, // bookingEndDay
                    totalPrice, // totalPrice (nullable decimal -> decimal)
                    serviceList, // selectedServices (Service)
                    out errorMessage
                );

                if (isUpdated)
                {
                    MessageBox.Show("Booking updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    popupGrid.Visibility = Visibility.Collapsed;
                    LoadBookings();
                }
                else
                {
                    MessageBox.Show($"Failed to update booking: {errorMessage}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRemoveService_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var serviceToRemove = button.DataContext as Service;
            if (serviceToRemove != null)
            {
                listBoxSelectedServices.Items.Remove(serviceToRemove);
                UpdateTotalPrice();  // Cập nhật tổng giá
            }
        }




        private void btnCancelBooking_Click(object sender, RoutedEventArgs e)
        {
            popupGrid.Visibility = Visibility.Collapsed;
        }

        private void btnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridBookings.SelectedItem is HotelManagement_DAL.Booking selectedBooking)
            {
                BookingDetail detailWindow = new BookingDetail(selectedBooking.BookingId, _bookingService);
                detailWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a booking to view details.", "No Booking Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            StaffWPF staffProfile = new StaffWPF(currentUser);
            staffProfile.Show();
            this.Close();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btn_Bookings_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking(currentUser);
            booking.Show();
            this.Close();
        }
        // Khi nhấn nút "Add Service" trong popup
        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem có dịch vụ nào được chọn không
            var selectedService = listBoxAvailableServices.SelectedItem as Service;
            if (selectedService != null && !listBoxSelectedServices.Items.Contains(selectedService))
            {
                listBoxSelectedServices.Items.Add(selectedService);
                UpdateTotalPrice();  // Cập nhật tổng giá
            }
            else
            {
                MessageBox.Show("Please select a service to add.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Đóng popup sau khi thêm dịch vụ
            popupAddService.IsOpen = false;
        }

        // Khi nhấn nút "Cancel" trong popup
        private void btnCancelService_Click(object sender, RoutedEventArgs e)
        {
            // Đóng popup mà không làm gì
            popupAddService.IsOpen = false;
        }

        // Khi nhấn nút "Add Service" trên giao diện chính
        private void btnAddService1_Click(object sender, RoutedEventArgs e)
        {
            // Tải danh sách dịch vụ vào Popup
            listBoxAvailableServices.ItemsSource = _serviceService.GetServices();  // Dữ liệu dịch vụ

            // Mở Popup để chọn dịch vụ
            popupAddService.IsOpen = true;
        }

    }
}
