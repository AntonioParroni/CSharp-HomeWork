/*
Исключения
Разработать собственный тип данных для хранения
целочисленных коэффициентов A, B и С линейного уравнения
A*x + B*y = С.
В классе реализовать:
• Статический метод Parse, который принимает строку со
значениями коэффициентов, разделенных запятой или
пробелом. В случае передачи в метод строки недопустимого
формата генерируется исключение FormatException.
• Статический метод для решения системы 2 линейных уравнений:
A1*x + B1*y = C1
A2*x + B2*y = C2
Метод с помощью выходных параметров должен возвращать
найденное решение или генерирует исключение ArgumentOutOfRangeException, если решение не существует.
*/

// само уравнение я решить не смог, извините

using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert A, B, C with space as a separator");
            try
            {
                NewType.Parse(Console.ReadLine());
                NewType.Show();
                NewType.ShowSolution();
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}