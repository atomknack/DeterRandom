using System;

namespace DeterRandom.Seeds;

// SplitMix64 in form of readonly struct
public readonly struct SplitMix64: IPseudoRandomSeed<SplitMix64> ,IEquatable<SplitMix64>
{
    private readonly ulong _s0;

    public SplitMix64 CreateIdenticalCopy() =>
        new SplitMix64(_s0);
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

    public void NextSeed(out SplitMix64 nextSeedPlaceholder)
    {
        nextSeedPlaceholder = new SplitMix64(NextSeed(_s0));
    }
    public void NextSaltedSeed(out SplitMix64 nextSeedPlaceholder, ulong salt)
    {
        nextSeedPlaceholder = new SplitMix64(NextSeed(unchecked(_s0 + SaltMaker.ValueToSalty(salt))));
    }

    private SplitMix64(ulong seed)
    {
        _s0 = seed;
    }
    public static ulong NextSeed(ulong seed)
    {
        unchecked
        {
            return seed + 0x9e3779b97f4a7c15;
        }
    }
    public static ulong PseudoRandom(ulong seed)
    {
        unchecked
        {
            ulong z = seed;
            z = (z ^ (z >> 30)) * 0xbf58476d1ce4e5b9;
            z = (z ^ (z >> 27)) * 0x94d049bb133111eb;
            return z ^ (z >> 31);
        }
    }


    public bool Equals(SplitMix64 other) => _s0 == other._s0;
    public override bool Equals(object obj) => obj is SplitMix64 otherSeed && Equals(otherSeed);
    public override int GetHashCode() => _s0.GetHashCode();


}
