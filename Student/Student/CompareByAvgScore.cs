using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    // Определение вспомогательного класса, реализующего интерфейс System.Collections.Generic.IComparer<Student>, 
    // который можно использовать для сравнения объектов типа Student по среднему баллу:
    class CompareByAvgScore : System.Collections.Generic.IComparer<Student>
    {
        int System.Collections.Generic.IComparer<Student>.Compare(Student a, Student b)
        {
            return a.AvgScore.CompareTo(b.AvgScore);
        }
    }
}
