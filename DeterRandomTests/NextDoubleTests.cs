using DeterRandom;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterRandomTests;

public abstract class NextFloatingPointTests
{
    protected abstract IRandom RandForTestSource { get; }
    protected abstract double NextMethod(IRandom irandom);

    [Theory]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void NextRandom(int len)
    {
        var randomUT = RandForTestSource;
        for (int i = 0; i < len; i++)
        {
            double next = NextMethod(randomUT);
            next.Should().BeGreaterThanOrEqualTo(0d).And.BeLessThan(1d);
        }
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(10, 3)]
    [InlineData(100, 40)]
    [InlineData(255, 120)]
    [InlineData(300, 140)]
    public void CountOfIncreasing(int len, int expectedCount)
    {
        var randomUT = RandForTestSource;
        double prev = 0;
        int count = 0;
        for (int i = 0; i < len; i++)
        {
            double next = NextMethod(randomUT);
            if (prev < next)
                count++;
            prev = next;
        }
        count.Should().BeGreaterThanOrEqualTo(expectedCount);
    }
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(10, 3)]
    [InlineData(100, 40)]
    [InlineData(255, 120)]
    [InlineData(300, 139)]
    public void CountOfDecreasing(int len, int expectedCount)
    {
        var randomUT = RandForTestSource;
        double prev = 0;
        int count = 0;
        for (int i = 0; i < len; i++)
        {
            double next = NextMethod(randomUT);
            if (prev > next)
                count++;
            prev = next;
        }
        count.Should().BeGreaterThanOrEqualTo(expectedCount);
    }
}
