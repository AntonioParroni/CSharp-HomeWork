/*2. Написать статический класс, который предоставляет
статические методы для:
- расчета экспоненциальной функции;
- нахождения арксинуса заданного аргумента;
- нахождения расстояния между двумя точками в
трехмерном пространстве;
- транспонирования матрицы.*/


using System;

namespace Classes
{
    public static class StaticClass
    {
        public static double Exp(double num)
        {
            return Math.Exp(num);
        }
        
        public static double Length(Point A, Point B)
        {
            return Math.Sqrt(((B.X - A.X) * (B.X - A.X)) + ((B.Y - A.Y) * (B.Y - A.Y))+((B.Z - A.Z) * (B.Z - A.Z)));
        }

        public static double ArcSin(double x)
        {
           return Math.Atan(x / Math.Sqrt(-x * x + 1));
        }
        
        public static double[,] SwapMatrix(double[,] arr, int size)
        {
            double[,] transported = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    transported[i,j]=arr[j, i];
            }
            return transported;
        }
    }
}