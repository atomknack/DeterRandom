using BenchmarkDotNet.Attributes;
using Benchmarks;
using DeterRandom;

namespace Bechmarks;

//[Config(typeof(AntiVirusFriendlyConfig))] //Uncomment if there are no result runs
//[MemoryDiagnoser]
public class RandomsBenchmark
{
    private const int N = 10000;

    private readonly Random net = new Random(42);
    private readonly RandomXs128pp xs128pp = RandomXs128pp.Create(42);
    private readonly RandomSm64 sm64 = RandomSm64.Create(42);

    //[Benchmark]
    public void NTimesDoesAllmostNothing()
    {
        long k = 0;
        for (int i = 0; i < N; i++)
        {
            k += i;
        }
    }
    [Benchmark]
    public void BenchNetRandom() => NRandomNet();
    [Benchmark]
    public void BenchXs128pp() => NRandomXs128pp();
    [Benchmark]
    public void BenchSm64() => NRandomSm64();

    public long NRandomNet()
    {
        long result = 0;
        for (int i = 0; i < N; i++)
        {
            int next = net.Next(1000);
            unchecked
            {
                result += next;
            }
        }
        return result;
    }

    public long NRandomXs128pp()
    {
        long result = 0;
        for (int i = 0; i < N; i++)
        {
            int next = xs128pp.Next(1000);
            unchecked
            {
                result += next;
            }
        }
        return result;
    }
    public long NRandomSm64()
    {
        long result = 0;
        for (int i = 0; i < N; i++)
        {
            int next = sm64.Next(1000);
            unchecked
            {
                result += next;
            }
        }
        return result;
    }
}
