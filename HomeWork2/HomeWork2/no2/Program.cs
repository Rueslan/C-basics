using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа подсчёта количества цифр в числе.\n");

            Console.Write("Введите число: ");
            Console.WriteLine($"\nКоличество цифр в числе = {CountOfDigits(Convert.ToInt32(Console.ReadLine()))}");
            Console.ReadKey();
        }

        static int CountOfDigits(int value)
        {
            int count = 0;
            while (value > 0)
            {
                count++;
                value = value / 10;
            }
            return count;
        }
    }
}
