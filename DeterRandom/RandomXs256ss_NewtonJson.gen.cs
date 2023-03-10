//----------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Random_NewtonJson
//     Changes will be lost if the code is regenerated.
// </auto-generated>
//----------------------------------------------------------------------------------------

using DeterRandom.Seeds;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;

namespace DeterRandom;

//public static RandomXs256ss Shared = RandomXs256ss.CreateFromPreSeed(42);
[JsonConverter(typeof(NewtonJson_RandomXs256ss))]
public sealed partial class RandomXs256ss
{
    //Thread safe implemenatation with pool(bag) for temp json objects
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    private class NewtonJson_RandomXs256ss : JsonConverter<RandomXs256ss>
    {
        //to check that no memory leaks change this class and static field to internal and uncomment counter in AfterEveryTest() in test project.
        private static readonly ConcurrentBag<NewtonJson_RandomXs256ss> s_pool = new ConcurrentBag<NewtonJson_RandomXs256ss>();
        [JsonRequired]
        public Xoroshiro256ss initialSeed;
        [JsonProperty(Required = Required.Default)]
        public Xoroshiro256ss? current;
        private static NewtonJson_RandomXs256ss FromPool()
        {
            NewtonJson_RandomXs256ss o;
            if (s_pool.TryTake(out o) == false)
                o = new NewtonJson_RandomXs256ss();
            //if (o.current.HasValue)
            o.current = null;
            return o;
        }
        public override void WriteJson(JsonWriter writer, RandomXs256ss value, JsonSerializer serializer)
        {
            NewtonJson_RandomXs256ss o = FromPool();
            unchecked
            {
                o.initialSeed = value._initialSeed;
                o.current = value._seed;
            }
            serializer.Serialize(writer, o);
            s_pool.Add(o);
        }

        public override RandomXs256ss ReadJson(JsonReader reader, Type objectType, RandomXs256ss existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            NewtonJson_RandomXs256ss o = FromPool();
            serializer.Populate(reader, o);
            RandomXs256ss result;
            if (o.current.HasValue)
                result = new RandomXs256ss(o.initialSeed, o.current.Value);
            else
                result = new RandomXs256ss(o.initialSeed);
            s_pool.Add(o);
            return result;
        }
    }
}

