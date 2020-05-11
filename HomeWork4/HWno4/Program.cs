using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWno4
{//Козлов Руслан
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа авторизации.\n");

            Account user1;
            if (user1.Authorization())
                Console.WriteLine("Вы внутри.");
            else
                Console.WriteLine("Неправильный логин или пароль. Вы израсходовали все попытки.");
             
            Console.ReadLine();
        }

        
    }
    struct Account
    {

        public bool Authorization()
        {
            List<string> mass = new List<string>();
            byte count = 3;
            string login = string.Empty;
            string password = string.Empty;

            mass = GetData();          
            do
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if (mass[0] == login && mass[1] == password)
                    break;
                else
                {
                    count--;
                    if (count != 0)
                        Console.WriteLine($"\nНеправильный логин или пароль.Осталось {count} попыток \n");
                }
            } while (count > 0);
            return count > 0 ? true : false;
        }

        private List<string> GetData()
        {   
            List<string> mass = new List<string>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "dblogin.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    mass.Add(line);                                        
                }
                
            }
            return mass;
        }
        
    }
}
