using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    // Определение класса Test:
    class Test
    {
        // Открытые автореализуемые свойства, доступных для чтения и записи:

        // Свойство типа string, в котором хранится название предмета:
        public string subjectName { get; set; }

        // Cвойство типа bool для информации о том, сдан зачет или нет:
        public bool result { get; set; }

        // Конструктор c параметрами типа string и bool для инициализации свойств класса:
        public Test(string subjectName, bool result)
        {
            this.subjectName = subjectName;
            this.result = result;
        }

        // Конструктор без параметров, инициализирующий все свойства класса некоторыми значениями по умолчанию:
        public Test()
        {
            this.subjectName = "Программирование";
            this.result = true;
        }

        // Перегруженная (override) версия виртуального метода string ToString() для формирования строки со значениями всех свойств класса:
        public override string ToString()
        {
            return String.Format("Название предмета: {0}, Зачёт: {1}", this.subjectName, this.result ? "сдан" : "нет");
        }
    }
}
