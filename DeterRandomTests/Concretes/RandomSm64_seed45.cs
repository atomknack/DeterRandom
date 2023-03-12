using DeterRandom;
using DeterRandom.Seeds;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace DeterRandomTests;

public class RandomSm64_seed37_NextIntTests : NextIntTests
{
    protected override IRandom RandForTestSource => RandomSm64.Create(45);
}
public class RandomSm64_seed37_NextDoubleTests : NextFloatingPointTests
{
    protected override IRandom RandForTestSource => RandomSm64.Create(45);
    protected override double NextMethod(IRandom irandom) => irandom.NextDouble();
}
public class RandomSm64_seed37_NextSingleTests : NextFloatingPointTests
{
    protected override IRandom RandForTestSource => RandomSm64.Create(45);
    protected override double NextMethod(IRandom irandom) => irandom.NextSingle();
}
public class RandomSm64_seed37_NextBytesTests : NextBytesTests
{
    protected override IRandom RandForTestSource => RandomSm64.Create(45);
}

public class RandomSm64_JsonTests : JsonTests<RandomSm64>
{
    public override string FolderName => "RandomSm64";

    protected override void AfterEveryTest()
    {
    }
}

public class RandomSm64_seed37_WriteRandomBitmaps : WriteRandomBitmaps
{
    protected override IRandom RandForTestSource => RandomSm64.Create(37);
    protected override IRandom Rand(int preseed) => RandomSm64.Create(preseed);
}