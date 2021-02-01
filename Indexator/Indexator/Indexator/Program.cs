/*Свойства. Индексаторы.
Предположим, есть некоторый интернет-магазин, который
занимается реализацией ноутбуков. У нас есть классы Shop и
Laptop. У класса Laptop переопределить метод ToString(), чтобы он
возвращал информацию о ноутбуке. В классе Shop должен
храниться массив объектов Laptop. Нужно сделать возможным
обращение к элементам этого массива через экземпляр класса
Shop, пользуясь синтаксисом массива так, словно класс Shop и есть
массив элементов типа Laptop. Добавьте необходимый индексатор,
а также необходимые конструкторы для работы.*/

using System;

namespace Indexator
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop a = new Laptop();
            Console.WriteLine(a.ToString());
            
            Shop b = new Shop();
            b[0] = new Laptop("Acer",44);
            b[1] = new Laptop("HP",99);
            b[2] = new Laptop();
            b[3] = a;
            
            Console.WriteLine( b[0].ToString());
            Console.WriteLine( b[1].ToString());
            Console.WriteLine( b[2].ToString());
            Console.WriteLine( b[3].ToString());
        }
    }
}