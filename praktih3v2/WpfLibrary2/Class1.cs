using System;

namespace WpfLibrary2
{
    public class CalculateModules
    {
        public int[] AverageUneven(int[,] matrix)
        {
            int sum = 0, count = matrix.GetLength(1);
            int[] averages = new int[matrix.GetLength(0)];

            for (int i = 1; i < matrix.GetLength(0); i += 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
                averages[i] = sum / count;
            }
            return averages;
        }
    }
}
