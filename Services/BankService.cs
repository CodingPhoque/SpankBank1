using SpankBank1.Interface;
using SpankBank1.Models;
using SpankBank1.DAL; 
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

        public Account GetAccountById(int id,string userEmail, string userRole) {
            var account = _bankService.BankAccounts.FirstOrDefault(a => a.Id == id);

            // If the user is a Customer, restrict them to their own account
            if (userRole == "Customer" && account.Email != userEmail)
            {
                return null; // If the account doesn't belong to the user, return null
            }

            // Admins can access any account, so no restriction needed for them
            return account;
            // Find the account by ID in the database (OLD)
            //return _bankService.BankAccounts.FirstOrDefault(a => a.Id == Id); (OLD)
        }

        public void CreateAccount( string name, string email, string password, string role) {
            var newAccount = new Account
            {
                
                AccountHolderName = name,
                Email = email,
                Password = password,
                Balance = 0,
                Role = role
            };
            _bankService.BankAccounts.Add(newAccount);
            _bankService.SaveChanges(); // Save to the database
        }

        public void UpdateAccount(Account account, string userEmail, string userRole) {
            // Find the account in the database and update its properties
            var existingAccount = GetAccountById(account.Id, userEmail, userRole);
            if (existingAccount != null)
            {
                throw new UnauthorizedAccessException("You are not authorized to update this account.");
            }
            
                existingAccount.AccountHolderName = account.AccountHolderName;
                existingAccount.Email = account.Email;
                existingAccount.Password = account.Password;
                existingAccount.Balance = account.Balance;
                _bankService.SaveChanges(); // Save the changes to the database
            
        }

        public void DeleteAccount(int id, string userEmail, string userRole) {
            var account = GetAccountById(id, userEmail, userRole);
            if (account != null)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this account.");
            }
            
                _bankService.BankAccounts.Remove(account);
                _bankService.SaveChanges(); // Remove and save changes to the database
            
        }

        public void DepositAccount(int id, decimal amount, string userEmail, string userRole)
        {
            var account = GetAccountById(id, userEmail, userRole);
            if (account != null)
            {
                throw new UnauthorizedAccessException("You are not authorized to deposit into this account.");
            }

            account.Balance += amount;
                _bankService.SaveChanges(); // Save the changes to the database
            
        }

        public void WithdrawAccount(int id, decimal amount, string userEmail, string userRole)
        {
            var account = GetAccountById(id, userEmail, userRole);
            if (account != null)
            {
                throw new UnauthorizedAccessException("You are not authorized to withdraw from this account.");
            }
            account.Balance -= amount;
                _bankService.SaveChanges(); // Save the changes to the database
            
        }
    }
}

