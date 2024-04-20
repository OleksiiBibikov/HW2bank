using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(0, double.MaxValue, ErrorMessage = "Interest rate out of range")] public decimal InterestRate { get; private set; }
        private List<Transaction> transactions;

        public Account(decimal initBalance, decimal interestRate) 
        { 
            if (initBalance < 0)
            {
                throw new ArgumentException(nameof(initBalance), "Initial balance cannot be less than 0");
            }
            if (interestRate < 0)
            {
                throw new ArgumentException(nameof(interestRate), "Interest rate cannot be less than 0");
            }
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
            if (amount.UAH < 0)
            {
                throw new ArgumentException(nameof(amount), "Deposit amount cannot be less than 0");
            }
            balance = balance.Add(amount);
            transactions.Add(new Transaction(amount, TransactionType.Deposit, DateTime.Now, this.Id, this.Id));
        }

        public async Task DepositAsync(Money amount)
        {
            await Task.Delay(100);
            balance = balance.Add(amount);
            transactions.Add(new Transaction(amount, TransactionType.Deposit, DateTime.Now, this.Id, this.Id));
        }

        public void Withdraw(Money amount)
        {
            if (amount.UAH < 0)
            {
                throw new ArgumentException(nameof(amount), "Deposit amount cannot be less than 0");
            }
            if (amount.UAH > balance.UAH)
            {
                throw new InvalidOperationException($"Not enough money");
            }
            balance = balance.Subtract(amount);
            transactions.Add(new Transaction(amount, DateTime.Now, this.Id, this.Id));
        }

        public async Task WithdrawAsync(Money amount)
        {
            if (amount.UAH < 0)
            {
                throw new ArgumentException(nameof(amount), "Deposit amount cannot be less than 0");
            }
            if (amount.UAH > balance.UAH)
            {
                throw new InvalidOperationException($"Not enough money");
            }
            await Task.Delay(100);
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

        public async Task TransferAsync(Account destination, Money amount)
        {
            if (this.Balance.UAH >= amount.UAH)
            {
                await this.WithdrawAsync(amount);
                await destination.DepositAsync(amount);
            }
            else 
            {
                throw new InvalidOperationException("Not enough money for transfer");
            }
        }
        

        public void SetInterestRate(decimal newInterestRate)
        {
            if (newInterestRate < 0) 
            {
                throw new ArgumentException(nameof(newInterestRate), "Interest rate cannot be less than 0");
            }
            InterestRate = newInterestRate;
        }

        public IEnumerable<Transaction> GetTransactions()
        { 
            return transactions.AsReadOnly();
        }

        
    }
}
