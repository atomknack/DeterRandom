using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom;

public partial class AbstractRandom<T>
{
    private static class PrivateStatic
    {
        internal static int NextInt32<S>(ref S seed) where S : IPseudoRandomSeed<S>
        {
            return BitHelpers.LossyConversionToInt32(NextPseudo(ref seed));
        }

        [Obsolete("Not tested")]
        internal static int NextInt32<S>(ref S seed, int minValue, int maxValue) where S : IPseudoRandomSeed<S>
        {
            //if (minValue > maxValue)
            Guard.ThrowIfMinBiggerThanMax(minValue, maxValue);
            ulong pseudo = NextPseudo(ref seed);
            ulong diff = (ulong)(maxValue - minValue);
            if (diff < 2)
                return minValue;
            int result = (int)(pseudo % diff);
            return result + minValue;
        }

        internal static ulong NextPseudo<S>(ref S seed) where S : IPseudoRandomSeed<S>
        {
            ulong result = seed.CurrentPseudoRandom();
            seed.NextSeed(out seed);
            return result;
        }
        internal static void NextBytes<S>(ref S seed, Span<byte> bytes) where S : IPseudoRandomSeed<S>
        {
            for (int i = 0; i < bytes.Length; ++i)
            {
                ulong pseudo = NextPseudo(ref seed);
                bytes[i] = (byte)(pseudo & BitHelpers.BYTE_MASK);
            }
        }
        internal static void GetItems<S,TItem>(ref S seed, ReadOnlySpan<TItem> choices, Span<TItem> destination) where S : IPseudoRandomSeed<S>
        {
            Guard.ThrowIfEmpty(choices);
            for (int i = 0; i < destination.Length; i++)
                destination[i] = choices[NextInt32(ref seed,0,choices.Length)];
        }
        internal static void Shuffle<S, TItem>(ref S seed, Span<TItem> values) where S : IPseudoRandomSeed<S>
        {
            int n = values.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int other = NextInt32(ref seed, i, n);
                if (other != i)
                    (values[i], values[other]) = (values[other], values[i]);
            }
        }
    }
}
