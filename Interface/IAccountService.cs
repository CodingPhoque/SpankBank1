using SpankBank1.Models;

namespace SpankBank1.Interface
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts(); // Read
        Account GetAccountById(int id);        // Read by ID
        void CreateAccount(string name, string email, string password); // Create
        void UpdateAccount(Account account);   // Update
        void DeleteAccount(int id);                // Delete

        void DepositAccount(int id, decimal amount);

        void WithdrawAccount(int id, decimal amount);
        
    }
}
