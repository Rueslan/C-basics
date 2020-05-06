using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class ComplexClass
    {
        public double im;
        public double re;
        public ComplexClass Plus(ComplexClass x)
        {
            ComplexClass y = new ComplexClass();
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        public ComplexClass Multi(ComplexClass x)
        {
            ComplexClass y = new ComplexClass();
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public ComplexClass Subtract(ComplexClass x)
        {
            ComplexClass y = new ComplexClass();
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }

    struct Complex
    {
        public double im;
        public double re;
        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public Complex Subtract(Complex x)
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа демонстрации работы методов с комплексными числами.");

            byte way = 1;
            bool wayResult = false;
            while (true)
            {
                Console.WriteLine("\nВыберите способ работы программы:\n\t1 - Использовать класс\n\t2 - Использовать структуру");
                Console.Write("\nВвод: ");
                wayResult = Byte.TryParse(Console.ReadLine(), out way);

                if (wayResult && (way == 1 || way == 2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода!");
                    continue;
                }
            }


            Console.WriteLine();
            switch (way)
            {
                case 1:
                    Console.WriteLine("\nВычисление, используя класс.");
                    ComplexClass complex1 = new ComplexClass();
                    complex1.re = 4;
                    complex1.im = 4;

                    ComplexClass complex2 = new ComplexClass();
                    complex2.re = 2;
                    complex2.im = 2;

                    ComplexClass result = complex1.Plus(complex2);
                    Console.WriteLine(result.ToString());
                    result = complex1.Multi(complex2);
                    Console.WriteLine(result.ToString());
                    result = complex1.Subtract(complex2);
                    Console.WriteLine(result.ToString());
                    break;
                case 2:
                    Console.WriteLine("\nВычисление, используя структуру.");
                    Complex complex_1;
                    complex_1.re = 4;
                    complex_1.im = 4;

                    Complex complex_2;
                    complex_2.re = 2;
                    complex_2.im = 2;

                    Complex result2 = complex_1.Plus(complex_2);
                    Console.WriteLine(result2.ToString());
                    result2 = complex_1.Multi(complex_2);
                    Console.WriteLine(result2.ToString());
                    result2 = complex_1.Subtract(complex_2);
                    Console.WriteLine(result2.ToString());
                    break;
            }

            Console.ReadKey();
        }
    }

}
