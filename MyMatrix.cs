using System;
using System.Text;


namespace OOP_Lab2
{
    partial class MyMatrix
    {

        private double[,] data;

        // Копіюючий конструктор
        public MyMatrix(MyMatrix other)
        {
            int h = other.getHeight();
            int w = other.getWidth();
            data = new double[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    data[i, j] = other.getElement(i, j);
                }
            }
        }

        // З двовимірного масиву
        public MyMatrix(double[,] array)
        {
            if (array == null)
                throw new ArgumentException("Масив не може бути null.");

            int h = array.GetLength(0);
            int w = array.GetLength(1);
            data = new double[h, w];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    data[i, j] = array[i, j];
                }
            }
        }

        // зубчастий масив
        public MyMatrix(double[][] jaggedArray)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
                throw new ArgumentException("Порожній масив.");

            int width = jaggedArray[0].Length;
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (jaggedArray[i].Length != width)
                    throw new ArgumentException("Масив не прямокутний.");
            }

            int height = jaggedArray.Length;
            data = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    data[i, j] = jaggedArray[i][j];
                }
            }
        }

        // З масиву рядків
        public MyMatrix(string[] lines)
        {
            if (lines == null || lines.Length == 0)
                throw new ArgumentException("Порожній масив рядків.");

            string[] Line = lines[0].Split(new char[] { ' ' });
            int width = Line.Length;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(new char[] { ' ' });
                if (parts.Length != width)
                    throw new ArgumentException("Рядки різної довжини.");
            }

            int height = lines.Length;
            data = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                string[] arr = lines[i].Split(new char[] { ' ' });
                for (int j = 0; j < width; j++)
                {
                    data[i, j] = double.Parse(arr[j]);
                }
            }
        }

        // З рядка з пробілами і переносами рядків
        public MyMatrix(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Порожній рядок.");

            string[] lines = input.Split(new char[] { '\n' });

            string[] Line = lines[0].Split(new char[] { ' ', '\t' });
            int width = Line.Length;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] arr = lines[i].Split(new char[] { ' ', '\t' });
                if (arr.Length != width)
                    throw new ArgumentException("Рядки різної довжини.");
            }

            int height = lines.Length;
            data = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                string[] arr = lines[i].Split(new char[] { ' ', '\t' });
                for (int j = 0; j < width; j++)
                {
                    data[i, j] = double.Parse(arr[j]);
                }
            }
        }

       // java
        public int Height
        {
            get
            {
                return data.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return data.GetLength(1);
            }
        }

        public int getHeight()
        {
            return Height;
        }

        public int getWidth()
        {
            return Width;
        }

        // індексатори
        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Height || j >= Width)
                    throw new IndexOutOfRangeException("Індекс поза межами матриці.");
                return data[i, j];
            }
            set
            {
                if (i < 0 || j < 0 || i >= Height || j >= Width)
                    throw new IndexOutOfRangeException("Індекс поза межами матриці.");
                data[i, j] = value;
            }
        }

        public double getElement(int row, int col)
        {
            return this[row, col];
        }

        public void setElement(int row, int col, double value)
        {
            this[row, col] = value;
        }

        
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    str.Append(data[i, j]);
                    if (j < Width - 1)
                        str.Append(' ');
                }
                if (i < Height - 1)
                    str.AppendLine();
            }
            return str.ToString();
        }


    }
}
