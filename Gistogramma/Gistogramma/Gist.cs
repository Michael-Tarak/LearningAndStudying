using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace Gistogramma
{
    static class Gist
    {
        public struct Color32
        {

            public byte b;
            public byte g;
            public byte r;
            public byte a;
            public Color32(byte a, byte r, byte g, byte b)
            {
                this.a = a;
                this.r = r;
                this.g = g;
                this.b = b;
            }
            public static unsafe implicit operator Color(Color32 c32) => Color.FromArgb(*(int*)&c32.b);
            public static unsafe implicit operator Color32(Color c) => new Color32(c.A, c.R, c.G, c.B);
        }

        public class Pixel
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Color32 Color { get; set; }
            public byte A => Color.a;
            public byte R => Color.r;
            public byte G => Color.g;
            public byte B => Color.b;

            public Pixel(int x, int y, Color32 color)
            {
                X = x;
                Y = y;
                Color = color;
            }

        }
        public static IEnumerable<Pixel> GetPixels(this Bitmap bmp)
        {
            var bd = bmp.LockBits(bmp.GetRect(), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            IntPtr p0 = bd.Scan0, pLast = p0 + bd.Stride * bd.Height;
            int x = 0, y = 0;
            while (p0 != pLast)
            {
                yield return new Pixel(x, y, (Color32)Marshal.PtrToStructure(p0, typeof(Color32)));
                x++;
                p0 += 4;
                if (x == bd.Width)
                {
                    x = 0;
                    y++;
                }
            }
            bmp.UnlockBits(bd);
        }
        public static Rectangle GetRect(this Bitmap bmp) => new Rectangle(0, 0, bmp.Width, bmp.Height);

        public static List<Pixel>[] GetHistogramm(this Bitmap bmp, Func<Color, int> func)
        {
            return
                bmp.GetPixels()
                .GroupBy(pixel => func(pixel.Color)) // группировка по функции
                .OrderBy(g => g.Key) // упорядочить по возрастания
                .Select(g => g.ToList()).ToArray();
        }

        public static Bitmap ToBitmap(this IEnumerable<IEnumerable<Pixel>> pixels)
        {
            int w = 0, h = 0;
            int count = 0;
            foreach (var column in pixels)
            {
                foreach (var pix in column)
                {
                    count++;
                    if (pix.X > w) w = pix.X;
                    if (pix.Y > h) h = pix.Y;
                }
            }
            var result = new Bitmap(w, h);
            var bd = result.LockBits(result.GetRect(), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                Color32* p0 = (Color32*)bd.Scan0;
                foreach (var column in pixels)
                {
                    foreach (var pix in column)
                    {
                        *(p0 + h * pix.Y + pix.X) = pix.Color;
                    }
                }
            }
            result.UnlockBits(bd);
            return result;
        }

        public static void Synchronize<T>(this List<T>[] data, Func<T, int, T> func)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = func(data[i][j], i);
                }
            }
        }

        public static Bitmap Equalize(this Bitmap bmp, Func<Color, int> func1, Func<Color, int, Color> func2)
        {
            var equalHistiogramm = bmp.GetHistogramm(func1);
            equalHistiogramm.Synchronize((pixel, index) => new Pixel(pixel.X, pixel.Y, func2(pixel.Color, index)));
            return equalHistiogramm.ToBitmap();
        }
    }
}
