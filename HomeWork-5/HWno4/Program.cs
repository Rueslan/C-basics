using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/* Козлов Руслан
 * Задача ЕГЭ.
На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, 
которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
    <Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, 
соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
    Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, 
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.*/

namespace HWno4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача ЕГЭ.\n");

            Regex mask = new Regex(@"[a-zа-яё]{1,20}\s[a-zа-яё]{1,15}\s[1-5]\s[1-5]\s[1-5]", RegexOptions.IgnoreCase);
            int studentsCount = 0;
            int[] worstStudents = new int[3];

            while (true)
            {
                Console.Write("Введите количество учеников: ");
                try
                {
                    studentsCount = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine($"Ошибка ввода. Введите целочисленное значение.\n");
                    continue;
                }
                
                if (studentsCount>=10 && studentsCount<=100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Количество учеников должно соответствовать диапазону от 10 до 100\n");
                }
            }                   

            Student[] students = new Student[studentsCount];
            string[] inputArr;
            string input;
            Console.WriteLine("Заполните данные об учениках:\n");

            for (int i = 0; i < students.Length; i++)
            {
                int gradesSum = 0;
                Console.Write($"Ученик {i+1}: ");
                input = Console.ReadLine().Trim().Replace("  ", " ");
                if (mask.IsMatch(input))
                {
                    inputArr = input.Split(' ').ToArray();
                    students[i] = new Student();
                    students[i].surname.Append(inputArr[0]);
                    students[i].name.Append(inputArr[1]);
                    for (int gradesCounter = 0; gradesCounter < 3; gradesCounter++)
                    {
                        students[i].grades[gradesCounter] = Int32.Parse(inputArr[2 + gradesCounter]);
                        gradesSum += students[i].grades[gradesCounter];
                    }
                    students[i].average = ((double)gradesSum / 3);
                }
                else
                {
                    Console.WriteLine("Данные введены не верно. Пожалуйста, повторите ввод.\n");
                    i--;
                    continue;
                }           
            }

            Console.WriteLine(GetWorstStudents(ref students));             

            Console.ReadLine();
        }

        static string GetWorstStudents(ref Student[] student)
        {
            #region Sort
            Student temp = new Student();
            for (int i = 0; i < student.Length; i++)
            {
                for (int j = i + 1; j < student.Length; j++)
                {
                    if (student[i].average > student[j].average)
                    {
                        temp = student[i];
                        student[i] = student[j];
                        student[j] = temp;
                    }
                }
            }
            #endregion

            string result = $"\nХудшие ученики:\n\t{student[0].surname} {student[0].name}\n\t{student[1].surname} {student[1].name}\n\t{student[2].surname} {student[2].name}";

            for (int i = 3; i < student.Length; i++)
            {
                if (student[i].average <= student[2].average)
                {
                    result += $"\n\t{student[i].surname} {student[i].name}";
                }
            }

            return result;
        }
                
    }

    public class Student
    {
        public StringBuilder surname = new StringBuilder(20);
        public StringBuilder name = new StringBuilder(15);
        public int[] grades = new int[3];
        public double average;

        public string GetData()
        {
            return $"{surname.ToString()} {name.ToString()} {string.Join(" ", grades)} {String.Format("{0:0.00}", average)}";
        }
    }

}
