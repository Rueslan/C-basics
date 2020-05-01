using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Программа Анкета------------\n");
            string name = "", surname = "";
            int age = 0, height = 0, weight = 0;
            Console.WriteLine("Программа анкета.\n");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            surname = Console.ReadLine();
            Console.Write("Введите рост: ");
            height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вес: ");
            weight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите возраст: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n------------Вывод тремя способами------------");
            Console.WriteLine($"\n{surname} {name}. Рост: {height}. Вес: {weight}. Возраст: {age}.");
            Console.WriteLine(String.Format("{0} {1}. Рост: {2}. Вес: {3}. Возраст: {4}.", surname, name, height, weight, age));
            Console.WriteLine(surname + " " + name + ". Рост: " + height +". Вес: " + weight + ". Возраст: " + age + ".");


            Console.ReadKey();
        }
    }
}
