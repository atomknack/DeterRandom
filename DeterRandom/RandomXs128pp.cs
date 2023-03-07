using System;
using DeterRandom.Seeds;

namespace DeterRandom;

public sealed partial class RandomXs128pp: AbstractRandom<Xoroshiro128plusplus>, IEquatable<RandomXs128pp>
{
    private static readonly RandomXs128pp _shared = Create(42);
    public static RandomXs128pp Shared { get => _shared; }

    public static RandomXs128pp Create(long preseed) =>
        new RandomXs128pp(Xoroshiro128plusplus.Create(unchecked((long)SaltMaker.ValueToSalty(preseed))));

    public override AbstractRandom<Xoroshiro128plusplus> CreateFromCurrentState() => 
        new RandomXs128pp(_seed);

    private RandomXs128pp(Xoroshiro128plusplus seed): base(seed) { }
    private RandomXs128pp(Xoroshiro128plusplus initial, Xoroshiro128plusplus current): base(initial, current) { }
    public override bool Equals(object obj) => obj is RandomXs128pp otherSeed && Equals(otherSeed);
    public bool Equals(RandomXs128pp other) => _initialSeed.Equals(other._initialSeed) && _seed.Equals(other._seed);
    public override int GetHashCode() => _seed.GetHashCode();
    public override string ToString() => $"(initial:{_initialSeed}, _seed:{_seed})";
}
