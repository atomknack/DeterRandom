using DeterRandom;
using System.Drawing;

namespace DeterRandomTests;

[Trait("Category", "SlowTests")]
public abstract class WriteRandomBitmaps
{
    private string SavePath => AssemblyData.SavePath + "WriteRandomBitmaps\\";
    protected abstract IRandom RandForTestSource { get; }
    protected abstract IRandom Rand(int preseed);

    [Fact]
    public void SaveGrayScaleFromRandomBytes()
    {
        Bitmap b = MakeGrayRandomFromBytes(RandForTestSource.NextBytes, 256, 600);
        b.Save(SavePath + this.GetType().Name + "_bytes" + ".bmp");
    }
    [Fact]
    public void SaveColorfullFromRandomULongs()
    {
        Bitmap b = MakeColorRandomFromRandomULongs(RandForTestSource.NextUInt64, 200, 500);
        b.Save(SavePath + this.GetType().Name + "_ulongs4bytesAsColor" + ".bmp");
    }
    [Fact]
    public void SaveGrayScaleFromRandomULongs()
    {
        Bitmap b = MakeGrayRandomFromRandomULongs(200);
        b.Save(SavePath + this.GetType().Name + "_ulongs" + ".bmp");
    }

    [Fact]
    public void SaveGrayScaleWithSaltFromRandomULongs()
    {
        IRandom rand;

        int height = 200;
        int width = height * 8;

        Span<byte> bytes = stackalloc byte[8];
        Bitmap bm = new Bitmap(width, height);
        for (int y = 0; y < height; y++)
        {
            rand = RandForTestSource;
            for (int x = 0; x < width; x += 8)
            {
                if (x == 160)
                {
                    //continue; uncomment to ensure that we salt middle (test output with continue will be empty at middle)
                    rand.Salt((ulong)(100 * y));
                }

                if (BitConverter.TryWriteBytes(bytes, rand.NextUInt64()) == false)
                    throw new Exception("byte conversion exception");
                for (int xOffset = 0; xOffset < 8; xOffset++)
                    bm.SetPixel(x + xOffset, y, Color.FromArgb(bytes[xOffset], bytes[xOffset], bytes[xOffset]));
            }
        }

        bm.Save(SavePath + this.GetType().Name + "_SameGenSaltedAt160WithDifferentSalt" + ".bmp");
    }
    [Fact]
    public void SaveEveryRowNewRandomGeneratorFromRandomULongs()
    {
        int k = 0;
        IRandom rand = Rand(k);

        int height = 200;
        int width = height * 8;

        Span<byte> bytes = stackalloc byte[8];
        Bitmap bm = new Bitmap(width, height);
        for (int y = 0; y < height; y++)
        {
            if (y % 4 == 0)
            {
                k++;
                rand = Rand(k);
            }


            for (int x = 0; x < width; x += 8)
            {
                if (BitConverter.TryWriteBytes(bytes, rand.NextUInt64()) == false)
                    throw new Exception("byte conversion exception");
                for (int xOffset = 0; xOffset < 8; xOffset++)
                    bm.SetPixel(x + xOffset, y, Color.FromArgb(bytes[xOffset], bytes[xOffset], bytes[xOffset]));
            }
        }

        bm.Save(SavePath + this.GetType().Name + "_ulongs_everyRow4NewRandomGenerator" + ".bmp");
    }

    public Bitmap MakeGrayRandomFromRandomULongs(int height)
    {
        var rand = RandForTestSource;

        int width = height * 8;
        Span<byte> bytes = stackalloc byte[8];
        Bitmap bm = new Bitmap(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x += 8)
            {
                if (BitConverter.TryWriteBytes(bytes, rand.NextUInt64()) == false)
                    throw new Exception("byte conversion exception");
                for (int xOffset = 0; xOffset < 8; xOffset++)
                    bm.SetPixel(x + xOffset, y, Color.FromArgb(bytes[xOffset], bytes[xOffset], bytes[xOffset]));
            }
        }
        return bm;
    }
    public static Bitmap MakeColorRandomFromRandomULongs(Func<ulong> ULongRand, int height, int width)
    {
        Span<byte> bytes = stackalloc byte[8];
        Bitmap bm = new Bitmap(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (BitConverter.TryWriteBytes(bytes, ULongRand()) == false)
                    throw new Exception("byte conversion exception");
                bm.SetPixel(x, y, Color.FromArgb(bytes[0], bytes[1], bytes[2], bytes[3]));
            }
        }
        return bm;
    }

    public delegate void SpanActionNoArgs<T>(Span<T> span);
    public static Bitmap MakeGrayRandomFromBytes(SpanActionNoArgs<byte> RandFiller, int height, int width)
    {
        byte[] bytes = new byte[height * width];
        RandFiller(bytes);
        Bitmap bm = new Bitmap(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                byte c = bytes[width * y + x];
                bm.SetPixel(x, y, Color.FromArgb(c, c, c));
            }
        }
        return bm;
    }

    //[Fact]
    //public void SaltedDiff()
    //{
    //    Bitmap b1 = (Bitmap)Bitmap.FromFile(XUnitSavePath + this.GetType().FullName + "_ulongs" + ".bmp");
    //    Bitmap b2 = (Bitmap)Bitmap.FromFile(XUnitSavePath + this.GetType().FullName + "_ulongsSaltedAtMiddle" + ".bmp");
    //    int height = b1.Height;
    //    int width = b2.Width;
    //    Bitmap diff = new Bitmap(width, height);
    //    for (int y = 0; y < height; y++)
    //    {
    //        for (int x = 0; x < width; x++)
    //        {
    //            Color color1 = b1.GetPixel(x, y);
    //            Color color2 = b2.GetPixel(x, y);
    //            Color resultColor = Color.FromArgb(color1.R & color2.R, color1.G & color2.G, color1.B & color2.B);
    //            diff.SetPixel(x, y, resultColor);
    //        }
    //    }
    //    diff.Save(XUnitSavePath + this.GetType().FullName + "_ulongs_diffWithSalted" + ".bmp");
    //}
}