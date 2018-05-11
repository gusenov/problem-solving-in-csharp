using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    // Определение класса StudentCollection:
    class StudentCollection
    {
        // Закрытое поле типа System.Collections.Generic.List<Student>:
        private System.Collections.Generic.List<Student> _studentsList = new System.Collections.Generic.List<Student>();
        
        // Метод void AddDefaults(), c помощью которого можно добавить некоторое число элементов типа Student для инициализации коллекции по умолчанию:
        public void AddDefaults()
        {
            Student s;

            s = new Student("Максим", "Шаров", new DateTime(2000, 12, 31), Education.Вachelor, 111);
            s.AddTests(new List<Test> {
                new Test("Мат. анализ", true),
                new Test("Алгоритмы", true),
                new Test("Лин. алгебра", true)
            });
            s.AddExams(new List<Exam> {
                new Exam("Мат. анализ", 4, new DateTime(2018, 01, 10)),
                new Exam("Алгоритмы", 5, new DateTime(2018, 01, 15)),
                new Exam("Лин. алгебра", 4, new DateTime(2018, 01, 20))
            });
            _studentsList.Add(s);

            s = new Student("Светлана", "Одинцова", new DateTime(2001, 1, 11), Education.Specialist, 222);
            s.AddTests(new List<Test> {
                new Test("Алгоритмы", true),
                new Test("Лин. алгебра", true)
            });
            s.AddExams(new List<Exam> {
                new Exam("Алгоритмы", 5, new DateTime(2018, 01, 15)),
                new Exam("Лин. алгебра", 4, new DateTime(2018, 01, 20))
            });
            _studentsList.Add(s);
            
            s = new Student("Борис", "Новиков", new DateTime(2002, 2, 22), Education.SecondEducation, 333);
            s.AddTests(new List<Test> {
                new Test("Мат. анализ", true),
                new Test("Алгоритмы", true),
                new Test("Лин. алгебра", true),
                new Test("Геометрия", true)
            });
            s.AddExams(new List<Exam> {
                new Exam("Мат. анализ", 5, new DateTime(2018, 01, 10)),
                new Exam("Алгоритмы", 5, new DateTime(2018, 01, 15)),
                new Exam("Лин. алгебра", 5, new DateTime(2018, 01, 20)),
                new Exam("Геометрия", 5, new DateTime(2018, 01, 25))
            });
            _studentsList.Add(s);
            
            s = new Student("Оксана", "Антонова", new DateTime(2003, 3, 23), Education.Вachelor, 444);
            s.AddTests(new List<Test> {
                new Test("Мат. анализ", true),
                new Test("Алгоритмы", true),
                new Test("Лин. алгебра", true)
            });
            s.AddExams(new List<Exam> {
                new Exam("Мат. анализ", 4, new DateTime(2018, 01, 10)),
                new Exam("Алгоритмы", 5, new DateTime(2018, 01, 15)),
                new Exam("Лин. алгебра", 4, new DateTime(2018, 01, 20))
            });
            _studentsList.Add(s);
            
            s = new Student("Роман", "Титов", new DateTime(2004, 4, 14), Education.Specialist, 555);
            s.AddTests(new List<Test> {
                new Test("Мат. анализ", true),
                new Test("Алгоритмы", true),
                new Test("Лин. алгебра", true)
            });
            s.AddExams(new List<Exam> {
                new Exam("Алгоритмы", 4, new DateTime(2018, 01, 15)),
                new Exam("Лин. алгебра", 5, new DateTime(2018, 01, 20))
            });
            _studentsList.Add(s);
        }

        // Метод void AddStudents (params Student[] ) для добавления элементов в список List<Student>:
        void AddStudents (params Student[] students)
        {
            foreach (Student student in students)
            {
                this._studentsList.Add(student);
            }
        }
        
        // Перегруженная версия виртуального метода string ToString() для формирования строки c информацией обо всех элементах списка List<Student>, 
        // включающую значения всех полей, список зачетов и экзаменов для каждого элемента Student:
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Student student in this._studentsList)
            {
                result.Append(String.Format("{0}\n", student.ToString()));
            }

            return result.ToString();
        }
        
        // Метод string ToShortString(), который формирует строку c информацией обо всех элементах списка List<Student>, 
        // содержащую значения всех полей, средний балл, число зачетов и число экзаменов для каждого элемента Student, но без списков зачетов и экзаменов:
        public string ToShortString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Student student in this._studentsList)
            {
                result.Append(String.Format("{0}\n", student.ToShortString()));
            }

            return result.ToString();
        }


        // Определение методов, выполняющих сортировку списка List<Student>:

        // По фамилии студента с использованием интерфейса IComparable, реализованного в классе Person:
        public void SortByLastName()
        {
            this._studentsList.Sort();
        }

        // По дате рождения студента с использованием интерфейса IComparer<Person>, реализованного в классе Person:
        public void SortByDateOfBirth()
        {
            this._studentsList.Sort(new Person());
        }
        
        // По среднему баллу с использованием интерфейса IComparer<Student>, реализованного во вспомогательном классе:
        public void SortByAvgScore()
        {
            this._studentsList.Sort(new CompareByAvgScore());
        }

        // Определение свойств и методов, выполняющих операции со списком List<Student> с использованием методов расширения класса System.Linq.Enumerable, 
        // и статические методы-селекторы, которые необходимы для выполнения соответствующих операций со списком:
        
        // Свойство типа double (только с методом get), возвращающее максимальное значение среднего балла для элементов списка List<Student>; 
        // если в коллекции нет элементов, свойство возвращает некоторое значение по умолчанию; 
        // для поиска максимального значения среднего балла использовать метод Max класса System.Linq.Enumerable:
        public double MaxAvgScore
        {
            get
            {
                if (this._studentsList.Count > 0)
                {
                    return this._studentsList.Max(student => student.AvgScore);
                }
                else
                {
                    return 0;
                }
            }
        }

        // Свойство типа IEnumerable<Student> (только с методом get), возвращающее подмножество элементов списка List<Student> с формой обучения Education.Specialist; 
        // для формирования подмножества использовать метод Where класса System.Linq.Enumerable:
        public IEnumerable<Student> Specialists
        {
            get
            {
                return this._studentsList.Where(student => student.EducationType == Education.Specialist);
            }
        }
        
        // Метод List<Student> AverageMarkGroup(double value), который возвращает список, 
        // в который входят элементы Student из списка List<Student> с заданным значением среднего балла; 
        // для формирования списка использовать методы Group и ToList класса System.Linq.Enumerable:
        public List<Student> AverageMarkGroup(double value)
        {
            IEnumerable<IGrouping<double, Student>> query =
                this._studentsList.GroupBy(student => student.AvgScore, student => student);

            IGrouping<double, Student> group = query.SingleOrDefault(grp => grp.Key == value);

            if (group == null)
            {
                return new List<Student>();
            }
            else
            {
                return group.ToList();
            }
        }

        public IEnumerable<IGrouping<double, Student>> AllAvgScoreGroups()
        {
            IEnumerable<IGrouping<double, Student>> query =
                this._studentsList.GroupBy(student => student.AvgScore, student => student);
            return query;
        }
    }
}
