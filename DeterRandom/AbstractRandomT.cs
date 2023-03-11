using DeterRandom.Seeds;
using System;

namespace DeterRandom;

public abstract partial class AbstractRandom<T>: IRandom where T : IPseudoRandomSeed<T>
{
    protected readonly T _initialSeed;
    protected T _seed;

    public abstract AbstractRandom<T> CreateFromCurrentState();

    public int Next() =>
        NextInt32(0, int.MaxValue);
    public int Next(int maxValue) =>
        NextInt32(0, maxValue);
    public int Next(int minValue, int maxValue) =>
        NextInt32(minValue, maxValue);
    public int NextInt32() =>
        PrivateStatic.NextInt32(ref _seed);
    public int NextInt32(int minValue, int maxValue) =>
        PrivateStatic.NextInt32(ref _seed, minValue, maxValue);
    public void NextBytes(byte[] bytes) =>
        NextBytes(bytes.AsSpan());
    public void NextBytes(Span<byte> bytes) =>
        PrivateStatic.NextBytes(ref _seed, bytes);

    public uint NextUInt32() =>
        (uint)(PrivateStatic.NextPseudo(ref _seed) >> 32);
    public ulong NextUInt64() =>
        PrivateStatic.NextPseudo(ref _seed);
    public float NextSingle() =>
        BitHelpers.LossyConversionToFloat(PrivateStatic.NextPseudo(ref _seed));
    public double NextDouble() =>
        BitHelpers.LossyConversionToDouble(PrivateStatic.NextPseudo(ref _seed));
    public double NextDoubleInclusive() =>
        BitHelpers.LossyConversionToDoubleInclusive(PrivateStatic.NextPseudo(ref _seed));
    //BitHelpers.NextDouble(ref _seed);

    [Obsolete]
    public void GetItems<TItem>(ReadOnlySpan<TItem> choices, Span<TItem> destination) =>
        PrivateStatic.GetItems(ref _seed, choices, destination);
    [Obsolete]
    public void Shuffle<S>(Span<S> values) =>
        PrivateStatic.Shuffle(ref _seed, values);

    public void Reset() => ResetToInitialState();
    public void ResetToInitialState() =>
        _seed = _initialSeed.CreateIdenticalCopy();

    public void Salt(ulong salt)
    {
        _seed.NextSaltedSeed(out _seed, salt);
    }



    public AbstractRandom(T seed): this(seed, seed.CreateIdenticalCopy()) { }
    public AbstractRandom(T initial, T current)
    {
        _initialSeed = initial;
        _seed = current;
    }
}
