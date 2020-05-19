using System;
using System.Linq;

/* Козлов Руслан
*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Например:
    badc являются перестановкой abcd.*/

namespace HWno3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа проверки строки на перестановку.\n");

            Console.Write("\nВведите первую строку: ");
            string str1 = Console.ReadLine();
            Console.Write("\nВведите вторую строку: ");
            string str2 = Console.ReadLine();

            if (IsReversedString(str1, str2))
                Console.WriteLine("Строка является перестановкой другой строки");
            else 
                Console.WriteLine("Строка не является перестановкой другой строки");

            Console.ReadKey();
        }

        public static bool IsReversedString(string str1, string str2)
        {
            str1 = new string(str1.Reverse().ToArray());
            return str1 == str2 ? true : false;            
        }
    }
    
}
