using BenchmarkDotNet.Running;

namespace Bechmarks;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<RandomsBenchmark>();

    }
}
