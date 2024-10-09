namespace SpankBank1.Models
{
    public class Account
    {

        public int Id { get; set; }
        public string AccountHolderName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public string Role { get; set; } 
    }
}
