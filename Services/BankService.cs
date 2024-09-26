
using SpankBank1.Interface;
using SpankBank1.Models;

namespace SpankBank1.Services
{
    public class BankService : IAccountService
    {
        private readonly List<Account> _accounts = new List<Account>();

        public IEnumerable<Account> GetAllAccounts() {
            return _accounts;
        }

        public Account GetAccountById(int id) {
            return _accounts.FirstOrDefault(a => a.Id == id);
        }

        public void CreateAccount(string name, string email, string password) {
            var newAccount = new Account
            {
                Id = _accounts.Count + 1,
                AccountHolderName = name,
                Email = email,
                Password = password,
                Balance = 0M
            };
            _accounts.Add(newAccount);
        }

        public void UpdateAccount(Account account) {
            var existingAccount = GetAccountById(account.Id);
            if (existingAccount != null)
            {
                existingAccount.AccountHolderName = account.AccountHolderName;
                existingAccount.Email = account.Email;
                existingAccount.Password = account.Password;
                existingAccount.Balance = account.Balance;
            }
        }

        public void DeleteAccount(int id) {
            var account = GetAccountById(id);
            if (account != null)
            {
                _accounts.Remove(account);
            }
        }
    }

}
