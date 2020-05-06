using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа рассчёта индекса массы тела.\n");

            double height = 0d, weight = 0d, bmi = 0d;

            Console.Write("\nВведите массу тела в килограммах: ");
            weight = Convert.ToDouble(Console.ReadLine().Replace('.', ','));

            Console.Write("\nВведите рост в метрах: ");
            height = Convert.ToDouble(Console.ReadLine().Replace('.', ','));

            Console.Write("\nИМТ = {0:0.00}\t", bmi = weight / (height * height));

            if (bmi<16)
            {
                Console.Write("Выраженный дефицит массы тела");
                Console.Write($"\nРекомендуется набрать {18.5-bmi}-{25-bmi}кг до нормы");

            }
            else if (bmi >= 16 && bmi < 18.5)
            {
                Console.Write("Недостаточная (дефицит) масса тела");
                Console.Write($"\nРекомендуется набрать {18.5 - bmi}-{25 - bmi}кг до нормы");
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                Console.Write("Норма");
            }
            else if (bmi >= 25 && bmi < 30)
            {
                Console.Write("Избыточная масса тела (предожирение)");
                Console.Write($"\nРекомендуется сбросить {bmi-18.5}-{bmi-25}кг до нормы");
            }
            else if (bmi >= 30 && bmi < 35)
            {
                Console.Write("Ожирение");
                Console.Write($"\nРекомендуется сбросить {bmi - 18.5}-{bmi - 25}кг до нормы");
            }
            else if (bmi >= 35 && bmi < 40)
            {
                Console.Write("Ожирение резкое");
                Console.Write($"\nРекомендуется сбросить {bmi - 18.5}-{bmi - 25}кг до нормы");
            }
            else if (bmi >= 40)
            {
                Console.Write("Очень резкое ожирение");
                Console.Write($"\nРекомендуется сбросить {bmi - 18.5}-{bmi - 25}кг до нормы");

            }

            Console.ReadLine();
        }
    }
}
