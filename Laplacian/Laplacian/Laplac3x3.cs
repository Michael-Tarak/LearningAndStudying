using System.Drawing;

namespace Laplacian
{

    static class Laplac3x3
    {
        public static Bitmap
        Laplacian3x3Filter(this Bitmap sourceBitmap,
                      bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, Matrix.Laplacian3x3, 1.0, 0, grayscale);
            //ExtBitmap.ConvolutionFilter(sourceBitmap,
            //                     Matrix.Laplacian3x3,
            //                       1.0, 0, grayscale);


            return resultBitmap;
        }
    }
}
