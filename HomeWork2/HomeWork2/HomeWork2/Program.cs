using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace no1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа поиска максимального числа из 3 чисел.\n");

            int[] nums = new int[] {0,0,0};
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"Введите число {i+1}: ");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.WriteLine($"\nМаксимальное число: { Max(nums[0], nums[1], nums[2])}");
            Console.ReadLine();
        }

        static int Max(int num1, int num2, int num3)
        {
            return num1>=num2 && num1>=num3 ? num1 : num2>=num3 && num2>=num1 ? num2 : num3;
        }
    }
}
