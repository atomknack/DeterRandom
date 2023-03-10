//----------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Seed_Common
//     Changes will be lost if the code is regenerated.
// </auto-generated>
//----------------------------------------------------------------------------------------

using System;

namespace DeterRandom.Seeds;

public readonly partial struct Xoroshiro128pp
{
    private readonly ulong _s0;
    private readonly ulong _s1;

    public ulong CurrentPseudoNextSeed(out Xoroshiro128pp nextSeedPlaceholder)
    {
        ulong result = CurrentPseudoRandomNoSeedChange();
        NextSeed(out nextSeedPlaceholder);
        return result;
    }

    public void NextSaltedSeed(out Xoroshiro128pp nextSeedPlaceholder, ulong salt)
    {
        ulong s0 = _s0;
        ulong s1 = _s1;
        NextSeed(ref s0, ref s1);
        Salt(ref s0, ref s1, SaltMaker.ValueToSalty(salt));
        nextSeedPlaceholder = new Xoroshiro128pp(s0, s1);
    }

    public void NextSeed(out Xoroshiro128pp nextSeedPlaceholder)
    {
            ulong s0 = _s0;
            ulong s1 = _s1;
        NextSeed(ref s0, ref s1);
        //Salt(ref s0, ref s1, SaltMaker.ValueToSalty(salt));
        nextSeedPlaceholder = new Xoroshiro128pp(s0, s1);
    }

    public Xoroshiro128pp CreateIdenticalCopy() => 
        new Xoroshiro128pp(_s0, _s1);

    private Xoroshiro128pp(ulong s0, ulong s1)
    {
        _s0 = s0;
        _s1 = s1;
    }

    public bool Equals(Xoroshiro128pp other) => _s0 == other._s0 && _s1 == other._s1;
    public override bool Equals(object obj) => obj is Xoroshiro128pp otherSeed && Equals(otherSeed);
    public override int GetHashCode() => _s0.GetHashCode();
    public override string ToString() => $"(s0:{ _s0 }, s1:{ _s1 })";

}



