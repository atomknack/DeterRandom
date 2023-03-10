//----------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Random_Common
//     Changes will be lost if the code is regenerated.
// </auto-generated>
//----------------------------------------------------------------------------------------

using System;
using DeterRandom.Seeds;

namespace DeterRandom;

public sealed partial class RandomXs128pp
{
    private static readonly RandomXs128pp _shared = Create(42);
    public static RandomXs128pp Shared { get => _shared; }

    public override AbstractRandom<Xoroshiro128plusplus> CreateFromCurrentState() => 
        new RandomXs128pp(_seed);

    private RandomXs128pp(Xoroshiro128plusplus seed): base(seed) { }
    private RandomXs128pp(Xoroshiro128plusplus initial, Xoroshiro128plusplus current): base(initial, current) { }
    public override bool Equals(object obj) => obj is RandomXs128pp otherSeed && Equals(otherSeed);
    public bool Equals(RandomXs128pp other) => _initialSeed.Equals(other._initialSeed) && _seed.Equals(other._seed);
    public override int GetHashCode() => _seed.GetHashCode();
    public override string ToString() => $"(initial:{_initialSeed}, _seed:{_seed})";
}


