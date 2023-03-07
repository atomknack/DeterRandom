/*
using DeterRandom.Seeds;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;

namespace DeterRandom;

//public static RandomXs128pp Shared = RandomXs128pp.CreateFromPreSeed(42);
[JsonConverter(typeof(NewtonJson_RandomXs128pp))]
public sealed partial class RandomXs128pp
{
    //Thread safe implemenatation with pool(bag) for temp json objects
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    private class NewtonJson_RandomXs128pp : JsonConverter<RandomXs128pp>
    {
        //to check that no memory leaks change this class and static field to internal and uncomment counter in AfterEveryTest() in test project.
        private static readonly ConcurrentBag<NewtonJson_RandomXs128pp> s_pool = new ConcurrentBag<NewtonJson_RandomXs128pp>();
        [JsonRequired]
        public Xoroshiro128plusplus initialSeed;
        [JsonProperty(Required = Required.Default)]
        public Xoroshiro128plusplus? current;
        private static NewtonJson_RandomXs128pp FromPool()
        {
            NewtonJson_RandomXs128pp o;
            if (s_pool.TryTake(out o) == false)
                o = new NewtonJson_RandomXs128pp();
            //if (o.current.HasValue)
            o.current = null;
            return o;
        }
        public override void WriteJson(JsonWriter writer, RandomXs128pp value, JsonSerializer serializer)
        {
            NewtonJson_RandomXs128pp o = FromPool();
            unchecked
            {
                o.initialSeed = value._initialSeed;
                o.current = value._seed;
            }
            serializer.Serialize(writer, o);
            s_pool.Add(o);
        }

        public override RandomXs128pp ReadJson(JsonReader reader, Type objectType, RandomXs128pp existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            NewtonJson_RandomXs128pp o = FromPool();
            serializer.Populate(reader, o);
            RandomXs128pp result;
            if (o.current.HasValue)
                result = new RandomXs128pp(o.initialSeed, o.current.Value);
            else
                result = new RandomXs128pp(o.initialSeed);
            s_pool.Add(o);
            return result;
        }
    }
}
*/