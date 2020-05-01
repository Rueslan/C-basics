using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyWeightIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = 0d, m = 0d;
            Console.WriteLine("------------Программа рассчёта индекса массы тела------------\n");
            Console.Write("\nВведите массу тела в килограммах: ");
            m = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.Write("\nВведите рост в метрах: ");
            h = Convert.ToDouble(Console.ReadLine().Replace('.',','));
            Console.WriteLine("\nИМТ = {0:0.00}", m / (h * h));

            Console.ReadKey();
        }
    }
}
