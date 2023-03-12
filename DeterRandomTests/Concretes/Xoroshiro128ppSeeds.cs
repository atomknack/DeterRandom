using DeterRandom;
using DeterRandom.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace DeterRandomTests;

public class Xoroshiro128ppSeeds : JsonTests<Xoroshiro128pp>
{
    private ITestOutputHelper _output;

    public Xoroshiro128ppSeeds(ITestOutputHelper output)
    {
        _output = output;
    }
    public override string FolderName => nameof(Xoroshiro128ppSeeds);

    protected override void AfterEveryTest()
    {
        //if no memory leak then should be small number, not bigger than number of testing threads*2
        //last time was 1
        //_output.WriteLine(Xoroshiro128plusplus.NewtonJson_Xoroshiro128plusplus.s_pool.Count.ToString());

    }
}
