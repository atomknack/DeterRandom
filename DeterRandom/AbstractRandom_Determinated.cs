/*
using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom;
public partial class AbstractRandom<T>
{
    public AbstractRandom_Determinated Determinated(ulong salt) => new AbstractRandom_Determinated(_initialSeed, salt);
    public readonly struct AbstractRandom_Determinated
    {
        private readonly T _seed;

        public ulong UInt64() =>
            _seed.CurrentPseudoRandom();
        public void Bytes(Span<byte> bytes)
        {
            var seed = _seed.NextSeed();
            PrivateStatic.NextBytes(ref seed, bytes);
        }
        public void GetItems<TItem>(ReadOnlySpan<TItem> choices, Span<TItem> destination)
        {
            var seed = _seed.NextSeed();
            PrivateStatic.GetItems(ref seed, choices, destination);
        }

        public AbstractRandom_Determinated(T seed, ulong salt)
        {
            _seed = seed.NextSaltedSeed(salt);
        }
    }
}

*/