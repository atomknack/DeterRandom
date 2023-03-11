using FluentAssertions;
using DeterRandom.Seeds;

namespace DeterRandomTests;

public class SimpleCreations
{
    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(42)]
    [InlineData(500)]
    public void CreateFromExported(ulong seed)
    {
        SplitMix64 created = SplitMix64.CreateFromExportedULongWithoutTransform(seed);
        created.ExportSeedAsUlong().Should().Be(seed);
        created.ExportSeedAsLong().Should().Be((long)seed);

    }
}