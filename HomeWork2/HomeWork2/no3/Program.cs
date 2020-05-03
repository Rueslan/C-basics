using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа подсчёта суммы нечётных положительных чисел.\nДля завершения ввода введите \"0\".\n");

            int sum = 0, num = 0;
            do
            {
                Console.Write("Введите число: ");
                num = Convert.ToInt32(Console.ReadLine());
                if (num > 0 && num % 2 != 0)
                    sum += num;
            }
            while (num != 0);
            Console.WriteLine($"\nСумма нечётных положительных чисел: {sum}");
            Console.ReadKey();
        }
    }
}
