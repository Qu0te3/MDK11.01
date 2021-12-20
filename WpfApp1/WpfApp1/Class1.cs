using System;

namespace Lib_5
{
    public class Calc
    {
        public string GetSum115(int k, out string result)
        {
            Random rnd = new Random();
            int x, sum = 0, count = 0;
            result = string.Empty;
            do
            {
                x = rnd.Next(1, 16);
                count++;
                sum += x;
                result += $"{(x)}  | Сумма: {sum} | Элементов: {count} \n";
            } while (sum < k);
            return result;
        }
    }
}