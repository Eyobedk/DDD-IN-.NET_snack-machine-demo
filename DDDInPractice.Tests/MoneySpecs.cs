using DDDInPractice.Logic;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xunit;

namespace DDDInPractice.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void sum_of_two_money_produces_correct_result()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Money sum = money1 + money2;
            Assert.Equal(2, sum.OneCentCount);

            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCOunt.Should().Be(8);
            sum.TenDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }

        [Fact]
        public void two_money_instances_equal_if_they_contain_the_same_money_amount() {

            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);
            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void two_money_instances_dont_equal_if_they_contain_the_same_money_amount() {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(8, 6, 9, 3, 1, 2);

            money1.Should().NotBe(money2);
            money1.GetHashCode().Should().NotBe(money2.GetHashCode());
        }
    }
}