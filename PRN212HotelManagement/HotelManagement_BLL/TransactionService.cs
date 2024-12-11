using HotelManagement_DAL;
using HotelManagement_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_BLL
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepo;

        public TransactionService(TransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionRepo.GetAllTransactions();
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepo.AddTransaction(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _transactionRepo.UpdateTransaction(transaction);
        }
    }
}
