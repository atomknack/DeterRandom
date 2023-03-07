using System;

namespace DeterRandom.Seeds;

public readonly partial struct Xoroshiro128plusplus : IPseudoRandomSeed<Xoroshiro128plusplus> ,IEquatable<Xoroshiro128plusplus>
{
    private readonly ulong _s0;
    private readonly ulong _s1;

    public static Xoroshiro128plusplus Create(long preSeed) =>
        unchecked(new Xoroshiro128plusplus(SplitMix64.NextSeed((ulong)preSeed), SplitMix64.PseudoRandom((ulong)preSeed)));


    public ulong CurrentPseudoRandom()
    {
        unchecked
        {
            return BitHelpers.Rotl64(_s0 + _s1, 17) + _s0;
        }
    }

    public void NextSaltedSeed(out Xoroshiro128plusplus nextSeedPlaceholder, ulong salt)
    {
        ulong s0 = _s0;
        ulong s1 = _s1;

        SaltMaker.SaltTwoSameWay(ref s0, ref s1, SaltMaker.ValueToSalty(salt));
        NextSeed(ref s0, ref s1);
        nextSeedPlaceholder = new Xoroshiro128plusplus(s0, s1);
    }

    public void NextSeed(out Xoroshiro128plusplus nextSeedPlaceholder)
    {
        ulong s0 = _s0;
        ulong s1 = _s1;
        NextSeed(ref s0, ref s1);
        nextSeedPlaceholder = new Xoroshiro128plusplus(s0, s1);
    }

    public static void NextSeed(ref ulong s0, ref ulong s1)
    {
        unchecked
        {
            s1 = s1 ^ s0;
            s0 = BitHelpers.Rotl64(s0, 49) ^ s1 ^ (s1 << 21);
            s1 = BitHelpers.Rotl64(s1, 28);
        }
    }

    public Xoroshiro128plusplus CreateIdenticalCopy() => 
        new Xoroshiro128plusplus(_s0, _s1);

    private Xoroshiro128plusplus(ulong s0, ulong s1)
    {
        _s0 = s0;
        _s1 = s1;
    }

    public bool Equals(Xoroshiro128plusplus other) => _s0 == other._s0 && _s1 == other._s1;
    public override bool Equals(object obj) => obj is Xoroshiro128plusplus otherSeed && Equals(otherSeed);
    public override int GetHashCode() => _s0.GetHashCode();
    public override string ToString() => $"(s0:{_s0.ToString()}, s1:{_s1.ToString()})";

}
