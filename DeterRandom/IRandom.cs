using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom;

public partial interface IRandom
{
    void Salt(ulong salt);
    int Next();
    int Next(int maxValue);
    int Next(int minValue, int maxValue);
    float NextSingle();
    double NextDouble();
    double NextDoubleInclusive();
    void NextBytes(byte[] bytes);
    void NextBytes(Span<byte> bytes);
    void GetItems<TItem>(ReadOnlySpan<TItem> choices, Span<TItem> destination);
    void Shuffle<TItem>(Span<TItem> values);
    public uint NextUInt32();
    public ulong NextUInt64();

}
