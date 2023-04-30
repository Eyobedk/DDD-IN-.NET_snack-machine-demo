using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money TenDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);




        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCount { get; }
        public int OneDollarCOunt { get; }
        public int TenDollarCount { get; }
        public int TwentyDollarCount { get; }

        public Money()
        {

        }
        public decimal Amount
        {
            get
            {
                return OneCentCount * 0.01m +
                    TenCentCount * 0.10m +
                    QuarterCount * 0.25m +
                    OneDollarCOunt +
                    TenDollarCount * 10 +
                    TwentyDollarCount * 20;
            }
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCount - money2.QuarterCount,
                money1.OneDollarCOunt - money2.OneDollarCOunt,
                money1.TenDollarCount - money2.TenDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount);
        }

        public Money(
            int OneCentCount,
            int TenCentCount,
            int QuarterCount,
            int OneDollarCOunt,
            int TenDollarCount,
            int TwentyDollarCount) : this()
        {
            this.OneCentCount = OneCentCount;
            this.TenCentCount = TenCentCount;
            this.QuarterCount = QuarterCount;
            this.OneDollarCOunt = OneDollarCOunt;
            this.TenDollarCount = TenDollarCount;
            this.TwentyDollarCount = TwentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2) {

            Money sum = new Money(
                    money1.OneCentCount + money2.OneCentCount,
                    money1.TenCentCount + money2.TenCentCount,
                    money1.QuarterCount + money2.QuarterCount,
                    money1.OneDollarCOunt + money2.OneDollarCOunt,
                    money1.TenDollarCount + money2.TenDollarCount,
                    money1.TwentyDollarCount + money2.TwentyDollarCount);
            return sum;
        }

        //check the equality for each of the properties
        public override bool EqualsCore(Money other) {
            return OneCentCount == other.OneCentCount
                && TenCentCount == other.TenCentCount
                && QuarterCount == other.QuarterCount
                && OneDollarCOunt == other.OneDollarCOunt
                && TenDollarCount == other.TenDollarCount
                && TwentyDollarCount == other.TwentyDollarCount;
        }

        protected override int GetHashCodeCore()
        {
           unchecked
            {
                int hascode = OneCentCount;
                hascode = (hascode * 397) ^ TenCentCount;
                hascode = (hascode * 397) ^ QuarterCount;
                hascode = (hascode * 397) ^ OneDollarCOunt;
                hascode = (hascode * 397) ^ TenDollarCount;
                hascode = (hascode * 397) ^ TwentyDollarCount;
                return hascode;
            }
        }

        public Money Allocate(decimal amount) {
            //int twentyDollarCount=  Math.Min((int)(amount / 20), TwentyDollarCount);
            //amount = amount - twentyDollarCount * 20;

            //int fiveDollarCount = Math.Min((int)(amount / 5), TenDollarCount);
            //amount = amount fiveDollarCount * 5;

            //int oneDollarCount = Math.Min((int)amount, OneDollarCount);
            //amount = amount - oneDollarCount;

            //int quarterCount Math.Min((int)(amount / 0.25m), arterunt);
            //amount amount quarterCount * 0.25m;

            //int tencentCount -Math.Min((int)(amount / 0.1m), Teint unt);
            //amount amount tenCentCount * 0.1m;

           // int oneCentCount -Math.min((int)(amount / 0.01m), OneCentCount);
            return new Money(
                OneCentCount,
                TenCentCount,
                QuarterCount,
                OneDollarCOunt,
                TenDollarCount,
                TwentyDollarCount);
        
        }
    }
}