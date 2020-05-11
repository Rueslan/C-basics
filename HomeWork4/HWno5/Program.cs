using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLib;

namespace HWno5
{//Козлов Руслан
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа инициализации матрицы.\n");
            string input = String.Empty;
            Matrix arr;

            while (true)
            {
                Console.Write("\nВыберите способ инициализации:\n1 - Создание заданной матрицы\n2 - Чтение матрицы из файла\nВвод: ");                
                input = Console.ReadLine();
                if (input == "1")
                {
                    try
                    {
                        Console.Write("Введите размер квадратной матрицы:\n");
                        int dim = Int32.Parse(Console.ReadLine());
                        arr = new Matrix(dim, dim);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка ввода: {ex}");
                        continue;
                    }
                    
                    break;
                }
                else if (input == "2")
                {
                    arr = new Matrix(true);
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода.");
                    continue;
                }
            }
            
            
            int val = 30;
            Console.WriteLine($"\nМаксимальное: {arr.Max} (Индекс {arr.MaxValueIndex}) \nМинимальное: {arr.Min}\nСумма: {arr.Sum}\nСумма значений свыше {val}: {arr.GetSumOverValue(val)}");
            
            Console.WriteLine(arr.ToString());
            Console.ReadKey();
        }
    }
}
