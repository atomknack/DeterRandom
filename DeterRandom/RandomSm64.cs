using System;
using DeterRandom.Seeds;

namespace DeterRandom;

public sealed partial class RandomSm64 : AbstractRandom<SplitMix64>, IEquatable<RandomSm64>
{
    public static RandomSm64 Create(long preseed) =>
        new RandomSm64(SplitMix64.Create(unchecked((long)SaltMaker.ValueToSalty(preseed))));
}
