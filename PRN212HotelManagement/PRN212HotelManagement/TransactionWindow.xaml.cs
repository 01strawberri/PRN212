using HotelManagement_BLL;
using HotelManagement_DAL;
using HotelManagement_DAL.DBContext;
using HotelManagement_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PRN212HotelManagement
{
    public partial class TransactionWindow : Window
    {
        private readonly TransactionService _transactionService;
        private List<Transaction> _allTransactions; // Lưu toàn bộ danh sách giao dịch

        public TransactionWindow()
        {
            InitializeComponent();
            _transactionService = new TransactionService(new TransactionRepository(new Prn212hotelManagementContext()));
            LoadTransactions(); // Gọi hàm tải toàn bộ giao dịch
        }

        private void LoadTransactions()
        {
            // Lấy toàn bộ danh sách giao dịch và hiển thị trong DataGrid
            _allTransactions = _transactionService.GetAllTransactions();
            dataGridTransactions.ItemsSource = _allTransactions;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Nếu không nhập gì vào ô tìm kiếm, hiển thị toàn bộ danh sách
            if (string.IsNullOrWhiteSpace(txtSearchBookingId.Text))
            {
                dataGridTransactions.ItemsSource = _allTransactions;
            }
            else
            {
                // Thực hiện lọc dữ liệu dựa trên Booking ID
                if (int.TryParse(txtSearchBookingId.Text, out int bookingId))
                {
                    var filteredTransactions = _allTransactions
                        .Where(t => t.BookingId == bookingId)
                        .ToList();

                    dataGridTransactions.ItemsSource = filteredTransactions;

                    if (!filteredTransactions.Any())
                    {
                        MessageBox.Show($"No transactions found for Booking ID: {bookingId}");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Booking ID.");
                }
            }
        }

        private void dataGridTransactions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGridTransactions.SelectedItem is Transaction selectedTransaction)
            {
                // Mở cửa sổ TransactionDetailWindow khi nhấn vào một dòng
                TransactionDetailWindow detailWindow = new TransactionDetailWindow(selectedTransaction.TransactionId);
                detailWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show($"No transactions found for Transaction ID: ");
            }
        }
    }
}
