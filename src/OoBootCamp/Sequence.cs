/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Linq;

namespace OoBootCamp
{
    // Understands ordered elements
    public class Sequence
    {
        public static T Max<T>(T[] elements) where T : Sequenceable<T>
        {
            T champion = elements.First();
            foreach (var challenger in elements)
            {
                champion = challenger.IsBetterThan(champion) ? challenger : champion;
            }
            return champion;
        }
    }

    // Understands rules to be ordered elements
    public interface Sequenceable<T>
    {
        bool IsBetterThan(T other);
    }
}