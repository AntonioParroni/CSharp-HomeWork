using System;

namespace Indexator
{
    public class Laptop
    {
        public string Model;
        public double Price;

        public Laptop(string _model, double _price)
        {
            Model = _model;
            Price = _price;
        }
        
        public Laptop()
        {
            Console.WriteLine("Insert Laptop Model Name");
            Model = Console.ReadLine();
            Console.WriteLine("Insert Laptop Price");
            Price = Convert.ToDouble(Console.ReadLine());
        }
        
        public override string ToString()
        {
            string test = "Model: " + Model + " $:" + Price;
            return test;
        }
    }
}