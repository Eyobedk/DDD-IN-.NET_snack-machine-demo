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

            snack_Machine.BuySnack();

            snack_Machine.MoneyInTranscation.Should().Be(Money.None);
            snack_Machine.MoneyInTranscation.Should().Be(2m);

        }
    }
}