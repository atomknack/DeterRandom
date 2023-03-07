using System;

namespace DeterRandom;

internal static class BitHelpers
{
    internal const ulong U48_MASK = (1UL << 48) - 1;
    internal const double NORM_48 = 1.0d / (1UL << 48);
    internal const double NORM_48_MINUSONE = 1.0d / ((1UL << 48)-1);
    internal const ulong U48_MASK_PLUSONE = U48_MASK + 1;
    internal const ulong UINT_MASK = 0xFF_FF_FF_FFUL;
    internal const ulong BYTE_MASK = 0xFFUL;
    internal const ulong DOUBLE_MASK = (1UL << 53) - 1;
    internal const double NORM_53 = 1.0d / (1UL << 53);
    internal const ulong FLOAT_MASK = (1UL << 24) - 1;
    internal const float NORM_24 = 1.0f / (1UL << 24);

    internal static readonly ulong rotl64_1By32 = Rotl64(1, 32);
    internal static readonly ulong rotl64_1By24 = Rotl64(1, 24);
    internal static readonly ulong rotl64_1By23 = Rotl64(1, 23);
    internal static readonly ulong rotl64_1By22 = Rotl64(1, 22);
    internal static readonly ulong rotl64_1By21 = Rotl64(1, 21);
    internal static readonly ulong rotl64_1By20 = Rotl64(1, 20);

    internal static ulong Rotl64(ulong x, int k) => (x << k) | (x >> (64 - k));
    internal static double LossyConversionToDouble(ulong pseudoRandom) => (pseudoRandom & DOUBLE_MASK) * NORM_53;
    internal static double LossyConversionToDoubleInclusive(ulong pseudoRandom) => (pseudoRandom & U48_MASK) * NORM_48_MINUSONE;
    internal static float LossyConversionToFloat(ulong pseudoRandom) => (pseudoRandom & FLOAT_MASK) * NORM_24;
    internal static uint LossyConversionToUInt32(ulong pseudoRandom) => unchecked((uint) pseudoRandom);
    internal static int LossyConversionToInt32(ulong pseudoRandom) => unchecked((int) pseudoRandom);

}
