using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWno5
{
    class Program
    {
        static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
        static void PrintToCenter(string msg)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - msg.Length / 2, Console.WindowHeight / 2);
            Console.WriteLine(msg);
        }
        static void Main(string[] args)
        {

            PrintToCenter("Руслан К. г.Сарапул\r"); 


            Console.ReadKey();
        }
    }
}
