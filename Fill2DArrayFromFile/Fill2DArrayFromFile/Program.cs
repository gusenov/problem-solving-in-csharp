using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fill2DArrayFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа № 2");
            Console.WriteLine("Название: Создать двумерный массив и заполнить его из файла.\n"
                + "\tСформировать одномерный массив\n"
                + "\tс суммами элементов в столбцах исходного массива.");
            Console.WriteLine("ФИО студента: ");
            Console.WriteLine("Группа студента: ");
            Console.WriteLine("Дата выполнения: 17 апреля 2018 года");
            Console.WriteLine();

            int[][] array2d;  // двумерный массив.
            int rows, cols;

            // Заполнение двумерного массива из файла:
            using (TextReader reader = File.OpenText("input1.txt"))
            {
                // Первые два числа в файле задают количество строк и столбцов в массиве:
                string[] size = reader.ReadLine().Split(' ');
                int.TryParse(size[0], out rows);
                int.TryParse(size[1], out cols);
                Console.Out.WriteLine("Количество строк и столбцов в массиве: {0} x {1}", rows, cols);

                Console.Out.WriteLine("Двумерный массив:");
                array2d = new int[rows][];  // создание двумерного массива.

                for (int row = 0; row < rows; row++)
                {
                    array2d[row] = new int[cols];
                    string[] elements = reader.ReadLine().Split(' ');
                    for (int col = 0; col < cols; col++)
                    {
                        int.TryParse(elements[col], out array2d[row][col]);
                        Console.Out.Write("{0, -5} ", array2d[row][col]);
                    }
                    Console.Out.WriteLine();
                }
            }
            Console.Out.WriteLine();

            int[] array1d = new int[cols];  // одномерный массив.

            Console.Out.WriteLine("Суммы элементов в столбцах исходного массива:");
            for (int col = 0; col < cols; col++)
            {
                array1d[col] = 0;
                for (int row = 0; row < rows; row++)
                {
                    array1d[col] += array2d[row][col];
                }
                Console.Out.Write("{0, -5} ", array1d[col]);
            }

            Console.ReadKey();
        }
    }
}
