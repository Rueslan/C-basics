using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа авторизации.\nВведите данные, учитывая регистр. \n");
            if (Authorization())
                Console.WriteLine("\nДоступ разрешен.");
            else
            {
                Console.WriteLine("\nДоступ запрещён. Все попытки израсходованы.");
                //Console.WriteLine(false);  
            }

            Console.ReadLine();

        }

        static bool Authorization()
        {
            string login = "", password = "";
            byte count = 3;
            do
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if ("root" == login && "GeekBrains" == password)
                    break;
                else
                {
                    count--;
                    if (count != 0)
                        Console.WriteLine($"\nДоступ запрещён.Осталось {count} попыток \n");
                }
            } while (count>0);

            return count>0 ? true : false ;
        }
    }
}
