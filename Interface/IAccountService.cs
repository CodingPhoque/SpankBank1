using SpankBank1.Models;

namespace SpankBank1.Interface
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts(); // Read
        Account GetAccountById(int id, string userEmail, string userR);        // Read by ID
        void CreateAccount(string name, string email, string password, string role); // Create
        void UpdateAccount(Account account, string userEmail, string userRole);   // Update
        void DeleteAccount(int id, string userEmail, string userRole);  // Delete

        void DepositAccount(int id, decimal amount, string userEmail, string userRole);

        void WithdrawAccount(int id, decimal amount, string userEmail, string userRole);
        
    }
}
