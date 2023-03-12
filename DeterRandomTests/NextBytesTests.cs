using DeterRandom;
using FluentAssertions;

namespace DeterRandomTests;

public abstract class NextBytesTests
{
    protected abstract IRandom RandForTestSource { get; }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(255)]
    [InlineData(300)]
    public void ArrayEqualSpan(int len)
    {
        var randomUT = RandForTestSource;
        var randomUT2 = RandForTestSource;
        byte[] bs = new byte[len];
        randomUT.NextBytes(bs);
        byte[] bs2 = new byte[len];
        randomUT2.NextBytes(bs2.AsSpan());
        bs2.Should().Equal(bs);
    }
    [Theory]
    [InlineData(0,0)]
    [InlineData(1,1)]
    [InlineData(10, 9)]
    [InlineData(100, 80)]
    [InlineData(255, 155)]
    [InlineData(300, 172)]
    public void DistinctNextBytes(int len, int expectedDistinctLen)
    {
        var randomUT = RandForTestSource;
        byte[] bs = new byte[len];
        randomUT.NextBytes(bs);
        byte[] distinct = bs.Distinct().ToArray();
        distinct.Length.Should().BeGreaterThanOrEqualTo(expectedDistinctLen);
    }
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(10, 3)]
    [InlineData(100, 40)]
    [InlineData(255, 120)]
    [InlineData(300, 138)]
    public void CountOfIncreasing(int len, int expectedCount)
    {
        var randomUT = RandForTestSource;
        byte[] bs = new byte[len];
        randomUT.NextBytes(bs);
        int count = 0;
        for (int i = 0; i < len-1; i++)
            if (bs[i] < bs[i+1])
                count++;
        count.Should().BeGreaterThanOrEqualTo(expectedCount);
    }
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(10, 3)]
    [InlineData(100, 40)]
    [InlineData(255, 120)]
    [InlineData(300, 138)]
    public void CountOfDecreasing(int len, int expectedCount)
    {
        var randomUT = RandForTestSource;
        byte[] bs = new byte[len];
        randomUT.NextBytes(bs);
        int count = 0;
        for (int i = 0; i < len - 1; i++)
            if (bs[i] > bs[i + 1])
                count++;
        count.Should().BeGreaterThanOrEqualTo(expectedCount);
    }
}
