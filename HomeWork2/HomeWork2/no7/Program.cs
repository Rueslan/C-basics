using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no7
{
    class Program
    {
        static int sum=0;
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вывода чисел от 0 до N и их суммы рекурсивным методом .\n");
            Console.Write("Введите конечное число: ");
            Console.WriteLine($"\n\nСумма чисел: {Output(0, Convert.ToInt32(Console.ReadLine()))}");
            Console.ReadLine();
        }

        static int Output(int a,int b)
        {
            sum += a;
            Console.Write($"{a} ");
            if (a < b)
                Output(a + 1, b);
                return sum;
            
        }
    }
}
