using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]public Money Amount { get; private set; }
        public DateTime DateTime { get; private set; }
        [Required]public TransactionType Type { get; private set;}
        public Guid? SourceAccountId { get; private set; }
        public Guid? DestinationAccountId { get; private set; }

        public Transaction(Money amount, TransactionType type, DateTime dateTime, Guid sourceAccountId, Guid accountId)
        {
            if (amount == null)
            { 
                throw new ArgumentNullException(nameof(amount), "Amount cannot be null");
            }
            if (accountId == Guid.Empty)
            {
                throw new ArgumentException(nameof(accountId), "Account ID cannot be empty");
            }
            Id = Guid.NewGuid();
            Amount = amount;
            DateTime = dateTime;
            Type = type;
            AssignAccountBasedOnType(accountId);
        }

        public Transaction(Money amount, DateTime dateTime, Guid sourceAccountId, Guid destinationAccountId) 
        {
            if (amount == null)
            {
                throw new ArgumentNullException(nameof(amount), "Amount cannot be null");
            }
            if (sourceAccountId == Guid.Empty || destinationAccountId == Guid.Empty)
            {
                throw new ArgumentException("Source account ID or destination account ID cannot be empty");
            }
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
            else
            {
                throw new ArgumentException(nameof(Type), "Invalid transaction type for account operation");
            }
        }
    }
}
