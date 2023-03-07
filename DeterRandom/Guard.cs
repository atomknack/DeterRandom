using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom
{
    internal static class Guard
    {
        internal static void ThrowIfMinBiggerThanMax(int min, int max)
        {
            if (min > max)
                throw new ArgumentOutOfRangeException($"{min} value bigger that {max} value");
        }
        internal static void ThrowIfEmpty<S>(Span<S> span)
        {
            if (span.IsEmpty)
                throw new ArgumentException($"{nameof(span)} is empty, but should not be");
        }
        internal static void ThrowIfEmpty<S>(ReadOnlySpan<S> span)
        {

            if (span.IsEmpty)
                throw new ArgumentException($"{nameof(span)} is empty, but should not be");
        }
        internal static void ThrowIfNull<S>(S[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
        }
    }
}
