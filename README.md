# DeterRandom

This library has multiple(2 at the moment) Random generators and made with mind of easy extension of additional generator types. 
Generators xoshiro and SplitMix based on code written in 2019 by David Blackman and Sebastiano Vigna (vigna@acm.org) and released by them under [public domain](http://creativecommons.org/publicdomain/zero/1.0/)

If you interested in their original work you can find it at https://prng.di.unimi.it

This library has additional features compared to Random from standard Net:
1) Reset generator to it's initial state
2) Make a new generator from existing one, that will use current state as an initial
3) You also can make a new generator by salting existing one.
4) Salting algorithms here is made by me and I can NOT say that they are having any mathematical base whatsoever, but probably fine :)
5) All generators in this library can be Serialized and Deserialized from Json by using Newtonsoft.Json
6) Json serialization support made in files with the corresponding name ending, and therefore can be easily removed if you don't need it.
