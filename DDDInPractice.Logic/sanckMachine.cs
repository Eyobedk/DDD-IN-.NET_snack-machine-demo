using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public class sanckMachine : Entity
    {
        public virtual Money MoneyInside { get; private set; } = Money.None;
        public virtual Money MoneyInTranscation { get; private set; } = Money.None;
        public virtual IList<Slot> slots { get; protected set; }

        public virtual void InsertMoney(Money money)
        {
            Money[] coins = { Money.Cent, Money.TenCent, Money.Quarter, Money.TenDollar, Money.TwentyDollar };
            if (!coins.Contains(money))
                throw new InvalidOperationException();

            MoneyInTranscation += money;
        }

        public virtual void ReturnMoney()
        {
            MoneyInTranscation = Money.None;
        }

        public virtual void BuySnack()
        {
            MoneyInside += MoneyInTranscation;
            MoneyInTranscation = Money.None;
        }

        public virtual void LoadSnacks(int position, Snack snack, int quantity, decimal price)
        {
            Slot slot = slots.Single(x => x.Position == position);
            slot.Snack = snack;
            slot.Quantity = quantity;
            slot.Price = price;
        }
    }
}