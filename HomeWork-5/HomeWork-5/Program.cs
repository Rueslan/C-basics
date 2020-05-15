using System;
using System.Text.RegularExpressions;

/* Козлов Руслан
Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, 
содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) **с использованием регулярных выражений.
*/

namespace HomeWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа проверки коррекности ввода логина.\n");
            Console.Write("\nВведите логин от 2 до 10 символов. \nЛогин может содержать латинские символы и цифры. \nПервым символом логина не может быть цифра. \n");
            //-----------------------------------------------------------------------------------
            string pattern = @"\b[a-zA-Z][a-zA-Z0-9_-]{0,9}$";
            Regex regex = new Regex(pattern);
            string login = string.Empty;
            string choose = string.Empty;
            char[] logsym;
            bool flag = false;            

            Console.Write("\nВведите \"да\" для выполнения проверки через Regex, иначе будет выполнена обычная проверка: ");
            choose = Console.ReadLine();

            while (!flag)
            {
                Console.Write("\nВведите логин: ");
                login = Console.ReadLine().Trim();

                switch (choose)
                {
                 case "да":
                    if (regex.IsMatch(login))
                    {
                        flag = true;
                    }
                    else
                    {
                        Console.WriteLine("Длина логина должна быть от 2 до 10 символов. Логин не может содержать цифру в качестве первого символа.\n");
                    }
                    break;
                 default:
                    if (login.Length != 0)
                        logsym = login.ToCharArray();
                    else
                    {
                        Console.WriteLine("Пустая строка не может быть логином.");
                        continue;
                    }
                    if (!(char.IsDigit(logsym[0]) || login.Length < 2 || login.Length > 10))
                    {
                        for (int i = 0; i < logsym.Length; i++)
                        {
                            if (((logsym[i] >= 'a') && (logsym[i] <= 'z')) || ((logsym[i] >= 'A') && (logsym[i] <= 'Z')) || ((logsym[i] >= '0') && (logsym[i] <= '9')) && (logsym[i] != ' '))
                            {
                                flag = true;
                            }
                            else
                            {
                                Console.WriteLine("Логин может состоять только из латинских символов и цифр.\n");
                                flag = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Длина логина может быть от 2 до 10 символов. Логин не должен содержать цифру в качестве первого символа.\n");
                        continue;
                    }
                    break;
                }
            }

            Console.WriteLine($"\nЛогин успешно создан: {login}");
            
            //-----------------------------------------------------------------------------------
            Console.ReadKey();
        }
    }
}
