using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom.Seeds;

public readonly partial struct Xoroshiro128plusplus : IPseudoRandomSeed<Xoroshiro128plusplus>, IEquatable<Xoroshiro128plusplus>
{
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
