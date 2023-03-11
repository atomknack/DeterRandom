using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom.Seeds;

public readonly partial struct SplitMix64 : IPseudoRandomSeed<SplitMix64>, IEquatable<SplitMix64>
{
    public static SplitMix64 CreateFromCurrentTime() =>
        Create(DateTime.Now.Ticks);
    public static SplitMix64 Create(long valuePreSeed) =>
        Create(unchecked((ulong)valuePreSeed));
    public static SplitMix64 Create(ulong valuePreSeed) =>
        new SplitMix64(NextSeed(valuePreSeed));
    public static SplitMix64 CreateFromExportedULongWithoutTransform(ulong exported) =>
        new SplitMix64(exported);
    public static SplitMix64 CreateWithAdditionalOffset(SplitMix64 seed, ulong offset) =>
        new SplitMix64(unchecked(seed._s0 + offset));

    public ulong CurrentPseudoRandom() => PseudoRandom(_s0);

    public ulong ExportSeedAsUlong() => _s0;
    public long ExportSeedAsLong() => unchecked((long)_s0);


    public static ulong NextSeed(ulong s0)
{
        ulong seed = s0;
        NextSeed(ref seed);
        return seed;
}
    internal static void NextSeed(ref ulong s0)
    {
        unchecked
        {
            s0 = s0 + 0x9e3779b97f4a7c15;
        }
    }
    internal static ulong PseudoRandom(ulong seed)
    {
        unchecked
        {
            ulong z = seed;
            z = (z ^ (z >> 30)) * 0xbf58476d1ce4e5b9;
            z = (z ^ (z >> 27)) * 0x94d049bb133111eb;
            return z ^ (z >> 31);
        }
    }
}
