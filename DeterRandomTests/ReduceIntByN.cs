using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace DeterRandomTests;

public class ReduceIntByN
{
    private readonly ITestOutputHelper _output;
    public ReduceIntByN(ITestOutputHelper output)
    {
        _output = output;
    }
    public static uint Reduce(uint x, uint N)
    {
        return (uint)((ulong)x * (ulong)N) >> 32;
    }

    [Fact]
    public void Reduced()
    {
        for (uint i = 0; i < 100; i++)
        {
            for (uint j = 0; j < 20; j++)
            {
                _output.WriteLine($"{i}, {j}, {Reduce(i, j)}");
            }
        }
    }
}
