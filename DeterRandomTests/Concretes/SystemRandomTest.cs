using DeterRandom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterRandomTests;

public class SystemRandomWrapped : System.Random, IRandom
{
    public SystemRandomWrapped(int Seed) : base(Seed)
    {
    }

    public void GetItems<TItem>(ReadOnlySpan<TItem> choices, Span<TItem> destination) => throw new NotImplementedException();

    public double NextDoubleInclusive() => throw new NotImplementedException();

    public uint NextUInt32() => throw new NotImplementedException();

    public ulong NextUInt64() => throw new NotImplementedException();

    public void Reset() => throw new NotImplementedException();

    public void Salt(ulong salt) => throw new NotImplementedException();

    public void Shuffle<TItem>(Span<TItem> values) => throw new NotImplementedException();
}


public class SystemRandomForTest_seed37_NextIntTests : NextIntTests
{
    protected override IRandom RandForTestSource => new SystemRandomWrapped(37);
}
public class SystemRandomForTest_seed37_NextDoubleTests : NextFloatingPointTests
{
    protected override IRandom RandForTestSource => new SystemRandomWrapped(37);
    protected override double NextMethod(IRandom irandom) => irandom.NextDouble();
}
public class SystemRandomForTest_seed37_NextSingleTests : NextFloatingPointTests
{
    protected override IRandom RandForTestSource => new SystemRandomWrapped(37);
    protected override double NextMethod(IRandom irandom) => irandom.NextSingle();
}
public class SystemRandomForTest_seed37_NextBytesTests : NextBytesTests
{
    protected override IRandom RandForTestSource => new SystemRandomWrapped(37);
}