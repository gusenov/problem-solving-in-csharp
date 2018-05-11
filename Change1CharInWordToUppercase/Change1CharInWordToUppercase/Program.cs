using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change1CharInWordToUppercase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа № 4");
            Console.WriteLine("Название: Замена во введенной с клавиатуры строке\n"
                + "\tпервых символов слов на символы в верхнем регистре.");
            Console.WriteLine("ФИО студента: ");
            Console.WriteLine("Группа студента: ");
            Console.WriteLine("Дата выполнения: 17 апреля 2018 года");
            Console.WriteLine();

            Console.Out.WriteLine("Введите с клавиатуры строку -> ");
            String inputLine = Console.ReadLine();
            
            String[] words = inputLine.Split(' ');
            
            StringBuilder outputResult = new StringBuilder();
            foreach (var word in words)
            {
                if (word.Length > 0)
                {
                    outputResult.Append(char.ToUpper(word[0]));
                    if (word.Length > 1)
                    {
                        outputResult.Append(word.Substring(1));
                    }
                }
                outputResult.Append(" ");
            }

            Console.Out.WriteLine("Результирующая строка:\n{0}", outputResult.ToString());

            Console.ReadKey();
        }
    }
}
