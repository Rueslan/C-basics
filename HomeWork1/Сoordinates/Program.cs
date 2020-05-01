using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Сoordinates
{
    class Program
    {
        static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        static void Main(string[] args)
        {
            double x1 = 0f, x2 = 0f, y1 = 0f, y2 = 0f;

            Console.WriteLine("------------Программа посчёта расстояния между точками------------\n");
            Console.Write("\nВведите x1: ");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nВведите y1: ");
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nВведите x2: ");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nВведите y2: ");
            y2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n{0:F2}", GetDistance(x1,y1,x2,y2));

            Console.ReadKey();
        }
    }
}
