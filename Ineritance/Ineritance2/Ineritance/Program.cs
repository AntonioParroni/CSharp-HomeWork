/*Наследование
Создать базовый класс “Транспорт”. От него наследовать “Авто”,
“Самолет”, “Поезд”. От класса “Авто” наследовать классы “Легковое
авто”, “Грузовое авто”. От класса “Самолет” наследовать классы
“Грузовой самолет” и “Пассажирский самолет”. Придумать поля для
базового класса, а также добавить поля в дочерние классы, которые
будут конкретно характеризовать объекты дочерних классов.
Определить конструкторы, методы для заполнения полей классов
(или использовать свойства). Написать метод, который выводит
информацию о данном виде транспорта и его характеристиках.
Использовать виртуальные методы.*/

using System;

namespace Ineritance
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Transport a = new Transport();
            a.ID = 1;
            a.ShowID();
            a.ShowTransportInfo();
            Train b = new Train();
            b.ShowTransportInfo();
            b.ID = 5;
            b.color = "Black";
            b.model = "Shinkansen";
            b.wagonsNumber = 21;
            b.ShowTransportInfo();*/

            /*Auto c = new Auto();
            c.color = "Purple";
            c.ShowTransportInfo();
            LightAuto d = new LightAuto();
            d.ShowTransportInfo();
            HeavyAuto e = new HeavyAuto();
            e.maxLoad = 500;
            e.ShowTransportInfo();*/
            
            Plane f = new Plane();
            f.ShowTransportInfo();
            PassengerPlane g = new PassengerPlane();
            g.ShowTransportInfo();
            TransportPlane h = new TransportPlane();
            h.model = "AH-225";
            h.color = "White";
            h.ID = 8;
            h.maxLoad = 250000;
            h.ShowTransportInfo();


        }
    }
}