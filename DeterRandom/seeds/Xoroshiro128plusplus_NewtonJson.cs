using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom.Seeds;

//public static RandomXs128pp Shared = RandomXs128pp.CreateFromPreSeed(42);
[JsonConverter(typeof(NewtonJson_Xoroshiro128plusplus))]
public readonly partial struct Xoroshiro128plusplus
{
    //Thread safe implemenatation with pool(bag) for temp json objects
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    //internal
    private 
        class NewtonJson_Xoroshiro128plusplus : JsonConverter<Xoroshiro128plusplus>
    {
        //to check that no memory leaks change this class and static field to internal and uncomment counter in AfterEveryTest() in test project.
        //internal
        private 
            static readonly ConcurrentBag<NewtonJson_Xoroshiro128plusplus> s_pool = new ConcurrentBag<NewtonJson_Xoroshiro128plusplus>();
        [JsonRequired]
        public long s0;
        [JsonRequired]
        public long s1;

        private static NewtonJson_Xoroshiro128plusplus FromPool() =>
            s_pool.TryTake(out NewtonJson_Xoroshiro128plusplus o) ? o : new NewtonJson_Xoroshiro128plusplus();
        private static void ReturnToPool(NewtonJson_Xoroshiro128plusplus o) => 
            s_pool.Add(o);
        public override void WriteJson(JsonWriter writer, Xoroshiro128plusplus value, JsonSerializer serializer)
        {
            NewtonJson_Xoroshiro128plusplus o = FromPool();
            unchecked
            {
                o.s0 = (long)value._s0;
                o.s1 = (long)value._s1;
            }

            serializer.Serialize(writer, o);
            ReturnToPool(o);
        }

        public override Xoroshiro128plusplus ReadJson(JsonReader reader, Type objectType, Xoroshiro128plusplus existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            //NewtonJson_Xoroshiro128plusplus o = serializer.Deserialize<NewtonJson_Xoroshiro128plusplus>(reader);
            NewtonJson_Xoroshiro128plusplus o = FromPool();
            serializer.Populate(reader, o);
            Xoroshiro128plusplus result = unchecked(new Xoroshiro128plusplus((ulong)o.s0, (ulong)o.s1));
            ReturnToPool(o);
            return result;
        }
    }
}
