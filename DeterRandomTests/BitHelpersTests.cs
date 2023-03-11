using DeterRandom;
using FluentAssertions;

namespace DeterRandomTests;

public class BitHelpersTests
{
    [Fact]
    public void MultiplyUncheckedUlong()
    {
        unchecked
        {
            ulong mm1 = ulong.MaxValue;
            ulong result = mm1 * 10;
            result.Should().Be(ulong.MaxValue - 9);
        }
    }

    [Fact]
    public void U48_MASK()
    {
        BitHelpers.U48_MASK.Should().Be(0x00_00_FF_FF_FF_FF_FF_FF);
    }

    [Fact]
    public void InclusiveMaskReturnOneInclusive()
    {
        BitHelpers.LossyConversionToDoubleInclusive(BitHelpers.U48_MASK).Should().Be(1d);
        //(BitHelpers.U48_MASK * BitHelpers.NORM_48_MINUSONE).Should().Be(0);
    }

    [Fact]
    public void Rotl64_1by32()
    {
        const ulong ROTL = 4294967296UL;
        BitHelpers.rotl64_1By32.Should().Be(ROTL);
        BitHelpers.Rotl64(1, 32).Should().Be(BitHelpers.rotl64_1By32);
        BitHelpers.rotl64_1By32.Should().Be(1UL << 32);
        BitHelpers.Rotl64(BitHelpers.rotl64_1By32, 32).Should().Be(1);
        unchecked((BitHelpers.rotl64_1By32 + 1) * BitHelpers.rotl64_1By32).Should().Be(ROTL);

        const ulong minusROTL = 18446744069414584321UL; // unchecked(0U - ROTL);
        unchecked((BitHelpers.rotl64_1By32 - 1) * BitHelpers.rotl64_1By32).Should().Be(minusROTL - 1);
        unchecked(ulong.MaxValue + 1).Should().Be(0);
        unchecked(BitHelpers.rotl64_1By32 * BitHelpers.rotl64_1By32).Should().Be(0);
        unchecked(ulong.MaxValue + 11UL).Should().Be(10UL);
    }

    [Fact]
    public void Rotl64_1by24()
    {
        BitHelpers.Rotl64(1, 24).Should().Be(BitHelpers.rotl64_1By24);
        BitHelpers.rotl64_1By24.Should().Be(1UL << 24);
    }

    [Fact]
    public void Rotl64_1by23()
    {
        BitHelpers.Rotl64(1, 23).Should().Be(BitHelpers.rotl64_1By23);
        BitHelpers.rotl64_1By23.Should().Be(1UL << 23);
    }
    [Fact]
    public void Rotl64_1by22()
    {
        BitHelpers.Rotl64(1, 22).Should().Be(BitHelpers.rotl64_1By22);
        BitHelpers.rotl64_1By22.Should().Be(1UL << 22);
    }
    [Fact]
    public void Rotl64_1by21()
    {
        BitHelpers.Rotl64(1, 21).Should().Be(BitHelpers.rotl64_1By21);
        BitHelpers.rotl64_1By21.Should().Be(1UL << 21);
    }
    [Fact]
    public void Rotl64_1by20()
    {
        BitHelpers.Rotl64(1, 20).Should().Be(BitHelpers.rotl64_1By20);
        BitHelpers.rotl64_1By20.Should().Be(1UL << 20);
    }

}
