//----------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Random_Common
//     Changes will be lost if the code is regenerated.
// </auto-generated>
//----------------------------------------------------------------------------------------

using System;
using DeterRandom.Seeds;

namespace DeterRandom;

public sealed partial class RandomSm64
{
    private static readonly RandomSm64 _shared = Create(42);
    public static RandomSm64 Shared { get => _shared; }

    public override AbstractRandom<SplitMix64> CreateFromCurrentState() => 
        new RandomSm64(_seed);

    private RandomSm64(SplitMix64 seed): base(seed) { }
    private RandomSm64(SplitMix64 initial, SplitMix64 current): base(initial, current) { }
    public override bool Equals(object obj) => obj is RandomSm64 otherSeed && Equals(otherSeed);
    public bool Equals(RandomSm64 other) => _initialSeed.Equals(other._initialSeed) && _seed.Equals(other._seed);
    public override int GetHashCode() => _seed.GetHashCode();
    public override string ToString() => $"(initial:{_initialSeed}, _seed:{_seed})";
}

