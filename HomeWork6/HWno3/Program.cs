using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Козлов Руслан
    3)Переделать программу Пример использования коллекций для решения следующих задач:
    а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
    в) отсортировать список по возрасту студента;
    г) *отсортировать список по курсу и возрасту студента;*/

namespace HWno3
{
    class Ages18_20
    {
        int course;
        int age;
        public Ages18_20(int course, int age)
        {
            this.course = course;
            this.age = age;
        }
    }
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }
    class Program
    {
        static int MyDelegat(Student st1, Student st2)
        {
            return String.Compare(st1.age.ToString(), st2.age.ToString());
        }
        static int MyDelegat2(Student st1, Student st2)
        {
            return String.Compare(st1.course.ToString(), st2.course.ToString());
        }
        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();
            int[] list2 = new int[6];
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[5]) < 5) bakalavr++; else magistr++;
                    if (int.Parse(s[6]) >= 18 && int.Parse(s[6]) <= 20) list2[int.Parse(s[5])]++;                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));
            list.Sort(new Comparison<Student>(MyDelegat2));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            Console.WriteLine("Бакалавров и магистров:{0}", (bakalavr + magistr));
            Console.WriteLine("Студенты возрастом 18-20:");
            for (int i = 1; i < list2.Length; i++)
            {
                Console.WriteLine($"на {i} курсе: {list2[i]} студентов");
            }
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }


}
