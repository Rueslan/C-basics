using System;
using System.Collections.Generic;
using System.IO;

/*Козлов Руслан
    1) Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
    Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
    2) Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
    а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. Использовать массив (или список) делегатов, в котором хранятся различные функции.
    б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр (с использованием модификатора out). */

namespace DoubleBinary
{
    class Program
    {
        delegate double Function(double a, double x);

        private static double F1(double a, double x)
        {
            return a * x * x;
        }

        private static double F2(double a, double x)
        {
            return a * Math.Sin(x);
        }

        public static void SaveFunc(string fileName, double a, double b, double h, int func)
        {
            List<Function> del = new List<Function>();
            del.Add(F1);
            del.Add(F2);
            if (func != 1)
                func = 2;            

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(del[func - 1].Invoke(a, x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static List<double> Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            List<double> values = new List<double>();
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                values.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return values;
        }

        public static int[] Menu()
        {
            int[] variables = new int[3];

            Console.Write("Выберите функцию: 1 - a*x^2; другое число - a*sin(x): ");
            variables[0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("На каком отрезке функции находить минимум?\n" +
                "Введите начальное значение X и конечное.\n" +
                "При этом a = начальному значению отрезка: ");
            variables[1] = Convert.ToInt32(Console.ReadLine());
            variables[2] = Convert.ToInt32(Console.ReadLine());

            return variables;
        }

        static void Main(string[] args)
        {
            List<double> fList = new List<double>();
            int[] variables = Menu();
            double fmin = 0;
            SaveFunc("data.bin", variables[1], variables[2], 0.5, variables[0]);
            fList = Load("data.bin", out fmin);
            foreach (var item in fList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\nМинимальное функции: {fmin}");

            Console.ReadKey();
        }
    }
}
