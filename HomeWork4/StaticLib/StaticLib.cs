using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StaticLib //дз 3б
{//Козлов Руслан
    public static class StaticClass //дз 2
    {
        public static int[] Massiv;//основной операнд класса
        public static int Sum { get { return Massiv.Sum(); } }//дз 3а
        public static string MaxCount //дз 3а
        {
            get
            {
                int maxCount = 0;
                int max = Massiv[0];
                for (int i = 0; i < Massiv.Length; i++)
                {
                    if (max < Massiv[i])
                        max = Massiv[i];
                }
                for (int i = 0; i < Massiv.Length; i++)
                {
                    if (max == Massiv[i])
                        maxCount++;
                }
                return $"{maxCount} ({max})";
            }
        }
        static StaticClass()//дз 3а 
        {
            int step = 0;
            Console.Write("Создание нового массива.\nВыберите режим инициализации\n1 - С заданным размером и шагом\n2 - С заданным размером и автозаполнением от 0 до 100\n3 - Считать из файла\n" +
                "Любой другой символ для решения задачи 1 из д\\з\nВвод: ");
            string flag = Console.ReadLine();
            switch (flag)
            {
                case "1":
                    Console.Write("Задайте размер массива: ");
                    Massiv = new int[Int32.Parse(Console.ReadLine())];
                    Console.Write("Задайте шаг для элементов массива: ");
                    step = Int32.Parse(Console.ReadLine());
                    for (int i = 0; i < Massiv.Length; i++)
                    {
                        Massiv[i] = step * i;
                    }
                    break;
                case "2":
                    Console.Write("Задайте размер массива: ");
                    Massiv = new int[Int32.Parse(Console.ReadLine())];
                    AutoFillArray(Massiv);
                    break;
                case "3":
                    Massiv = ReadArrayFromFile(out int massLength, $@"{ Environment.CurrentDirectory}\1.txt");
                    break;
                default:
                    Massiv = new int[20];
                    FillArray(Massiv);                    
                    break;
            }
            Console.WriteLine("Инициализирован массив:\n");
            Print(Massiv);
            if (flag == "1" || flag == "2" || flag == "3")
            {
                Console.Write("\nВыберите действие:\n1 - Multy\n2 - Inverse\n3 - Dictionary\n4 - Sum\n5 - MaxCount\nВвод: ");
                flag = Console.ReadLine();
                switch (flag)
                {
                    case "1":
                        Console.WriteLine("\nУмножение элементов массива. ");
                        while (true)
                        {
                            Console.Write("\nВведите множитель: ");
                            try
                            {
                                Print(Multy(Massiv, Int32.Parse(Console.ReadLine())));
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка ввода {ex}");
                                continue;
                            }
                            break;
                        }


                        break;
                    case "2":
                        Console.WriteLine("\nИнвертированные значения массива:");
                        Print(Inverse(Massiv));
                        break;
                    case "3":
                        Console.WriteLine("\nВхождения элементов в массив:");
                        Dictionary(Massiv);
                        break;
                    case "4":
                        Console.WriteLine($"\nСумма элементов массива: {Sum}");
                        break;
                    case "5":
                        Console.WriteLine($"\nКоличество максимальных элементов: {MaxCount}");
                        break;
                    default:
                        Console.WriteLine($"\nДействие не выбрано. Вывод массива:\n");
                        break;
                }
            } else Print(Solution(Massiv));

        }

        public static void Call() { } //Вызов конструктора класса

        public static int[] Multy(int[] arr, int factor)//дз 3а
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= factor;
            }
            return arr;
        }

        public static int[] Inverse(int[] arr)//дз 3а
        {
            int[] arr2 = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr2[i] = arr[i] * -1;
            }
            return arr2;
        }

        public static int[] ReadArrayFromFile(out int count, string path)//дз 2б+2в
        {
            int LinesCount = 0;
            try
            {
                string line;
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        LinesCount++;
                    }
                }
                int i = 0;
                int[] tmp = new int[LinesCount];
                using (StreamReader sr2 = new StreamReader(path))
                {

                    while (!sr2.EndOfStream)
                    {
                        tmp[i] = Int32.Parse(line = sr2.ReadLine());
                        i++;
                    }
                }
                count = LinesCount;
                return tmp;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\nЧтение массива из файла невозможно.");
            }
            count = 0;
            return null;

        }

        public static int[] Solution(int[] arr)//дз 2а
        {
            FillArray(arr);
            Divisibility3(arr);
            return arr;
        }

        public static void FillArray(int[] arr)//дз 1
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10000, 10000);
            }
        }

        public static void AutoFillArray(int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, 100);
            }
        }

        public static int Divisibility3(int[] arr)//дз 1
        {
            Console.WriteLine("\nПары чисел массива:\n");
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0 || arr[i + 1] % 3 == 0)
                    count++;
                Console.WriteLine($"Пара чисел: {arr[i]} и {arr[i + 1]}");
            }
            Console.WriteLine("Количество пар, довлетворяющих условию: " + count);
            return count;
        }

        public static void Print(int[] arr)//Вывод на консоль
        {
            string stringarray = string.Empty;
            try
            {
                foreach (int i in arr)
                    stringarray += $"{i} ";
            }
            catch (Exception ex)
            {
                stringarray = $"Ошибка вывода:\n{ex.Message}";
            }
            Console.WriteLine($"\n{stringarray}");
        }

        public static void Dictionary(int[] arr)//дз 3е
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in arr)
            {
                if (dict.ContainsKey(i)) dict[i]++;
                else dict.Add(i, 1);
            }
            Console.WriteLine();
            foreach (KeyValuePair<int, int> i in dict)
            {
                Console.WriteLine(i.Key + " встречается " + i.Value + " раз");
            }
        }
    }
}
