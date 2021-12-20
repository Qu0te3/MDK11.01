using System;
using System.Data;
using System.IO;

namespace LibMatrix
{
    public static class VisualMatrix
    {
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add($"{i + 1}", typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }

    public class BasicMatrixActs
    {
        private Random _random = new Random();
        private int[,] _matrix;

        public int[,] Create(int lengthN, int lengthM, int min = 0, int max = 0)
        {
            _matrix = new int[lengthN, lengthM];
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = _random.Next(min, max);
                }
            }
            return _matrix;
        }

        public int[,] Generate(int lengthN, int lengthM, int min = -100, int max = 101)
        {
            _matrix = new int[lengthN, lengthM];
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = _random.Next(min, max);
                }
            }
            return _matrix;
        }

        public int[,] Open(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException();
            }

            StreamReader read = new StreamReader(path);
            _matrix = new int[Convert.ToInt32(read.ReadLine()), Convert.ToInt32(read.ReadLine())];
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = Convert.ToInt32(read.ReadLine());
                }
            }

            return _matrix;

        }

        public void Save(string path)
        {
            {
                StreamWriter write = new StreamWriter(path);
                write.WriteLine(_matrix.GetLength(0));
                write.WriteLine(_matrix.GetLength(1));
                for (int i = 0; i < _matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < _matrix.GetLength(1); j++)
                    {
                        write.WriteLine(_matrix[i, j]);
                    }
                }
                write.Close();
            }
        }

        public void ClearMatrix(int max = 0)
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = _random.Next(max);
                }
            }
        }
    }
}
