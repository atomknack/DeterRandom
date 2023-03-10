using System;

namespace DeterRandom.Seeds;

public readonly partial struct Xoroshiro256ss : IPseudoRandomSeed<Xoroshiro256ss> ,IEquatable<Xoroshiro256ss>
{

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

}
