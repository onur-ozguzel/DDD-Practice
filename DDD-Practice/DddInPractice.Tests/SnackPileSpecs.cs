using DddInPractice.Logic.SnackMachines;
using FluentAssertions;
using System;
using Xunit;

namespace DddInPractice.Tests
{
    public class SnackPileSpecs
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void Cannot_insert_negative_quantity(int quantity)
        {
            Action action = () => { SnackPile snackPile = new SnackPile(null, quantity, 0m); };

            action.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(-0.01)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void Cannot_insert_negative_price(decimal price)
        {
            Action action = () => { SnackPile snackPile = new SnackPile(null, 0, price); };

            action.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(0.001)]
        [InlineData(0.002)]
        [InlineData(0.009)]
        [InlineData(0.099)]
        public void Cannot_insert_smaller_then_one_cent(decimal price)
        {
            Action action = () => { SnackPile snackPile = new SnackPile(null, 0, price); };

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
