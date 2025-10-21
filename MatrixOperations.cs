using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP_Lab2
{
    partial class MyMatrix
    {

       
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
                throw new ArgumentException("Матриці мають різні розміри.");

            int h = a.Height;
            int w = a.Width;
            double[,] result = new double[h, w];

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    result[i, j] = a[i, j] + b[i, j];

            return new MyMatrix(result);
        }

       
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Width != b.Height)
                throw new ArgumentException("Неправильні розміри для множення.");

            int h = a.Height;
            int w = b.Width;
            int inner = a.Width;

            double[,] result = new double[h, w];

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    for (int k = 0; k < inner; k++)
                        result[i, j] += a[i, k] * b[k, j];

            return new MyMatrix(result);
        }

       
        private double[,] GetTransponedArray()
        {
            int h = Height;
            int w = Width;
            double[,] transposed = new double[w, h];

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    transposed[j, i] = data[i, j];

            return transposed;
        }

        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }

        public void TransponeMe()
        {
            data = GetTransponedArray();
        }

    }
}
