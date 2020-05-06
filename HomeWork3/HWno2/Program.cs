using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWno2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа подсчёта суммы нечётных положительных чисел.\n");

            Input();
            
            Console.ReadKey();
        }

        static void Input()
        {
            bool result;
            string arr="";
            int num, sum = 0;
            while (true)
            {
                Console.Write("Введите число: ");
                result = Int32.TryParse(Console.ReadLine(), out num);
                if (result == false)
                {
                    Console.WriteLine("Ошибка! Не удается преобразовать строку в число!");
                    continue;
                } 
                if (num == 0)
                {
                    break;
                }
                else if (num % 2 != 0 && num > 0)
                {
                    sum += num;
                }
                arr +=num+" ";
            }
            Console.WriteLine($"\nВведённые числа: {arr}");
            Console.WriteLine($"Сумма нечётных положительных чисел: {sum}");
        }
    }
}
