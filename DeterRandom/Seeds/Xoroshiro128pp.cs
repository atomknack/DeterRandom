using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom.Seeds;

public readonly partial struct Xoroshiro128pp : IPseudoRandomSeed<Xoroshiro128pp>, IEquatable<Xoroshiro128pp>
{
    public static Xoroshiro128pp Create(long preSeed) =>
        unchecked(new Xoroshiro128pp(SplitMix64.NextSeed((ulong)preSeed), SplitMix64.PseudoRandom((ulong)preSeed)));

    public ulong CurrentPseudoRandomNoSeedChange()
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
    internal static void Salt(ref ulong s0, ref ulong s1, ulong salt) //totally NOT scientifical method of salting
    {
        unchecked
        {
            int saltShift = (int)(salt % 59);
            s0 = BitHelpers.Rotl64(s0 ^ salt, saltShift);
            s1 = BitHelpers.Rotl64(s1 ^ salt, saltShift);
        }
    }
}
