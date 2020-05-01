using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    class MyMethods
    {
        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }
        public static void Pause()
        {
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyMethods.Print("Сообщение вызвано методом Print класса MyMethods");
            MyMethods.Pause();
        }
    }
}
