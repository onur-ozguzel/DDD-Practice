using DddInPractice.Logic.Common;
using DddInPractice.Logic.SharedKernel;
using System;

namespace DddInPractice.Logic.Atms
{
    public class Atm : AggregateRoot
    {
        private const decimal CommissionRate = 0.01m;
        public virtual Money MoneyInside { get; protected set; }
        public virtual decimal MoneyCharged { get; protected set; }
        public Atm()
        {
            MoneyInside = Money.None;
        }

        public virtual string CanTakeMoney(decimal amount)
        {
            if (amount <= 0m) return "Invalid amount";
            if (MoneyInside.Amount < amount) return "Not enough money";
            if (!MoneyInside.CanAllocate(amount)) return "Not enough change";

            return string.Empty;
        }
        public virtual void TakeMoney(decimal amount)
        {
            if (CanTakeMoney(amount) != string.Empty) throw new InvalidOperationException();

            Money output = MoneyInside.Allocate(amount);
            MoneyInside -= output;

            decimal amountWithCommission = CalculateAMountWithCommission(amount);
            MoneyCharged += amountWithCommission;

            //DomainEvents.Raise(new BalanceChangedEvent(amountWithCommission));
            AddDomainEvent(new BalanceChangedEvent(amountWithCommission));
        }

        public virtual void LoadMoney(Money dollar)
        {
            MoneyInside += dollar;
        }

        public virtual decimal CalculateAMountWithCommission(decimal amount)
        {
            decimal commission = amount * CommissionRate;
            decimal lessThanCent = commission % 0.01m;
            if (lessThanCent > 0)
            {
                commission = commission - lessThanCent + 0.01m;
            }

            return amount + commission;
        }
    }
}
