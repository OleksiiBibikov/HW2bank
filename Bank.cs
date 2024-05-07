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
        private ClientRepository clientRepository;
        private AccountRepository accountRepository;

        public Bank(string connectionString)
        {
            clientRepository = new ClientRepository(connectionString);
            accountRepository = new AccountRepository(connectionString);
        }

        public void AddClient(string firstName, string lastName)
        {
            var client = new Client(firstName, lastName);
            clientRepository.AddClient(client);
        }

        public Account GetAccount(decimal initialBalance, decimal interestRate, int clientId)
        {
            var client = clientRepository.GetClient(clientId);
            if (client == null)
            {
                throw new InvalidOperationException("Client not found");
            }

            var account = new Account(initialBalance, interestRate);
            accountRepository.AddAccount(account, clientId);
            return account;
        }

        public void DoTransfer(Guid sourceAccountId, Guid destinationAccountId, Money amount)
        {
            var sourceAccount = accountRepository.GetAccount(sourceAccountId);
            var destinationAccount = accountRepository.GetAccount(destinationAccountId);

            if (sourceAccount == null || destinationAccount == null)
            {
                throw new InvalidOperationException("One of the accounts is not found");
            }

            sourceAccount.Transfer(destinationAccount, amount);
            accountRepository.UpdateAccount(sourceAccount);
            accountRepository.UpdateAccount(destinationAccount);
        }

        //public void ShowTransactionHistory()
        //{
        //    var accounts = accountRepository.GetAllAccounts();
        //    foreach (var account in accounts)
        //    {
        //        Console.WriteLine($"History of account: {account.Id}:");
        //        foreach (var transaction in account.GetTransactions())
        //        {
        //            Console.WriteLine($"{transaction.DateTime:g}: {transaction.Type} {transaction.Amount.UAH} UAH");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //public IEnumerable<Client> GetAllClients()
        //{
        //    return clientRepository.GetAllClients();
        //}

        //public IEnumerable<Account> GetAllAccounts()
        //{
        //    return accountRepository.GetAllAccounts();
        //}

        public decimal GetTotalBalanceOfClient(int clientId)
        {
            var client = clientRepository.GetClient(clientId);
            if (client == null)
            {
                throw new InvalidOperationException("Client not found");
            }
            return client.GetTotalBalance();
        }
    }

}
