using System.Drawing;

namespace Laplacian
{
    static class Laplac5x5
    {
        public static Bitmap
        Laplacian5x5Filter(this Bitmap sourceBitmap,
                      bool grayscale = true)
        {
            Bitmap resultBitmap =
                   ExtBitmap.ConvolutionFilter(sourceBitmap,
                                        Matrix.Laplacian5x5,
                                          1.0, 0, grayscale);


            return resultBitmap;
        }
    }
}
