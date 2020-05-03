using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace no6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа подсчета количества \"хороших\" чисел в диапазоне от 1 до 1 000 000 000.\n");

            Console.WriteLine("Пожалуйста, не закрывайте программу, идёт подсчёт...");
            int range = 1000000000, sum = 0, digits = 0, goodDigit = 0;
            DateTime timer= DateTime.Now;
            for (int i = 1; i <= range; i++)
            {
                sum = 0;
                digits = i;
                while (digits > 0)
                {
                    sum += digits % 10;
                    digits /= 10;
                }
                if (i % sum == 0)
                {
                    goodDigit++;
                }
            }
            Console.WriteLine($"Количество \"хороших\" чисел: {goodDigit}\nВремени потрачено: {DateTime.Now - timer}");
            Console.ReadLine();
        }
    }
}
