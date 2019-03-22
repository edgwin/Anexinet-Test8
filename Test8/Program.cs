using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Write a function such that if an element in an MxN matrix is 0, its entire row and column are setto 0 and then printed out.");
            Console.WriteLine("Please set the array width: ");
            var width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please set the array heigth: ");
            var heigth = Convert.ToInt32(Console.ReadLine());
            var message = string.Empty;
            if (!validateDimentions(width, heigth, out message))
                Console.WriteLine(message);
            else
            {
                int[,] matrix = setMatrix(width, heigth);
                if (matrix != null)
                {
                    var newMatrix = processMatrix(matrix);
                    writeMatrix(newMatrix);
                }
                else
                    Console.WriteLine("The values in the matrix must to be integer numbers");
            }
            Console.ReadLine();
        }

        private static bool validateDimentions(int x, int y, out string message)
        {
            message = string.Empty;
            if (x <= 1)
                message += $"Width value could not be {x}\n";

            if (y <= 1)
                message += $"Heigth value could not be {y}";

            return message == string.Empty;
        }

        private static int[,] setMatrix(int width, int heigth)
        {
            var matrix = new int[width, heigth];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < heigth; y++)
                {
                    Console.Write($"Set the value for cell {x},{y}: ");
                    var value = 0;
                    var isANum = int.TryParse(Console.ReadLine(), out value);
                    if (isANum)
                        matrix[x, y] = value;
                    else
                        return null;
                }
            return matrix;
        }

        public static int[,] processMatrix(int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int heigth = matrix.GetLength(1);
            bool[] row = new bool[width];
            bool[] col = new bool[heigth];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < heigth; y++)
                    if (matrix[x, y] == 0)
                    {
                        row[x] = true;
                        col[y] = true;
                    }
            int[,] newMatrix = new int[width, heigth];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    if (row[i] || col[j])
                        newMatrix[i, j] = 0;
                    else
                        newMatrix[i, j] = matrix[i, j];
                }
            }
            return newMatrix;
        }

        private static void writeMatrix(int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int heigth = matrix.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    Console.Write(matrix[i, j].ToString() + ", ");
                }
                Console.Write("\n");
            }
        }
    }
}
