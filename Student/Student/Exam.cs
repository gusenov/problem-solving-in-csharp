using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Exam : IDateAndCopy
    {
        // Открытые автореализуемые свойства, доступных для чтения и записи:

        // Свойство типа string, в котором хранится название предмета:
        public string subjectName { get; set; }

        // Свойство типа int, в котором хранится оценка:
        public int mark { get; set; }

        // Свойство типа System.DateTime для даты экзамена:
        public System.DateTime examDate { get; set; }

        // Конструктор с параметрами типа string, int и DateTime для инициализации всех свойств класса:
        public Exam(string subjectName, int mark, DateTime examDate)
        {
            this.subjectName = subjectName;
            this.mark = mark;
            this.examDate = examDate;
        }

        // Конструктор без параметров, инициализирующий все свойства класса некоторыми значениями по умолчанию:
        public Exam()
        {
            this.subjectName = "Программирование";
            this.mark = 5;
            this.examDate = new DateTime(2018, 04, 30);  // год - месяц - день
        }

        // Перегруженная (override) версия виртуального метода string ToString() для формирования строки со значениями всех свойств класса:
        public override string ToString()
        {
            return String.Format("Название предмета: {0}, Оценка: {1}, Дата экзамена: {2}", this.subjectName, this.mark, this.examDate.ToString("d"));
        }

        // Реализацию интерфейса IDateAndCopy:

        object IDateAndCopy.DeepCopy()
        {
            return new Exam(this.subjectName, this.mark, this.examDate);
        }

        DateTime IDateAndCopy.Date
        {
            get
            {
                return this.examDate;
            }
            set
            {
                this.examDate = value;
            }
        }
    }
}
