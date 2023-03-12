using System;
using DeterRandom.Seeds;

namespace DeterRandom;

public sealed partial class RandomXs128pp: AbstractRandom<Xoroshiro128pp>, IEquatable<RandomXs128pp>
{
    public static RandomXs128pp Create(long preseed) =>
        new RandomXs128pp(Xoroshiro128pp.Create(unchecked((long)SaltMaker.ValueToSalty(preseed))));
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
