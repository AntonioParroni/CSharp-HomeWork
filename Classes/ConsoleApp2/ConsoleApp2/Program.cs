/*1. Придумать класс, описывающий студента и предусмотреть в
нем следующие поля: имя, фамилия, отчество, группа,
возраст, массив (рваный) оценок по программированию,
администрированию и дизайну. Также добавить методы по
работе с перечисленными данными: возможность установки/
получения оценки, получение среднего балла по данному
предмету, распечатка данных о студенте.
2. Написать статический класс, который предоставляет
статические методы для:
- расчета экспоненциальной функции;
- нахождения арксинуса заданного аргумента;
- нахождения расстояния между двумя точками в
трехмерном пространстве;
- транспонирования матрицы. */


using System;
using System.Threading.Channels;

namespace Classes
{
    class ConsoleApp2
    {
        static void Main(string[] args)
        {
            
            /*Student a = new Student();
            a.SetStudentInfo();
            a.SetGrades(a.GradesProgrammingArray);
            a.SetGrades(a.GradesProgrammingArray);
            a.ShowStudentInfo();*/
            
            Point a = new Point(4, 6, 10);
            Point b = new Point(7, 9, 11);
            a.ShowPoint();
            b.ShowPoint();
            Console.WriteLine(StaticClass.Length(a, b));
        }
    }
}