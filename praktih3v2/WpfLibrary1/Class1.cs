using Microsoft.Win32;
using System;
using System.Data;
using System.IO;

namespace WpfLibrary1
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

    public class Acts
    {
        private Random _random = new Random();
        private int[,] _matrix;

        public int[,] Generate(int lengthN, int lengthM, int min = -50, int max = 51)
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

        public int[,] Open()
        {
            OpenFileDialog reader = new OpenFileDialog();
            reader.DefaultExt = ".txt";
            if (reader.ShowDialog() == true)
            {
                StreamReader read = new StreamReader(reader.FileName);
                _matrix = new int[Convert.ToInt32(read.ReadLine()), Convert.ToInt32(read.ReadLine())];
                for (int i = 0; i < _matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < _matrix.GetLength(1); j++)
                    {
                        _matrix[i, j] = Convert.ToInt32(read.ReadLine());
                    }
                }
            }
            return _matrix;
        }

        public void Save()
        {
            SaveFileDialog writer = new SaveFileDialog();
            writer.DefaultExt = ".txt";
            if (writer.ShowDialog() == true)
            {
                StreamWriter write = new StreamWriter(writer.FileName);
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
