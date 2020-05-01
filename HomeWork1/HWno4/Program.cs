using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWno4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int a = 0, b = 0, c = 0;
            Console.WriteLine("------------Программа обмена значений переменных------------");
            Console.Write("\nВведите первое значение:  ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе значение:  ");
            b = Convert.ToInt32(Console.ReadLine());
            #region *обмен значениями с использованием двух переменных* 
                Console.WriteLine("------------Обмен значениями с использованием двух переменных------------");
                Console.WriteLine($"\na = {a}");
                Console.WriteLine($"b = {b}");
                a = a + b; 
                b = a - b;
                a = a - b;
                Console.WriteLine("\n------------Обмен значениями------------");
                Console.WriteLine($"\na = {a}");
                Console.WriteLine($"b = {b}");
            #endregion
            #region *обмен значениями с использованием трёх переменных*
                Console.WriteLine("\n\n------------Обмен значениями с использованием трёх переменных------------");
                Console.WriteLine($"\na = {a}");
                Console.WriteLine($"b = {b}");
                c = a;
                a = b;
                b = c;
                Console.WriteLine("\n------------Обмен значениями------------");
                Console.WriteLine($"\na = {a}");
                Console.WriteLine($"b = {b}");
            #endregion
            Console.Read();
        }
    }
}
