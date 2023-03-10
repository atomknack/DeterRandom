using System;

namespace DeterRandom.Seeds;

public readonly partial struct Xoroshiro256ss : IPseudoRandomSeed<Xoroshiro256ss> ,IEquatable<Xoroshiro256ss>
{
    private readonly ulong _s0;
    private readonly ulong _s1;
    private readonly ulong _s2;
    private readonly ulong _s3;

    public static Xoroshiro256ss Create(long preSeed)
    {
        unchecked
        {
            ulong s0 = SplitMix64.NextSeed((ulong)preSeed);
            ulong s1 = SplitMix64.PseudoRandom((ulong)preSeed);
            ulong s2 = SplitMix64.NextSeed(s0);
            ulong s3 = SplitMix64.PseudoRandom(s2^s1);
            return new Xoroshiro256ss(s0, s1, s2, s3);
        }
    }



    public ulong CurrentPseudoRandom()
    {
        unchecked
        {
            return BitHelpers.Rotl64(_s1 * 5, 7) * 9;
        }
    }

    public void NextSaltedSeed(out Xoroshiro256ss nextSeedPlaceholder, ulong salt)
    {
        unchecked
        {
            ulong t = _s1 << 17;
            ulong s2 = _s2 ^ _s0;
            ulong s3 = _s3 ^ _s1;
            ulong s1 = _s1 ^ s2;
            ulong s0 = _s0 ^ s3;

            s2 = _s2 ^ t;
            s3 = BitHelpers.Rotl64(s3, 45);

            SaltMaker.SaltFourSameWay(ref s0, ref s1, ref s2, ref s3, SaltMaker.ValueToSalty(salt));
            nextSeedPlaceholder = new Xoroshiro256ss(s0, s1, s2, s3);
        }
    }

    public void NextSeed(out Xoroshiro256ss nextSeedPlaceholder)
    {
        unchecked
        {
            ulong t = _s1 << 17;
            ulong s2 = _s2 ^ _s0;
            ulong s3 = _s3 ^ _s1;
            ulong s1 = _s1 ^ s2;
            ulong s0 = _s0 ^ s3;

            s2 = _s2 ^ t;
            s3 = BitHelpers.Rotl64(s3, 45);

            //SaltMaker.SaltFourSameWay(ref s0, ref s1, ref s2, ref s3, SaltMaker.ValueToSalty(salt));
            nextSeedPlaceholder = new Xoroshiro256ss(s0, s1, s2, s3);
        }
    }

    public Xoroshiro256ss CreateIdenticalCopy() => 
        new Xoroshiro256ss(_s0, _s1, _s2, _s3);

    private Xoroshiro256ss(ulong s0, ulong s1, ulong s2, ulong s3)
    {
        _s0 = s0;
        _s1 = s1;
        _s2 = s2;
        _s3 = s3;
    }

    public bool Equals(Xoroshiro256ss other) => _s0 == other._s0 && _s1 == other._s1 && _s2 == other._s2 && _s3 == other._s3;
    public override bool Equals(object obj) => obj is Xoroshiro256ss otherSeed && Equals(otherSeed);
    public override int GetHashCode() => _s0.GetHashCode();
    public override string ToString() => $"(s0:{_s0.ToString()}, s1:{_s1.ToString()}, s2:{_s2.ToString()}, s3:{_s3.ToString()})";

}
