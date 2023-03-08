using DeterRandom;
using DeterRandom.Seeds;

namespace DeterRandomTests;
public class SplitMixSeed_Test
{
    private sealed class RandomSplitMixForTest : AbstractRandom<SplitMix64>
    {
        public RandomSplitMixForTest(SplitMix64 seed) : base(seed)
        {}

        public override AbstractRandom<SplitMix64> CreateFromCurrentState() =>
            new RandomSplitMixForTest(_seed);
    }

    
    public class SplitMix64_seed37_WriteRandomBitmaps : WriteRandomBitmaps
    {
        protected override IRandom RandForTestSource => new RandomSplitMixForTest(SplitMix64.Create(37));
        protected override IRandom Rand(int preseed) => new RandomSplitMixForTest(SplitMix64.Create(preseed));
    }
    
}
