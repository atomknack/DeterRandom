using BenchmarkDotNet.Running;
using Benchmarks;

namespace Bechmarks;

public class Program
{
    public static void Main(string[] args)
    {
        //var summary = BenchmarkRunner.Run<RandomsBenchmark>();
        var summary = BenchmarkRunner.Run<ResetBenchmark>();

    }
}
