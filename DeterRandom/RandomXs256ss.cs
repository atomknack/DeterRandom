using System;
using DeterRandom.Seeds;

namespace DeterRandom;

public sealed partial class RandomXs256ss : AbstractRandom<Xoroshiro256ss>, IEquatable<RandomXs256ss>
{
    public static RandomXs256ss Create(long preseed) =>
        new RandomXs256ss(Xoroshiro256ss.Create(unchecked((long)SaltMaker.ValueToSalty(preseed))));
}
