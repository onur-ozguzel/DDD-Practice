﻿using DddInPractice.Logic.Common;
using System;

namespace DddInPractice.Logic.SnackMachines
{
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        public static readonly SnackPile Empty = new SnackPile(Snack.None, 0, 0);
        public Snack Snack { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public SnackPile()
        {
        }

        public SnackPile(Snack snack, int quantity, decimal price) : this()
        {
            if (quantity < 0) throw new InvalidOperationException();
            if (price < 0) throw new InvalidOperationException();
            if (price % 0.01m > 0) throw new InvalidOperationException();

            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        public SnackPile SubtrackOne()
        {
            return new SnackPile(Snack, Quantity - 1, Price);
        }

        protected override bool EqualsCore(SnackPile other)
        {
            return Snack == other.Snack &&
                Quantity == other.Quantity &&
                Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Snack.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }
    }
}
