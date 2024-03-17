using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HW2bank
{
    public class Account
    {
        public Guid Id { get; private set; }
        private Money balance;
        public decimal InterestRate { get; private set; }
        private List<Transaction> transactions;

        public Account(decimal initBalance, decimal interestRate) 
        { 
            Id = Guid.NewGuid();
            balance = new Money(initBalance);
            InterestRate = interestRate;
            transactions = new List<Transaction>();
            
        }
        
        public Money Balance 
        { 
            get { return balance; } 
        }

        public void Deposit(Money amount)
        {
            balance = balance.Add(amount);
            transactions.Add(new Transaction(amount, TransactionType.Deposit, DateTime.Now, this.Id, this.Id));
        }

        public void Withdraw(Money amount)
        { 
            if (amount.UAH > balance.UAH)
            {
                throw new InvalidOperationException($"Not enough money");
            }
            balance = balance.Subtract(amount);
            transactions.Add(new Transaction(amount, DateTime.Now, this.Id, this.Id));
        }

        public void Transfer(Account destination, Money amount)
        {
            if (this.Balance.UAH >= amount.UAH) 
            { 
                this.Withdraw(amount);
                destination.Deposit(amount);
            }
            else
            {
                throw new InvalidOperationException("Not enough money for transfer");
            }
        }
        

        public void SetInterestRate(decimal newInterestRate)
        {
            InterestRate = newInterestRate;
        }

        public IEnumerable<Transaction> GetTransactions()
        { 
            return transactions.AsReadOnly();
        }

        
    }
}
