using System;

namespace DeterRandom.Seeds;

// SplitMix64 in form of readonly struct
public readonly partial struct SplitMix64
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
        ulong s0 = _s0;
        NextSeed(ref s0);
        nextSeedPlaceholder = new SplitMix64(s0);
    }
    public void NextSaltedSeed(out SplitMix64 nextSeedPlaceholder, ulong salt)
    {
        ulong s0 = _s0;
        NextSeed(ref s0);
        SaltMaker.SaltSplitMix64(ref s0, salt);
        nextSeedPlaceholder = new SplitMix64(s0);
    }

    private SplitMix64(ulong seed)
    {
        _s0 = seed;
    }


    public bool Equals(SplitMix64 other) => _s0 == other._s0;
    public override bool Equals(object obj) => obj is SplitMix64 otherSeed && Equals(otherSeed);
    public override int GetHashCode() => _s0.GetHashCode();


}
