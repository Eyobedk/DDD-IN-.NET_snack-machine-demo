using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public sealed class sanckMachine : Entity
    {
        public Money MoneyInside { get; private set; } = Money.None;
        public Money MoneyInTranscation { get; private set; } = Money.None;

        public void InsertMoney(Money money)
        {
            Money[] coins = { Money.Cent, Money.TenCent, Money.Quarter, Money.TenDollar, Money.TwentyDollar };
            if (!coins.Contains(money))
                throw new InvalidOperationException();

            MoneyInTranscation += money;
        }

        public void ReturnMoney() {
            MoneyInTranscation = Money.None;
        }

        public void BuySnack() {
            MoneyInside += MoneyInTranscation;
            MoneyInTranscation = Money.None;
        }
    }
}