﻿using DddInPractice.Logic.Atms;
using DddInPractice.Logic.Common;
using DddInPractice.Logic.SharedKernel;
using DddInPractice.Logic.Utils;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DddInPractice.Tests
{
    public class AtmSpecs
    {
        [Fact]
        public void Take_money_exchanges_money_with_commission()
        {
            var atm = new Atm();
            atm.LoadMoney(Money.Dollar);

            atm.TakeMoney(1m);

            atm.MoneyInside.Amount.Should().Be(0m);
            atm.MoneyCharged.Should().Be(1.01m);
        }

        [Fact]
        public void Commission_is_at_least_one_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Money.Cent);

            atm.TakeMoney(0.01m);

            atm.MoneyCharged.Should().Be(0.02m);
        }

        [Fact]
        public void Commission_is_rounded_up_to_the_next_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Money.Dollar + Money.TenCent);

            atm.TakeMoney(1.1m);

            atm.MoneyCharged.Should().Be(1.12m);
        }

        [Fact]
        public void Take_money_raises_an_event()
        {
            //Initer.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true");
            Atm atm = new Atm();
            atm.LoadMoney(Money.Dollar);
            
            //BalanceChangedEvent balanceChangedEvent = null;
            //DomainEvents.Register<BalanceChangedEvent>(ev => balanceChangedEvent = ev);
            
            atm.TakeMoney(1m);

            //balanceChangedEvent.Should().NotBeNull();
            //balanceChangedEvent.Delta.Should().Be(1.01m);

            //var balanceChangedEvent = atm.DomainEvents[0] as BalanceChangedEvent;
            //balanceChangedEvent.Should().NotBeNull();
            //balanceChangedEvent.Delta.Should().Be(1.01m);

            atm.ShouldContainBalanceChangedEvent(1.01m);
        }
    }

    internal static class AtmExtensions
    {
        public static void ShouldContainBalanceChangedEvent(this Atm atm, decimal delta)
        {
            BalanceChangedEvent domainEvent = (BalanceChangedEvent)atm.DomainEvents.SingleOrDefault(x => x.GetType() == typeof(BalanceChangedEvent));

            domainEvent.Should().NotBeNull();
            domainEvent.Delta.Should().Be(delta);
        }
    }
}
