using System;

namespace DeterRandom.Seeds;

public readonly partial struct Xoroshiro256ss : IPseudoRandomSeed<Xoroshiro256ss> ,IEquatable<Xoroshiro256ss>
{
    public static Xoroshiro256ss Create(long preSeed)
    {
        unchecked
        {
            ulong s0 = SplitMix64.NextSeed((ulong)preSeed);
            ulong s1 = SplitMix64.PseudoRandom((ulong)preSeed);
            ulong s2 = SplitMix64.NextSeed(s0);
            ulong s3 = SplitMix64.PseudoRandom(s2 ^ s1);
            return new Xoroshiro256ss(s0, s1, s2, s3);
        }
    }

    public ulong CurrentPseudoRandomNoSeedChange()
    {
        unchecked
        {
            return BitHelpers.Rotl64(_s1 * 5, 7) * 9;
        }
    }

    internal static void NextSeed(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3)
    {
        unchecked
        {
            ulong t = s1 << 17;
            s2 = s2 ^ s0;
            s3 = s3 ^ s1;
            s1 = s1 ^ s2;
            s0 = s0 ^ s3;

            s2 = s2 ^ t;
            s3 = BitHelpers.Rotl64(s3, 45);
        }
    }
    internal static void Salt(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ulong salt) //totally NOT scientifical method of salting
    {
        unchecked
        {
            int saltShift = (int)(salt % 59);
            s0 = BitHelpers.Rotl64(s0 ^ salt, saltShift);
            s1 = BitHelpers.Rotl64(s1 ^ salt, saltShift);
            s2 = BitHelpers.Rotl64(s2 ^ salt, saltShift);
            s3 = BitHelpers.Rotl64(s3 ^ salt, saltShift);
        }
    }

}
