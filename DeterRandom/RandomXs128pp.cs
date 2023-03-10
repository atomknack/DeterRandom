using System;
using DeterRandom.Seeds;

namespace DeterRandom;

public sealed partial class RandomXs128pp: AbstractRandom<Xoroshiro128plusplus>, IEquatable<RandomXs128pp>
{
    public static RandomXs128pp Create(long preseed) =>
        new RandomXs128pp(Xoroshiro128plusplus.Create(unchecked((long)SaltMaker.ValueToSalty(preseed))));
}
