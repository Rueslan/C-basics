using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
    public static class Message
    {
        public static string msg;
        public static void GetWordsWhereSymbolsLessThen(int n)
        {
            string result = string.Empty;
            string[] arr = msg.Split(new char[] { ' ', ',', '.', '!', '?', '-' }).Where(word => (word.Length <= n && word.Length != 0)).ToArray();
            foreach (string word in arr)
            {
                result += $" \"{word}\"";
            }
            Console.WriteLine($"\nСлова, количество символов которых не более {n}:\n{result}\n");
        }

        public static void DeleteWordsWhereLastSymbolIs(char symbol)
        {
            string pattern = @"\w+?(" + symbol + @")(?=[\.\,\s]{1,})";
            Regex rgx = new Regex(pattern);
            StringBuilder result = new StringBuilder(rgx.Replace(msg, string.Empty).Replace("  ", " "));//тут можно было бы юзать маску для удаления лишних пробелов(но мне лень)))
            Console.WriteLine($"\nТекст,из которого удалены слова с окончанием на символ \"{symbol}\":\n\n{result}\n");
        }

        public static void GetLongestWord()
        {
            string[] arr = msg.Split(' ', '.', ',', '!', '?');
            int max = 0;
            string word = String.Empty;
            for (int sym = 0; sym < arr.Length; sym++)
            {
                if (arr[sym].Length > max)
                {
                    max = arr[sym].Length;
                    word = arr[sym];
                }
            }
            Console.WriteLine($"\nСамое длинное слово в тексте: {word}\n");
        }

        public static void GetStringWithLongWords(int wordLength)
        {
            string[] arr = msg.Split(' ', '.', ',', '!', '?');
            StringBuilder result = new StringBuilder();
            foreach (var word in arr)
            {
                if (word.Length > wordLength)
                {
                    result.Append($"{word} ");
                }
            }
            Console.WriteLine($"\nСамые длинные слова в тексте (количество символов больше {wordLength}):\n{result}\n");
        }



        public static Dictionary<string, int> FrequencyAnalysis(List<string> words, string text)
        {
            var dict = new Dictionary<string, int>();
            if (words.Count == 0)
            {
                dict.Add("Введено значений", 0);
                return dict;
            }
            int count = 0;
            string newword = string.Empty;
            string[] arr = text.Split(' ', '.', ',', '!', '?');

            for (int i = 0; i < words.Count; i++)
            {
                for (int word = 0; word < arr.Length; word++)
                {
                    if (arr[word] == words[i])
                    {
                        count++;
                    }
                }
                dict.Add(words[i], count);
                count = 0;
            }
            return dict;
        }

    }
}
