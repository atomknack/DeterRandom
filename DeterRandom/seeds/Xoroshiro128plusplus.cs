using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom.Seeds;

public readonly partial struct Xoroshiro128plusplus : IPseudoRandomSeed<Xoroshiro128plusplus>, IEquatable<Xoroshiro128plusplus>
{
    public static Xoroshiro128plusplus Create(long preSeed) =>
        unchecked(new Xoroshiro128plusplus(SplitMix64.NextSeed((ulong)preSeed), SplitMix64.PseudoRandom((ulong)preSeed)));

    public ulong CurrentPseudoRandom()
    {
        unchecked
        {
            return BitHelpers.Rotl64(_s0 + _s1, 17) + _s0;
        }
    }
    internal static void NextSeed(ref ulong s0, ref ulong s1)
    {
        unchecked
        {
            s1 = s1 ^ s0;
            s0 = BitHelpers.Rotl64(s0, 49) ^ s1 ^ (s1 << 21);
            s1 = BitHelpers.Rotl64(s1, 28);
        }
    }
}
