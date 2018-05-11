using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        // № 1
        // Метод Main():
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа № 5");
            Console.WriteLine("Название: Универсальные типы. Классы-коллекции.\n"
                + "\tМетоды расширения класса System.Linq.Enumerable.");
            Console.WriteLine("ФИО студента: ");
            Console.WriteLine("Группа студента: ");
            Console.WriteLine("Дата выполнения: 19 апреля 2018 года");
            Console.WriteLine();

            Console.WriteLine("\n\n//---------------------------------------------------------------------");

            Console.Out.WriteLine("№ 2");
            // Создание объекта типа StudentCollection:
            StudentCollection students = new StudentCollection();

            // Добавление в коллекцию несколько различных элементов типа Student:
            students.AddDefaults();

            Console.Out.WriteLine("Вывод объекта StudentCollection:");
            Console.Out.WriteLine(students);

            Console.WriteLine("\n\n//---------------------------------------------------------------------");

            Console.Out.WriteLine("№ 3");
            // Для созданного объекта StudentCollection вызов методов, 
            // выполняющих сортировку списка List<Student> по разным критериям, 
            // и после каждой сортировки вывод данных объекта:

            Console.Out.WriteLine("\n\n\tСортировка по фамилии студента:");
            students.SortByLastName();
            Console.Out.WriteLine(students.ToShortString());

            Console.Out.WriteLine("\n\n\tСортировка по дате рождения:");
            students.SortByDateOfBirth();
            Console.Out.WriteLine(students.ToShortString());

            Console.Out.WriteLine("\n\n\tСортировка по среднему баллу:");
            students.SortByAvgScore();
            Console.Out.WriteLine(students.ToShortString());

            Console.WriteLine("\n\n//---------------------------------------------------------------------");

            Console.Out.WriteLine("№ 4");
            // Вызов методов класса StudentCollection, выполняющих операции со списком List<Student>, 
            // и после каждой операции вывод результата операции:

            // Вычисление максимального значения среднего балла для элементов списка:
            Console.Out.WriteLine("\n\nМакс. значения ср. балла для элементов списка = {0}", students.MaxAvgScore);

            // Фильтрация списка для отбора студентов с формой обучения Education.Specialist:
            Console.Out.WriteLine("\n\nСтуденты с формой обучения Education.Specialist:");
            foreach (Student specialist in students.Specialists)
            {
                Console.Out.WriteLine(specialist.ToShortString());
            }

            // Группировка элементов списка по значению среднего балла:

            double queryAvgScore = 4.33;
            Console.WriteLine("\n\n\tГруппа студентов со ср. баллом {0}:", queryAvgScore);
            foreach (Student student in students.AverageMarkGroup(queryAvgScore))
            {
                Console.WriteLine(student.ToShortString());
            }

            Console.WriteLine("\n\nВывод всех групп элементов:");
            foreach (IGrouping<double, Student> studentGroup in students.AllAvgScoreGroups())
            {
                Console.WriteLine("\tГруппа студентов со ср. баллом {0}:", studentGroup.Key);
                foreach (Student student in studentGroup)
                    Console.WriteLine(student.ToShortString());
            }

            Console.WriteLine("\n\n//---------------------------------------------------------------------");

            Console.Out.WriteLine("№ 5");

            // Число элементов в коллекциях вводится пользователем в процессе работы приложения. 
            // Если при вводе была допущена ошибка, приложение обрабатывает исключение, сообщает об ошибке ввода 
            // и повторяет прием ввода до тех пор, пока не будет правильно введено целочисленное значение.

            int numberOfElementsInCollections;
            do
            {
                Console.Out.Write("Введите число элементов в коллекциях -> ");
                string inputLine = Console.ReadLine();  // ввод строки.
                try
                {
                    if (!int.TryParse(inputLine, NumberStyles.Integer, CultureInfo.InvariantCulture, out numberOfElementsInCollections))
                    {
                        throw new ArgumentException("При вводе была допущена ошибка!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.Out.WriteLine(e.Message);
                    continue;
                }
            } while (true);

            // Создание объекта типа TestCollections:
            TestCollections tests = new TestCollections(numberOfElementsInCollections);
            
            // Вызов метода для поиска в коллекциях первого, центрального, последнего и элемента, не входящего в коллекции.
            // Вывод значений времени поиска для всех четырех случаев.
            // Вывод содержит информацию о том, к какой коллекции и к какому элементу относится данное значение:
            tests.calcSearchTime();

            Console.ReadKey();
        }
    }
}
