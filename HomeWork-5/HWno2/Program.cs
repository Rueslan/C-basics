using System;
using System.Collections.Generic;
using static HWno2.Message;

/* Козлов Руслан
Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения,  которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, 
в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.*/

namespace HWno2
{
    class Program
    {
        static void Main(string[] args)
        {
            msg = "Создать программу, котоооорая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 будет символов, содержащая только не буквы латинского алфавита строка или цифры, при этом цифра не может быть первой";
            Console.WriteLine("Статический класс Message для работы с текстом.\n");
            //Console.Write("Введите или вставьте текст:");
            //msg = Console.ReadLine();

            Console.Write("Введите количество символов для поиска слов в тексте длиной не более этого количества: ");
            int vGetWordsWhereSymbolsLessThen = Int32.Parse(Console.ReadLine());
            GetWordsWhereSymbolsLessThen(vGetWordsWhereSymbolsLessThen);

            Console.Write("Введите символ; Слова, оканчивающиеся на этот символ будут удалены из текста: ");
            char vDeleteWordsWhereLastSymbolIs = Convert.ToChar(Console.ReadLine());
            DeleteWordsWhereLastSymbolIs(vDeleteWordsWhereLastSymbolIs);

            Console.Write("Введите количество символов для вывода слов из текста, привышающих это значение: ");
            int vGetStringWithLongWords = Int32.Parse(Console.ReadLine());
            GetStringWithLongWords(vGetStringWithLongWords);

            GetLongestWord();

            Console.WriteLine("Введите построчно слова для поиска количества их вхождений в текст. Для завершения ввода введите пустую строку.\n");
            List<string> words = new List<string>();
            string line = string.Empty;
            while (true)
            {
                line = Console.ReadLine();
                if (line.Length != 0)
                    words.Add(line);                
                else                
                    break;     
            }            
            Console.WriteLine($"\nАнализ вхождений заданных слов в текст:\n\n { string.Join("\n", FrequencyAnalysis(words, msg))}");            

            Console.ReadKey();
        }

    }   

}
