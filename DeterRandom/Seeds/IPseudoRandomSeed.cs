using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom.Seeds;

public interface IPseudoRandomSeed<T>
{
    public T CreateIdenticalCopy();
    public void NextSeed(out T nextSeedPlaceholder);
    public void NextSaltedSeed(out T nextSeedPlaceholder, ulong salt);
    public ulong CurrentPseudoNextSeed(out T nextSeedPlaceholder);
    public ulong CurrentPseudoRandomNoSeedChange();
}
