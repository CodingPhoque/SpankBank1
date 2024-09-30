using SpankBank1.Interface;
using SpankBank1.Models;
using SpankBank1.DAL; // Assuming BankContext is in this namespace
using System.Collections.Generic;
using System.Linq;

namespace SpankBank1.Services
{
    public class BankService : IAccountService
    {
        private readonly BankContext _bankService;
        
        public BankService(BankContext context) {
            _bankService = context;
        }

        public IEnumerable<Account> GetAllAccounts() {
            // Return all accounts from the database
            
           

            return _bankService.BankAccounts.ToList();
        }

        public Account GetAccountById(int id) {
            // Find the account by ID in the database
            return _bankService.BankAccounts.FirstOrDefault(a => a.Id == id);
        }

        public void CreateAccount( string name, string email, string password) {
            var newAccount = new Account
            {
                
                AccountHolderName = name,
                Email = email,
                Password = password,
                Balance = 0
            };
            _bankService.BankAccounts.Add(newAccount);
            _bankService.SaveChanges(); // Save to the database
        }

        public void UpdateAccount(Account account) {
            // Find the account in the database and update its properties
            var existingAccount = GetAccountById(account.Id);
            if (existingAccount != null)
            {
                existingAccount.AccountHolderName = account.AccountHolderName;
                existingAccount.Email = account.Email;
                existingAccount.Password = account.Password;
                existingAccount.Balance = account.Balance;
                _bankService.SaveChanges(); // Save the changes to the database
            }
        }

        public void DeleteAccount(int id) {
            var account = GetAccountById(id);
            if (account != null)
            {
                _bankService.BankAccounts.Remove(account);
                _bankService.SaveChanges(); // Remove and save changes to the database
            }
        }
    }
}

