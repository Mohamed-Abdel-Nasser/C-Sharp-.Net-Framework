using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPuzzleHandler
{
    internal class SudokuPuzzleHandlerprogram
    {
        static void Main(string[] args)
        {
            int[,] inputs = new int[,] {
                {8, 3, 5, 4, 1, 6, 9, 2, 7},
                {2, 9, 6, 8, 5, 7, 4, 3, 1},
                {4, 1, 7, 2, 9, 3, 6, 5, 8},
                {5, 6, 9, 1, 3, 4, 7, 8, 2},
                {1, 2, 3, 6, 7, 8, 5, 4, 9},
                {7, 4, 8, 5, 2, 9, 1, 6, 3},
                {6, 5, 2, 7, 8, 1, 3, 9, 4},
                {9, 8, 1, 3, 4, 5, 2, 7, 6},
                {3, 7, 4, 9, 6, 2, 8, 1, 5}
            };

            var suduko = new suduko(inputs);
            Console.WriteLine(suduko[5, 5]); // 9 Console.ReadKey();
        }
    }

    public class suduko
    {
        private int[,] _matrix;
        private int myVar;
        public int this[int row, int col]
        {
            get
            {
                if (row < 0 || row > _matrix.GetLength(0) - 1) // GetLength(0) → return rows
                {
                    return -1;
                }

                if (col < 0 || col > _matrix.GetLength(1) - 1)// GetLength(1) → return col
                {
                    return -1;
                }
                return _matrix[row, col];
            }
            set
            {
                if (value < 1 || value > _matrix.GetLength(0))
                {
                    return;
                }
                _matrix[row, col] = value;
            }
        }
        public suduko(int[,] matrix)
        {
            this._matrix = matrix;
        }
    }


}
