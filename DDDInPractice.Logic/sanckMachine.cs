using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public sealed class sanckMachine
    {
        public Money MoneyInside { get; private set; }
        public Money MoneyInTranscation { get; private set; }



        public void InsertMoney(Money money)
        {
            MoneyInTranscation += money;
        }

        public void ReturnMoney() { 
           // MoneyInTranscation = 0  
        }

        public void BuySnack() {
            MoneyInside += MoneyInTranscation;
            //MoneyInTransaction = 0
        }
    }
}