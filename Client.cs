using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2bank
{
    public class Client
    {

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        private List<Account> accounts;

        public Client(string firstName, string lastName) 
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException(nameof(firstName), "First name cannot be null or contains only whitespace");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException(nameof(lastName), "First name cannot be null or contains only whitespace");
            }
            FirstName = firstName;
            LastName = lastName;
            accounts = new List<Account>();
        }

        public void AddAccount(Account account) 
        { 
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null");
            }
            accounts.Add(account);
        }

        public void RemoveAccount(Account account) 
        {
            accounts.Remove(account);
        }

        public IEnumerable<Account> GetAccounts() 
        { 
            return accounts.AsReadOnly();
        }

        public decimal GetTotalBalance() 
        { 
            decimal totalBalance = 0;
            foreach (var account in accounts)
            {
                totalBalance += account.Balance.UAH;
            }
            return totalBalance;
        }


        public override string ToString() 
        {
            if (accounts == null || accounts.Count == 0)
            {
                return "The client has no accounts";
            }
            else
            {
                decimal totalBalance = GetTotalBalance();
                return $"Total balance: {GetTotalBalance()} UAH";
            }
        }
    }
}
