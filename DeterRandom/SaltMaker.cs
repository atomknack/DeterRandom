using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

using static DeterRandom.BitHelpers;

namespace DeterRandom
{
    public static partial class SaltMaker
    {
        internal static void SaltTwoSameWay(ref ulong s0, ref ulong s1, ulong salt) //totally NOT scientifical method of salting
        {
            unchecked
            {
                int saltShift = (int)(salt % 59);
                s0 = Rotl64(s0 ^ salt, saltShift);
                s1 = Rotl64(s1 ^ salt, saltShift);
            }
        }
        internal static void SaltFourSameWay(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ulong salt) //totally NOT scientifical method of salting
        {
            unchecked
            {
                int saltShift = (int)(salt % 59);
                s0 = Rotl64(s0 ^ salt, saltShift);
                s1 = Rotl64(s1 ^ salt, saltShift);
                s2 = Rotl64(s2 ^ salt, saltShift);
                s3 = Rotl64(s3 ^ salt, saltShift);
            }
        }
        public static ulong ValueToSalty(long value) =>
            ValueToSalty(unchecked((ulong)value));
        public static ulong ValueToSalty(ulong value)
        {
            unchecked
            {
                int shift = (int)(value % 59);
                return value ^ (rotl64_1By32 + Rotl64(value, shift));
            }
        }

        public static ulong MixSalts(ulong salt1, ulong salt2)
        {
            unchecked
            {
                return salt1 + rotl64_1By23 + Rotl64(salt1, 21) + Rotl64(salt2, 13);
            }
        }
        public static ulong ValueToSalty(float value) =>
            ValueToSalty(BitConverter.SingleToInt32Bits(value));
        public static ulong ValueToSalty(int value) =>
              ValueToSalty(unchecked((uint) value));
        public static ulong ValueToSalty(uint value)
        {
            unchecked
            {
                int shift = (int)(value % 49);
                return ValueToSalty(value + Rotl64(value, shift));
            }
        }
        public static ulong ValueToSalty(double value)=>
            ValueToSalty(BitConverter.DoubleToInt64Bits(value));

    }
}
