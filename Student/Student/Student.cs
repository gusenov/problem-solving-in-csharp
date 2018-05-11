using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    // Определение класса Student:
    class Student : Person, IDateAndCopy, IEnumerable<object>
    {
        // Закрытое поле типа Person, в котором хранятся данные студента:
        //private Person _studentInfo;  // (старая версия)

        // Закрытое поле типа Education для информации о форме обучения:
        private Education _educationType;

        // Закрытое поле типа int для номера группы:
        private int _groupNo;

        // Закрытое поле типа Exam [] для информации об экзаменах, которые сдал студент:
        //private Exam[] _examInfo;  // (старая версия)

        // Закрытое поле типа System.Collections.ArrayList для списка экзаменов (объекты типа Exam):
        //private System.Collections.ArrayList _examInfo = new System.Collections.ArrayList();  // (старая версия)

        System.Collections.Generic.List<Exam> _examInfo = new System.Collections.Generic.List<Exam>();  // для списка экзаменов.

        // Закрытое поле типа System.Collections.ArrayList, в котором хранится список зачетов (объекты типа Test):
        // private System.Collections.ArrayList _testInfo = new System.Collections.ArrayList();  // (старая версия)

        System.Collections.Generic.List<Test> _testInfo = new System.Collections.Generic.List<Test>();  // для списка зачетов.

        // Конструктор c параметрами типа Person, Education, int для инициализации соответствующих полей класса:
        public Student(Person studentInfo, Education educationType, int groupNo):
            base(studentInfo.FirstName, studentInfo.LastName, studentInfo.DateOfBirth)
        {
            //this._studentInfo = studentInfo;  // (старая версия)

            this._educationType = educationType;
            this._groupNo = groupNo;
        }

        // Конструктор без параметров, инициализирующий поля класса значениями по умолчанию:
        public Student()
        {
            //this._studentInfo = new Person();  // (старая версия)

            this._firstName = "Вася";
            this._lastName = "Пупкин";
            this._dateOfBirth = new DateTime(2000, 12, 31);  // год - месяц - день

            this._educationType = Education.Вachelor;
            this._groupNo = 1;

            // (старая версия)
            //this._examInfo = new Exam[1];
            //this._examInfo[0] = new Exam();
        }

        // Новая версия конструктора для класса Student определенного как класс, производный от класса Person:
        public Student(string firstName, string lastName, DateTime dateOfBirth, Education educationType, int groupNo):
            base(firstName, lastName, dateOfBirth)
        {
            this._educationType = educationType;
            this._groupNo = groupNo;
        }

        // Определение свойств c методами get и set:

        // Свойство типа Person для доступа к полю с данными студента:
        public Person StudentInfo
        {
            // Метод get свойства возвращает объект типа Person, данные которого совпадают с данными подобъекта базового класса:
            get
            {
                //return this._studentInfo;  // (старая версия)
                return new Person(base.FirstName, base.LastName, base.DateOfBirth);
            }

            // Метод set присваивает значения полям из подобъекта базового класса:
            set
            {
                //this._studentInfo = value;  // (старая версия)

                base._firstName = value.FirstName;
                base._lastName = value.LastName;
                base._dateOfBirth = value.DateOfBirth;
            }
        }

        // Свойство типа Education для доступа к полю с формой обучения:
        public Education EducationType
        {
            get
            {
                return this._educationType;
            }
            set
            {
                this._educationType = value;
            }
        }

        // Свойство типа int для доступа к полю с номером группы:
        public int GroupNo
        {
            get
            {
                return this._groupNo;
            }
            set
            {
                if (value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Присваиваемое значение меньше или равно 100 или больше 599.");
                }

                this._groupNo = value;
            }
        }

        // Свойство типа Exam [] для доступа к полю со списком экзаменов:
        // (старая версия)
        //public Exam [] ExamInfo
        //public System.Collections.ArrayList ExamInfo
        public System.Collections.Generic.List<Exam> ExamInfo
        {
            get
            {
                return this._examInfo;
            }
            set
            {
                this._examInfo = value;
            }
        }

        public System.Collections.Generic.List<Test> TestInfo
        {
            get
            {
                return this._testInfo;
            }
            set
            {
                this._testInfo = value;
            }
        }

        // Свойство типа double (только с методом get), в котором вычисляется средний балл как среднее значение оценок в списке сданных экзаменов:
        public double AvgScore
        {
            get
            {
                double result = 0;

                //if (this.ExamInfo.Length > 0)   // (старая версия)
                if (this.ExamInfo.Count > 0)
                {
                    //foreach (var exam in this.ExamInfo)  // (старая версия)
                    foreach (Exam exam in this.ExamInfo)
                    {
                        result += exam.mark;
                    }
                    //result /= this.ExamInfo.Length;  // (старая версия)
                    result /= this.ExamInfo.Count;
                }

                return Math.Round(result, 2);
            }
        }

        // Индексатор булевского типа (только с методом get) с одним параметром типа Education; 
        // значение индексатора равно true, если значение поля с формой обучения студента совпадает со значением индекса, и false в противном случае:
        public bool this[Education educationType]
        {
            get
            {
                return this.EducationType == educationType;
            }
        }

        // Метод void AddExams ( params Exam [] ) для добавления элементов в список экзаменов:
        
        // (старая версия)
        //public void AddExams(params Exam [] elements)
        //{
        //    int examCnt = this._examInfo.Length;
        //    Array.Resize<Exam>(ref this._examInfo, examCnt + elements.Length);
        //    Array.Copy(elements, 0, this._examInfo, examCnt, elements.Length);
        //}
        
        //public void AddExams(System.Collections.ArrayList elements)
        
        public void AddExams(System.Collections.Generic.List<Exam> elements)
        {
            foreach (var exam in elements)
            {
                this.ExamInfo.Add(exam);
            }
        }

        public void AddTests(System.Collections.Generic.List<Test> elements)
        {
            foreach (var test in elements)
            {
                this.TestInfo.Add(test);
            }
        }

        // Перегруженная версия виртуального метода string ToString() для формирования строки со значениями всех полей класса, включая список экзаменов:
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Данные студента:\n");
            //result.Append(String.Format("\t{0}\n", this.StudentInfo));  // (старая версия)
            result.Append(String.Format("\tИмя: {0}, Фамилия: {1}, Дата рождения: {2}\n", this._firstName, this._lastName, this._dateOfBirth.ToString("d")));

            result.Append(String.Format("Форма обучения: {0}\n", this.EducationType));
            result.Append(String.Format("Номер группы: {0}\n", this.GroupNo));

            result.Append("Информация о зачётах, которые сдал студент:\n");
            foreach (var test in this.TestInfo)
            {
                result.Append(String.Format("\t{0}\n", test));
            }

            result.Append("Информация об экзаменах, которые сдал студент:\n");
            foreach (var exam in this.ExamInfo)
            {
                result.Append(String.Format("\t{0}\n", exam));
            }

            return result.ToString();
        }

        // Виртуальный метод string ToShortString(), который формирует строку со значениями всех полей класса без списка экзаменов, но со значением среднего балла:
        public override string ToShortString()
        {
            StringBuilder result = new StringBuilder();

            // (старая версия)
            //result.Append("Данные студента:\n");
            //result.Append(String.Format("\t{0}\n", this.StudentInfo));
            result.Append(String.Format("Данные студента: {0} {1}\n", this.FirstName, this.LastName));

            result.Append(String.Format("Форма обучения: {0}\n", this.EducationType));
            result.Append(String.Format("Номер группы: {0}\n", this.GroupNo));
            result.Append(String.Format("Средний балл: {0}\n", this.AvgScore));

            result.Append(String.Format("Число зачетов: {0}\n", this.TestInfo.Count));
            result.Append(String.Format("Число экзаменов: {0}\n", this.ExamInfo.Count));

            return result.ToString();
        }

        // Реализацию интерфейса IDateAndCopy:

        object IDateAndCopy.DeepCopy()
        {
            //Student copy = new Student(this.StudentInfo, this.EducationType, this.GroupNo);  // (старая версия)
            Student copy = new Student(this.FirstName, this.LastName, this.DateOfBirth, this.EducationType, this.GroupNo);
            
            // (старая версия)
            //copy.ExamInfo = new Exam[this.ExamInfo.Length];
            //for (int i = 0; i < this.ExamInfo.Length; i++)
            //{
            //    IDateAndCopy exam = this.ExamInfo[i];
            //    copy.ExamInfo[i] = (Exam)exam.DeepCopy();
            //}

            for (int i = 0; i < this.ExamInfo.Count; i++)
            {
                IDateAndCopy exam = (Exam)this.ExamInfo[i];
                copy.ExamInfo[i] = (Exam)exam.DeepCopy();
            }

            return copy;
        }

        DateTime IDateAndCopy.Date
        {
            get
            {
                //return this.StudentInfo.DateOfBirth;  // (старая версия)    
                return this.DateOfBirth;
            }
            set
            {
                //this.StudentInfo.DateOfBirth = value;  // (старая версия)
                this.DateOfBirth = value;
            }
        }

        // Итератор для последовательного перебора всех элементов (объектов типа object) из списков зачетов и экзаменов (объединение):
        public IEnumerator<object> GetEnumerator()
        {
            foreach (var item in this._testInfo)
            {
                yield return item;
            }

            foreach (var item in this._examInfo)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Итератор c параметром для перебора экзаменов (объектов типа Exam) с оценкой больше заданного значения:
        public IEnumerable<Exam> ByMarkThreshold(int markThreshold)
        {
            foreach (Exam exam in this.ExamInfo)
            {
                if (exam.mark > markThreshold)
                    yield return exam;
            }
        }

    }
}
