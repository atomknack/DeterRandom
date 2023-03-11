using BenchmarkDotNet.Attributes;
using DeterRandom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks;

[MemoryDiagnoser]
public class ResetBenchmark
{
    private const int RESETS = 100;
    private const int NRANDS = 100;

    [Benchmark]
    public int ResetXs256AsInterface()
    {
        int next = 0;
        IRandom rand = RandomXs256ss.Create(70);
        for (int i = 0; i < RESETS; ++i)
        {
            rand.Reset();
            for (int j = 0; j < NRANDS; ++j)
            {
                next ^= rand.Next();
            }
        }
        return next;
    }
    [Benchmark]
    public int ResetXs256()
    {
        int next = 0;
        RandomXs256ss rand = RandomXs256ss.Create(70);
        for (int i = 0; i < RESETS; ++i)
        {
            rand.ResetToInitialState();
            for (int j = 0; j < NRANDS; ++j)
            {
                next ^= rand.Next();
            }
        }
        return next;
    }
    [Benchmark]
    public int ResetXs128()
    {
        int next = 0;
        RandomXs128pp rand = RandomXs128pp.Create(70);
        for (int i = 0; i < RESETS; ++i)
        {
            rand.ResetToInitialState();
            for (int j = 0; j < NRANDS; ++j)
            {
                next ^= rand.Next();
            }
        }
        return next;
    }
    [Benchmark]
    public int ResetNet()
    {
        int next = 0;
        for (int i = 0; i < RESETS; ++i)
        {
            Random rand = new Random(70);
            for (int j = 0; j < NRANDS; ++j)
            {
                next ^= rand.Next();
            }
        }
        return next;
    }
}