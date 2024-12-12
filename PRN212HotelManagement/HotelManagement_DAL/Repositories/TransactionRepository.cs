using HotelManagement_DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_DAL.Repositories
{
    public class TransactionRepository
    {
        private readonly Prn212hotelManagementContext _context;


        public TransactionRepository(Prn212hotelManagementContext context)
        {
            _context = context;
        }

        // Lấy danh sách Transaction
        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions
                           .Include(t => t.User)
                           .Include(t => t.Booking)
                           .ToList();
        }

        // Thêm Transaction
        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        // Cập nhật Transaction
        public void UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }

    }
}
