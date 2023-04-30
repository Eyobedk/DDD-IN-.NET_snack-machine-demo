using DDDInPractice.Logic;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xunit;

namespace DDDInPractice.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void can_not_insert_more_than_one_coin_or_note_at_a_time()
        {
            var snack_Machine = new sanckMachine();
            snack_Machine.InsertMoney(Money.Dollar);

            snack_Machine.ReturnMoney();

            snack_Machine.MoneyInTranscation.Should().Be(0m);
        }

        [Fact]
        public void money_intransction_goes_to_money_inside_after_purchase()
        {
            var snack_Machine = new sanckMachine();
            snack_Machine.InsertMoney(Money.Dollar);
            snack_Machine.InsertMoney(Money.Dollar);

            snack_Machine.BuySnack(2);

            snack_Machine.MoneyInTranscation.Should().Be(0);
            snack_Machine.MoneyInTranscation.Should().Be(2m);

        }

        [Fact]
        public void Buy_snack_trades_Inserted_money_for_a_snack()
        {
            var snack_Machine = new sanckMachine();
            snack_Machine.LoadSnacks(1, new SnackPile(new Snack("some snack"), 10, 1m));
            snack_Machine.InsertMoney(Money.Dollar);

            snack_Machine.BuySnack(1);

            snack_Machine.MoneyInTranscation.Should().Be(0);
            snack_Machine.MoneyInside.Amount.Should().Be(2m);
            snack_Machine.GetSnackPile(1).Quantity.Should().Be(9);

        }
    }
}