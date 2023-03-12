using DeterRandom;
using DeterRandom.Seeds;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace DeterRandomTests;

public class RandomXs256ss_seed37_NextIntTests : NextIntTests
{
    protected override IRandom RandForTestSource => RandomXs256ss.Create(37);
}
public class RandomXs256ss_seed37_NextDoubleTests : NextFloatingPointTests
{
    protected override IRandom RandForTestSource => RandomXs256ss.Create(37);
    protected override double NextMethod(IRandom irandom) => irandom.NextDouble();
}
public class RandomXs256ss_seed37_NextSingleTests : NextFloatingPointTests
{
    protected override IRandom RandForTestSource => RandomXs256ss.Create(37);
    protected override double NextMethod(IRandom irandom) => irandom.NextSingle();
}
public class RandomXs256ss_seed37_NextBytesTests : NextBytesTests
{
    protected override IRandom RandForTestSource => RandomXs256ss.Create(37);
}


public class RandomXs256ss_JsonTests : JsonTests<RandomXs256ss>
{
    public override string FolderName => "RandomXs256ss";

    protected override void AfterEveryTest()
    {
    }
}



public class RandomXs256ss_seed37_WriteRandomBitmaps : WriteRandomBitmaps
{
    protected override IRandom RandForTestSource => RandomXs256ss.Create(37);
    protected override IRandom Rand(int preseed) => RandomXs256ss.Create(preseed);
}