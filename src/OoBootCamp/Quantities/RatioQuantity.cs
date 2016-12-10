/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

namespace OoBootCamp.Quantities
{
    // Understands a specific measurement of a Ratio metric
    public class RatioQuantity : IntervalQuantity, Sequenceable<RatioQuantity>
    {

        protected internal RatioQuantity(double amount, Unit unit) : base(amount, unit)
        {
        }
        public static RatioQuantity operator -(RatioQuantity q)
        {
            return new RatioQuantity(-q.Amount, q.Unit);
        }

        public static RatioQuantity operator +(RatioQuantity left, RatioQuantity right)
        {
            return new RatioQuantity(left.Amount + left.ConvertedAmount(right), left.Unit);
        }

        public static RatioQuantity operator -(RatioQuantity left, RatioQuantity right)
        {
            return left + -right;
        }

        public bool IsBetterThan(RatioQuantity other)
        {
            return this.Amount > ConvertedAmount(other);
        }
    }
}