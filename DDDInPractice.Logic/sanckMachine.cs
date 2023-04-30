using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public class sanckMachine : Entity
    {
        public virtual Money MoneyInside { get; private set; }
        public virtual decimal MoneyInTranscation { get; private set; }
        protected virtual IList<Slot> slots { get;  set; }

        public sanckMachine()
        {
            MoneyInside = Money.None;
            MoneyInTranscation =0;

            slots = new List<Slot>
            {
            new Slot (this, 1),
            new Slot(this, 2),
            new Slot(this, 3)
            };
         }

        public virtual SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        private Slot GetSlot(int position) {
            return slots.Single(x => x.Position == position);
        }

        public virtual void InsertMoney(Money money)
        {
            Money[] coins = { Money.Cent, Money.TenCent, Money.Quarter, Money.TenDollar, Money.TwentyDollar };
            if (!coins.Contains(money))
                throw new InvalidOperationException();

            MoneyInTranscation += money.Amount;
            MoneyInside += money;
        }

        public virtual void ReturnMoney()
        {
            MoneyInTranscation = 0;
        }

        public virtual void BuySnack(int position)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = slot.SnackPile.SubstractOne();

            MoneyInTranscation = 0;
        }

        public virtual void LoadSnacks(int position, SnackPile snackpile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackpile;
        }
    }
}