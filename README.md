# DeterRandom

DeterRandom library in not intended for any kind of critical applications, but made with mind of easy use, speed and extension.
Currently there available random generators: 
1) RandomXs256ss - xoshiro256starstar
2) RandomXs128pp - xoroshiro128plusplus
3) RandomSm64 - SplitMix64

Generators xoshiro and SplitMix based on code written in 2019 by David Blackman and Sebastiano Vigna (vigna@acm.org) and released by them under [public domain](http://creativecommons.org/publicdomain/zero/1.0/)
You can find their original at https://prng.di.unimi.it

All operations of random generators are deterministic.
Benchmarks show, that generators 3-4 times faster than System.Random.

All generators in this library additionally can be:
1) Reset to state of it creation.
2) Made from existing one, as copy or independent derivative that will use current state as initial
3) Salted by ulong value, which will change current state, but leave initial state intact.
4) Serialized and Deserialized from Json by using Newtonsoft.Json. Json aspect is moved to separate files with corresponding name ending.

There is some known negative side, of course, but should be fine for applications like game development:
1) Salting algorithms here is made by me and I can NOT say that they are having any mathematical base whatsoever.
2) Conversion mehods from ulong to required random value type can be biased and have some minor flaws.