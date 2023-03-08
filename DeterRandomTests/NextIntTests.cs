using DeterRandom;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterRandomTests;

public abstract class NextIntTests
{
    protected abstract IRandom RandForTestSource { get; }

    [Fact]
    public void NextIntFor_0_0()
    {
        var rand = new Random(1);
        var rut = RandForTestSource;
        rut.Next(0, 0).Should().Be(rand.Next(0));
        rut.Next(0, 1).Should().Be(rand.Next(1));
        rut.Next(0, 0).Should().Be(rand.Next(0, 0));
        rut.Next(0, 1).Should().Be(rand.Next(0, 1));
    }
    [Theory]
    [InlineData(0, 10)]
    [InlineData(0, 100)]
    [InlineData(-10, 10)]
    [InlineData(-20, 3)]
    [InlineData(-20, 20)]

    public void NextIntNotEmptyInterval1000Times(int minInclusive, int maxExclusive)
    {
        var rand = new Random(2);
        HashSet<int> randSet = new HashSet<int>();
        var randXs128 = RandForTestSource;
        HashSet<int> xsSet = new HashSet<int>();
        for (int i = 0; i < 1000; i++)
        {
            randSet.Add(rand.Next(minInclusive, maxExclusive));
            xsSet.Add(randXs128.Next(minInclusive, maxExclusive));
        }
        xsSet.Should().BeEquivalentTo(randSet, "Should contain equivalent elements");
        xsSet.Should().NotEqual(randSet, "Elements should be in different order");
        //xsSet.Count.Should().Be(maxExclusive - minInclusive);
    }

}
