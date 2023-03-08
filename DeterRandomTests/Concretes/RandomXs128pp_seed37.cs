using DeterRandom;
using DeterRandom.Seeds;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace DeterRandomTests;

public class RandomXs128pp_seed37_NextIntTests : NextIntTests
{
    protected override IRandom RandForTestSource => RandomXs128pp.Create(37);
}
public class RandomXs128pp_seed37_NextDoubleTests : NextFloatingPointTests
{
    protected override IRandom RandForTestSource => RandomXs128pp.Create(37);
    protected override double NextMethod(IRandom irandom) => irandom.NextDouble();
}
public class RandomXs128pp_seed37_NextSingleTests : NextFloatingPointTests
{
    protected override IRandom RandForTestSource => RandomXs128pp.Create(37);
    protected override double NextMethod(IRandom irandom) => irandom.NextSingle();
}
public class RandomXs128pp_seed37_NextBytesTests : NextBytesTests
{
    protected override IRandom RandForTestSource => RandomXs128pp.Create(37);
}

public class RandomXs128pp_JsonTests : JsonTests<RandomXs128pp>
{
    public override string FolderName => "RandomXs128pp";

    [Fact]
    public void FromPartialJson()
    {
        var actual = RandomXs128pp.Create(100);
        string expectedAsJson = "{ \"initialSeed\":{ \"s0\":-7045809347765830535,\"s1\":-1918337914387732858} }";
        RandomXs128pp expected = JsonConvert.DeserializeObject<RandomXs128pp>(expectedAsJson);
        actual.Should().Be(expected);

        int firstExpectedInt = expected.Next();
        firstExpectedInt.Should().NotBe(0);
        actual.Next().Should().Be(firstExpectedInt);

        actual.NextUInt64().Should().Be(expected.NextUInt64());
        actual.Next().Should().NotBe(firstExpectedInt);
        actual.ResetToInitialState();
        actual.Next().Should().Be(firstExpectedInt);

    }
    protected override void AfterEveryTest()
    {
    }
}


public class RandomXs128pp_seed37_WriteRandomBitmaps : WriteRandomBitmaps
{
    protected override IRandom RandForTestSource => RandomXs128pp.Create(37);
    protected override IRandom Rand(int preseed) => RandomXs128pp.Create(preseed);
}