using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LnXPlus1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа № 1");
            Console.WriteLine("Название: Вычисление значения функции ln(x + 1) \n"
                + "\tкак суммы ряда для введенного значения х и заданной точности epsilon \n" 
                + "\tи с использованием функции библиотеки Math.");
            Console.WriteLine("ФИО студента: ");
            Console.WriteLine("Группа студента: ");
            Console.WriteLine("Дата выполнения: 14 апреля 2018 года");
            Console.WriteLine();

            // Объявление требуемыех переменных:

            string line;
            string[] numbers;

            double x, epsilon = double.MaxValue;

            do
            {
                Console.Out.Write("Введите x и epsilon -> ");
                line = Console.ReadLine();  // ввод строки.
                numbers = line.Split(' ');  // разбиение строки на строковые элементы.
            } while (!(numbers.Length == 2
                && double.TryParse(numbers[0], NumberStyles.Number, CultureInfo.InvariantCulture, out x)  // парсинг x.
                && (-1 < x) && (x <= 1)
                && double.TryParse(numbers[1], NumberStyles.Number, CultureInfo.InvariantCulture, out epsilon)));  // парсинг ε.
            Console.Out.WriteLine();

            // Вывод исходных данных на экран:
            Console.Out.WriteLine("Введённые значения:", x);
            Console.Out.WriteLine("x = {0}", x);
            Console.Out.WriteLine("epsilon = {0}", epsilon);
            Console.Out.WriteLine();

            // Объявление требуемыех переменных:

            double sum = 0;  // сумма ряда.
            double prev;  // предыдущее значение суммы ряда.

            double power = 0;
            int n = 0;

            do
            {
                prev = sum;

                // Объявление требуемыех переменных:
                double exp = Math.Pow(x, power + 1);
                double elem = exp / (n + 1);

                if (Double.IsInfinity(elem) || Double.IsNaN(elem))
                {
                    break;
                }

                if (n % 2 == 0)
                {
                    sum += elem;
                }
                else
                {
                    sum -= elem;
                }
                
                ++power;
                ++n;
            } while (Math.Abs(sum - prev) > epsilon);

            // Вывод результатов на экран:

            Console.WriteLine("Значения функции ln(x + 1) как суммы ряда:");
            Console.WriteLine(sum);

            Console.WriteLine("Значения функции ln(x + 1) с использованием функции Log() библиотеки Math:");
            Console.WriteLine(Math.Log(x + 1));

            Console.ReadKey();
        }
    }
}
