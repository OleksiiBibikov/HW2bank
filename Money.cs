using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HW2bank
{
    public class Money
    {
        public decimal UAH {  get; }

        public Money(decimal uah) 
        {
            if (uah < 0)
            {
                throw new ArgumentException(nameof(uah), "Amount must be bigger than 0");
            }
            UAH = uah;  
        }

        public Money Add(Money amount) 
        {
            return new Money(this.UAH + amount.UAH);
        }

        public Money Subtract(Money amount) 
        { 
            if (amount.UAH > this.UAH)
            {
                throw new ArgumentException("Not enough money");
            }
            return new Money(this.UAH - amount.UAH);
            
        }

        public static Money operator +(Money a, Money b) 
        { 
            return a.Add(b);
        }

        public static Money operator -(Money a, Money b) 
        { 
            return a.Subtract(b);
        }

        public static bool operator >(Money a, Money b)
        {
            return a.UAH > b.UAH;
        }

        public static bool operator <(Money a, Money b)
        {
            return a.UAH < b.UAH;
        }

        public static bool operator >=(Money a, Money b) 
        {
            return a.UAH >= b.UAH;
        }

        public static bool operator <=(Money a, Money b)
        {
            return a.UAH <= b.UAH;
        }

        public override string ToString()
        {
            return $"{UAH} griven";
        }
    }
}
