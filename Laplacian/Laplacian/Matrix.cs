namespace Laplacian
{
    static class Matrix
    {
        public static double[,] Laplacian3x3
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, },
         { -1,  8, -1, },
         { -1, -1, -1, }, };
            }
        }
        public static double[,] Laplacian5x5
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, -1, -1, },
         { -1, -1, -1, -1, -1, },
         { -1, -1, 24, -1, -1, },
         { -1, -1, -1, -1, -1, },
         { -1, -1, -1, -1, -1  } };
            }
        }
    }
}
