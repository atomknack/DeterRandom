using Xunit.Abstractions;

namespace DeterRandomTests;

public class ReduceIntByN
{

    private readonly ITestOutputHelper _output;
    public ReduceIntByN(ITestOutputHelper output)
    {
        _output = output;
    }
    //trying idea from https://lemire.me/blog/2016/06/27/a-fast-alternative-to-the-modulo-reduction/
    public static uint Reduce(uint x, uint N)
    {
        return (uint)((ulong)x * (ulong)N) >> 32;
    }

    [Fact]
    //test is part of search for replacement of int % n in random ulong to int 0..N mapping
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
