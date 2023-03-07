using System;
using System.Collections.Generic;
using System.Text;

namespace DeterRandom;

public interface IPseudoRandomSeed<T>
{
    public T CreateIdenticalCopy();
    public void NextSeed(out T nextSeedPlaceholder);
    public void NextSaltedSeed(out T nextSeedPlaceholder, ulong salt);
    public ulong CurrentPseudoRandom();
}
