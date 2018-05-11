using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Person : IDateAndCopy, System.IComparable, System.Collections.Generic.IComparer<Person>
    {
        // Закрытое поле типа string, в котором хранится имя:
        protected string _firstName;

        // Закрытое поле типа string, в котором хранится фамилия:
        protected string _lastName;

        // Закрытое поле типа System.DateTime для даты рождения:
        protected System.DateTime _dateOfBirth;

        // Конструктор c тремя параметрами типа string, string, DateTime для инициализации всех полей класса:
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._dateOfBirth = dateOfBirth;
        }

        // Конструктор без параметров, инициализирующий все поля класса некоторыми значениями по умолчанию:
        public Person()
        {
            this._firstName = "Вася";
            this._lastName = "Пупкин";
            this._dateOfBirth = new DateTime(2000, 12, 31);  // год - месяц - день
        }

        // Свойства c методами get и set:

        // Свойство типа string для доступа к полю с именем:
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                this._firstName = value;
            }
        }

        // Свойство типа string для доступа к полю с фамилией:
        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                this._lastName = value;
            }
        }

        // Свойство типа DateTime для доступа к полю с датой рождения:
        public DateTime DateOfBirth
        {
            get
            {
                return this._dateOfBirth;
            }
            set
            {
                this._dateOfBirth = value;
            }
        }

        // Свойство типа int c методами get и set для получения информации (get) и изменения (set) года рождения в закрытом поле типа DateTime, в котором хранится дата рождения:
        public int YearOfBirth
        {
            get
            {
                return this._dateOfBirth.Year;
            }
            set
            {
                this._dateOfBirth.AddYears(value - this._dateOfBirth.Year);
            }
        }

        // Перегруженная (override) версия виртуального метода string ToString() для формирования строки со значениями всех полей класса:
        public override string ToString()
        {
            return String.Format("Имя: {0}, Фамилия: {1}, Дата рождения: {2}", this._firstName, this._lastName, this._dateOfBirth.ToString("d"));
        }

        // Виртуальный метод string ToShortString(), который возвращает строку, содержащую только имя и фамилию:
        public virtual string ToShortString()
        {
            return String.Format("{0} {1}", this.FirstName, this.LastName);
        }

        // Переопределение (override) виртуального метода bool Equals (object obj):
        public override bool Equals(object value)
        {
            Person person = value as Person;

            return !Object.ReferenceEquals(null, person)
                && String.Equals(FirstName, person.FirstName)
                && String.Equals(LastName, person.LastName)
                && DateTime.Equals(DateOfBirth, person.DateOfBirth);
        }

        // Определение операций == и !=:

        public static bool operator ==(Person lhs, Person rhs)
        {
            if (Object.ReferenceEquals(lhs, null))  // проверка левой стороны на null.
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;  // null == null = true.
                }
                return false;  // только левая сторона является null.
            }
            
            // Equals учитывает случай, когда правая сторона является null.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Person lhs, Person rhs)
        {
            return !(lhs == rhs);
        }

        // Переопределение виртуального метода int GetHashCode():
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.FirstName.GetHashCode();
                hash = hash * 23 + this.LastName.GetHashCode();
                hash = hash * 23 + this.DateOfBirth.GetHashCode();
                return hash;
            }
        }

        // Реализацию интерфейса IDateAndCopy:

        object IDateAndCopy.DeepCopy()
        {
            return new Person(this.FirstName, this.LastName, this.DateOfBirth);
        }

        DateTime IDateAndCopy.Date
        {
            get
            {
                return this.DateOfBirth;
            }
            set
            {
                this.DateOfBirth = value;
            }
        }

        // Реализация интерфейса System.IComparable для сравнения объектов типа Person по полю с фамилией:
        int IComparable.CompareTo(object other)
        {
            return this.LastName.CompareTo(((Person)other).LastName);
        }

        // Реализация интерфейса System.Collections.Generic.IComparer<Person> для сравнения объектов типа Person по дате рождения:
        int System.Collections.Generic.IComparer<Person>.Compare(Person a, Person b)
        {
            return a.DateOfBirth.CompareTo(b.DateOfBirth);
        }

    }
}
