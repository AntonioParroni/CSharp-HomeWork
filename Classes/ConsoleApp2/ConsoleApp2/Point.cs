/*
2. Написать статический класс, который предоставляет
статические методы для:
- расчета экспоненциальной функции;
- нахождения арксинуса заданного аргумента;
- нахождения расстояния между двумя точками в
трехмерном пространстве;
- транспонирования матрицы.
*/

using System;

namespace Classes
{
    public class Point
    {
        double x, y, z; 
        
        public double X
        {
            get {return x;}
        }
        public double Y
        {
            get {return y;}
        }
        public double Z
        {
            get {return z;}
        }
 
        public Point(double x, double y, double z) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void ShowPoint()
        {
            Console.WriteLine("X:" + X + " Y:" + Y + " Z:" + Z);
        }
    }
    
}