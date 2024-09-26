using SpankBank1.DAL;
using SpankBank1.Interface;
using SpankBank1.Models;

namespace SpankBank1.Services
{
    public class BankServiceDb : IAccountService
    {
        private readonly BankContext _context;

        public BankServiceDb(BankContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _context.BankAccounts.ToList();
        }

        public Account GetAccountById(int id)
        {
            return _context.BankAccounts.Find(id);
        }

        public void CreateAccount(string name, string email, string password)
        {
            var newAccount = new Account
            {
                AccountHolderName = name,
                Email = email,
                Password = password,
                Balance = 0M
            };
            _context.BankAccounts.Add(newAccount);
            _context.SaveChanges();  // Save changes to the database
        }

        public void UpdateAccount(Account account)
        {
            _context.BankAccounts.Update(account);
            _context.SaveChanges();  // Save changes to the database
        }

        public void DeleteAccount(int id)
        {
            var account = _context.BankAccounts.Find(id);
            if (account != null)
            {
                _context.BankAccounts.Remove(account);
                _context.SaveChanges();  // Save changes to the database
            }
        }
    }

}
