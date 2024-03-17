using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2bank
{
    public enum TransactionType
    {
        Deposit,
        Withdraw,
        Transfer
    }
    public class Transaction
    {
        public Guid Id { get; private set; }
        public Money Amount { get; private set; }
        public DateTime DateTime { get; private set; }
        public TransactionType Type { get; private set;}
        public Guid? SourceAccountId { get; private set; }
        public Guid? DestinationAccountId { get; private set; }

        public Transaction(Money amount, TransactionType type, DateTime dateTime, Guid sourceAccountId, Guid accountId)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            DateTime = dateTime;
            Type = type;
            AssignAccountBasedOnType(accountId);
        }

        public Transaction(Money amount, DateTime dateTime, Guid sourceAccountId, Guid destinationAccountId) 
        { 
            Id = Guid.NewGuid();
            Amount = amount;
            DateTime = dateTime;
            Type = TransactionType.Transfer;
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
        }

        private void AssignAccountBasedOnType(Guid accountId) 
        { 
            if (Type == TransactionType.Deposit)
            {
                DestinationAccountId = accountId;
            }
            else if (Type == TransactionType.Withdraw)
            {
                SourceAccountId = accountId;
            }
        }
    }
}
