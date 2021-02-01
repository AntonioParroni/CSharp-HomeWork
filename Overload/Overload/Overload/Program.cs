/*Реализовать класс для хранения комплексного числа. Выполнить в
нем перегрузку всех необходимых операторов для успешной
компиляции следующего фрагмента кода:
Complex z = new Complex(1,1);
Complex z1;
z1 = z - (z * z * z - 1) / (3 * z * z);
Console.WriteLine($“z1 = {z1}”); */

// 1) Вычетание (Complex - Complex)
// 2) Вычетание (Number  - Complex)
// 3) Умножение (Complex * Complex)
// 4) Умножение (Number  * Complex)
// 5) Деление   (Complex / Complex)


using System;

namespace Overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z = new Complex(1,1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            z1.ShowComplex();
            Console.WriteLine($"z1 = {z1}");
        }
    }
}