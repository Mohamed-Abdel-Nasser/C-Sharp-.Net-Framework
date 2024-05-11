namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            int[,] data1 = { { 1, 2 }, { 3, 4 } };
            int[,] data2 = { { 5, 6 }, { 7, 8 } };

            Matrix m1 = new Matrix(data1);
            Matrix m2 = new Matrix(data2);

            // Matrix addition using operator overloading
            Matrix sum = m1 + m2;
            Console.WriteLine($"Matrix Sum:\n{sum}");
        }
    }
    public class Matrix
    {
        private int[,] data;

        public Matrix(int[,] data)
        {
            this.data = data;
        }

        // Overload addition operator (+) for matrix addition
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            int rows = m1.data.GetLength(0);
            int cols = m1.data.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = m1.data[i, j] + m2.data[i, j];
                }
            }

            return new Matrix(result);
        }

        // Override ToString method to display matrix contents
        public override string ToString()
        {
            string result = "";
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += $"{data[i, j]}\t";
                }
                result += Environment.NewLine;
            }

            return result;
        }
    }



}
