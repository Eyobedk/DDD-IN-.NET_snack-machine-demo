using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public class Money : ValueObject<Money>
    {
        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCount { get; private set; }
        public int OneDollarCOunt { get; private set; }
        public int TenDollarCount { get; private set; }
        public int TwentyDollarCount { get; private set; }

        public Money(
            int OneCentCount,
            int TenCentCount,
            int QuarterCount,
            int OneDollarCOunt,
            int TenDollarCount,
            int TwentyDollarCount)
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

        public override bool EqualScore(Money other) {
            return OneCentCount == other.OneCentCount
                && TenCentCount == other.TenCentCount
                && QuarterCount == other.QuarterCount
                && OneDollarCOunt == other.OneDollarCOunt
                && TenDollarCount == other.TenDollarCount
                && TwentyDollarCount == other.TwentyDollarCount;
        }
    }
}