using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWordsWithDigitsFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа № 3");
            Console.WriteLine("Название: Чтение текста из файла и вывод на экран слов с цифрами.");
            Console.WriteLine("ФИО студента: ");
            Console.WriteLine("Группа студента: ");
            Console.WriteLine("Дата выполнения: 17 апреля 2018 года");
            Console.WriteLine();
            
            String[] words;

            using (TextReader reader = File.OpenText("input.txt")) {
                words = reader.ReadToEnd().Split(new char[] { ' ', '\n' });
            }

            Console.Out.WriteLine("Вывод на экран слов с цифрами:");
            foreach (var word in words)
            {
                if (word.Any(char.IsDigit))
                {
                    Console.Out.WriteLine(word);
                }
            }

            Console.ReadKey();
        }
    }
}
