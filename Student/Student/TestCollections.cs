using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    // Определение класса TestCollections:
    class TestCollections
    {
        // В качестве типа TKey используется класс Person, а в качестве типа TValue - класс Student. 
        // Тип ключа TKey и тип значения TValue связаны отношением базовый-производный.
        // В классе TValue определено свойство, которое возвращает ссылку на объект типа TKey 
        // с данными, совпадающими с данными подобъекта базового класса (это свойство возращает ссылку на объект типа TKey, а не ссылку на вызывающий объект TValue).
        // Каждый объект TValue содержит подобъект базового класса TKey.
        // Соответствие между значениями целочисленного параметра метода и подобъектами TKey класса TValue должно быть взаимно-однозначным – 
        // равным значениям параметра должны отвечать равные объекты TKey и наоборот.

        // Класс содержит закрытые поля с коллекциями типов:

        // System.Collections.Generic.List<TKey>
        private System.Collections.Generic.List<Person> _personList;

        // System.Collections.Generic.List<string>
        private System.Collections.Generic.List<string> _stringList;

        // System.Collections.Generic.Dictionary<TKey, TValue>
        private System.Collections.Generic.Dictionary <Person, Student> _personStudentDict;

        // System.Collections.Generic.Dictionary<string, TValue>
        private System.Collections.Generic.Dictionary <string, Student> _stringStudentDict;

        // Cтатический метод с одним целочисленным параметром типа int, который возвращает ссылку на объект типа Student 
        // и используется для автоматической генерации элементов коллекций:
        public static Student GenerateStudent(int arg) 
        {
            Student student = new Student(arg.ToString(), arg.ToString(), new DateTime(2000, 12, 31), Education.Вachelor, 101);
            return student;

            // Так как статический метод для автоматической генерации элементов 
            // должен обеспечивать взаимно-однозначное соответствие между значением целочисленного параметра метода и объектами TKey, 
            // этот метод можно использовать как при создании коллекций с большим числом элементов, 
            // так и для генерации элемента для поиска.
        }

        // Конструктор c параметром типа int (число элементов в коллекциях) для автоматического создания коллекций с заданным числом элементов:
        public TestCollections(int numberOfElementsInCollections)
        {
            // В конструкторе класса TestCollections создаются коллекции с заданным числом элементов.
            // Все четыре коллекции содержат одинаковое число элементов:
            this._personList = new List<Person>(numberOfElementsInCollections);
            this._stringList = new System.Collections.Generic.List<string>(numberOfElementsInCollections);
            this._personStudentDict = new System.Collections.Generic.Dictionary<Person, Student>(numberOfElementsInCollections);
            this._stringStudentDict = new System.Collections.Generic.Dictionary<string, Student>(numberOfElementsInCollections);

            for (int id = 1; id <= numberOfElementsInCollections; id++)
            {
                Student student = TestCollections.GenerateStudent(id);
                Person person = student.StudentInfo;
            
                // Каждому элементу из коллекции List<TKey> должен отвечать элемент в коллекции Dictionary<TKey, TValue> с равным значением ключа:
                this._personList.Add(person);
                this._personStudentDict.Add(person, student);

                // Список List<string> состоит из строк, которые получены в результате вызова метода ToString() для объектов TKey из списка List<TKey>:
                string personAsString = person.ToString();
                this._stringList.Add(personAsString);

                // Каждому элементу списка List<string> отвечает элемент в коллекции-словаре Dictionary<string, TValue> с равным значением ключа типа string:
                this._stringStudentDict.Add(personAsString, student);
            }

        }

        // Сравнение времени поиска элемента в коллекциях-списках List<TKey> 
        // и времени поиска элемента по ключу и элемента по значению в коллекциях-словарях Dictionary<TKey,TValue>.
        // Метод, который вычисляет время поиска элемента в списках List<Person> и List<string>, 
        // время поиска элемента по ключу и время поиска элемента по значению в коллекциях-словарях Dictionary<Person, Student> и Dictionary<string, Student>:
        public void calcSearchTime()
        {
            Debug.Assert((this._personList.Count == this._stringList.Count)
                && (this._personList.Count == this._personStudentDict.Count)
                && (this._personList.Count == this._stringStudentDict.Count), "Коллекции не содержат одинаковое число элементов!");

            int numberOfElementsInCollections = this._personList.Count;
            const int elCount = 4;

            // Для четырех разных элементов -
            Student studentFirst = TestCollections.GenerateStudent(1);  // первого,
            Person personFirst = studentFirst.StudentInfo;
            string personFirstAsString = personFirst.ToString();

            int centralIdx = (int)Math.Ceiling(numberOfElementsInCollections / 2.0);
            Console.WriteLine("Индекс центрального элемента = {0}", centralIdx);
            Student studentCentral = TestCollections.GenerateStudent(centralIdx);  // центрального,
            Person personCentral = studentCentral.StudentInfo;
            string personCentralAsString = personCentral.ToString();

            Student studentLast = TestCollections.GenerateStudent(numberOfElementsInCollections);  // последнего
            Person personLast = studentLast.StudentInfo;
            string personLastAsString = personLast.ToString();

            Student studentNotIncluded = TestCollections.GenerateStudent(numberOfElementsInCollections + 1);  // и элемента, не входящего в коллекцию
            Person personNotIncluded = studentNotIncluded.StudentInfo;
            string personNotIncludedAsString = personNotIncluded.ToString();
            // - измерение времени поиска:

            object[][] el = new object[3][];
            for (int i = 0; i < el.Length; i++)
                el[i] = new object[elCount];

            el[0][0] = studentFirst;        el[0][1] = studentCentral;        el[0][2] = studentLast;        el[0][3] = studentNotIncluded;
            el[1][0] = personFirst;         el[1][1] = personCentral;         el[1][2] = personLast;         el[1][3] = personNotIncluded;
            el[2][0] = personFirstAsString; el[2][1] = personCentralAsString; el[2][2] = personLastAsString; el[2][3] = personNotIncludedAsString;

            Stopwatch watch;
            long[][] elapsedMs = new long[5][];
            for (int i = 0; i < elapsedMs.Length; i++)
                elapsedMs[i] = new long[elCount];

            bool result;

            // элемента в коллекциях List<TKey> и List<string> с помощью метода Contains:
            for (int i = 0; i < elCount; i++)
            {
                watch = System.Diagnostics.Stopwatch.StartNew();
                result = this._personList.Contains(el[0][i]);
                watch.Stop();
                Debug.Assert(i < elCount - 1 ? result : !result);
                elapsedMs[0][i] = watch.ElapsedMilliseconds;
            }

            for (int i = 0; i < elCount; i++)
            {
                watch = System.Diagnostics.Stopwatch.StartNew();
                result = this._stringList.Contains(el[2][i]);
                watch.Stop();
                Debug.Assert(i < elCount - 1 ? result : !result);
                elapsedMs[1][i] = watch.ElapsedMilliseconds;
            }

            // элемента по ключу в коллекциях Dictionary< TKey, TValue> и Dictionary<string, TValue > с помощью метода ContainsKey:
            for (int i = 0; i < elCount; i++)
            {
                Person key = (Person)el[1][i];
                watch = System.Diagnostics.Stopwatch.StartNew();
                result = this._personStudentDict.ContainsKey(key);
                watch.Stop();
                Debug.Assert(i < elCount - 1 ? result : !result);
                elapsedMs[2][i] = watch.ElapsedMilliseconds;
            }

            for (int i = 0; i < elCount; i++)
            {
                String key = (String)el[2][i];
                watch = System.Diagnostics.Stopwatch.StartNew();
                result = this._stringStudentDict.ContainsKey(key);
                watch.Stop();
                Debug.Assert(i < elCount - 1 ? result : !result);
                elapsedMs[3][i] = watch.ElapsedMilliseconds;
            }
            
            // значения элемента в коллекции Dictionary< TKey, TValue > с помощью метода ContainsValue:
            for (int i = 0; i < elCount; i++)
            {
                Student value = (Student)el[0][i];
                watch = System.Diagnostics.Stopwatch.StartNew();
                result = this._personStudentDict.ContainsValue(value);
                watch.Stop();
                Debug.Assert(i < elCount - 1 ? result : !result);
                elapsedMs[4][i] = watch.ElapsedMilliseconds;
            }

            Console.WriteLine("{0, -22}{1, -14}{2, -10}{3, -10}{4, -10}{5, -10}", 
                "Структура данных", "Метод", "Первый", "Централ.", "Последний", "Не вход.");
            for (int i = 0; i < elapsedMs.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write("{0, -22}{1, -14}", "List<Person>", "Contains");
                        break;
                    case 1:
                        Console.Write("{0, -22}{1, -14}", "List<string>", "Contains");
                        break;
                    case 2:
                        Console.Write("{0, -22}{1, -14}", "Dict.<Person,Student>", "ContainsKey");
                        break;
                    case 3:
                        Console.Write("{0, -22}{1, -14}", "Dict.<string,Student>", "ContainsKey");
                        break;
                    case 4:
                        Console.Write("{0, -22}{1, -14}", "Dict.<Person,Student>", "ContainsValue");
                        break;
                    default:
                        break;
                }
                for (int j = 0; j < elCount; j++)
                {
                    Console.Write("{0, -10}", elapsedMs[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
