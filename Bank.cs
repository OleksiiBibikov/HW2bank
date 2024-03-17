using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW2bank
{
    public class Bank
    {
        public List<Client> clients { get; private set; }
        public List<Account> accounts { get; private set; }

        public Bank()
        {
            clients = new List<Client>();
            accounts = new List<Account>();
        }

        public void AddClient(string firstName, string lastName)
        {
            var client = new Client(firstName, lastName);
            clients.Add(client);
        }

        public Account GetAccount(decimal initialBalance, decimal interestRate, Client client) 
        {
            var clientCheck = clients.FirstOrDefault(c => c.FirstName == client.FirstName && c.LastName == client.LastName);
            if (clientCheck == null) 
            {
                throw new InvalidOperationException("Client not found");
            }

            var account = new Account(initialBalance, interestRate);
            accounts.Add(account);
            clientCheck.AddAccount(account);

            return account;
        }

        public void DoTransfer(Guid sourceAccountId, Guid destinationAccountId, Money amount)
        {
            var sourceAccount = this.accounts.FirstOrDefault(a => a.Id == sourceAccountId);
            var destinationAccount = this.accounts.FirstOrDefault(b => b.Id == destinationAccountId);

            if (sourceAccount == null || destinationAccount == null)
            {
                throw new InvalidOperationException("One of account is not found");
            }
            sourceAccount.Transfer(destinationAccount, amount);
        }

        public void ShowTransactionHistory()
        {
            foreach (var account in accounts) 
            {
                Console.WriteLine($"History of account: {account.Id}:");
                foreach (var transaction in account.GetTransactions())
                {
                    Console.WriteLine($"{transaction.DateTime:g}: {transaction.Type} {transaction.Amount.UAH} UAH");
                }
                Console.WriteLine();
            }
        }


        public IEnumerable<Client> GetAllClients() 
        {
            return clients.AsReadOnly();
        }

        public IEnumerable<Account> GetAllAccounts() 
        { 
            return accounts.AsReadOnly();
        }

        public decimal GetTotalBalanceOfClient(string firstName, string lastName)
        {
            var client = clients.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
            if (client == null)
            {
                throw new InvalidOperationException("Client not found");
            }
            return client.GetTotalBalance();
        }
    }
}
