using System;

namespace Ineritance
{
    public class Plane:Transport
    {
        public virtual string type { get; set; } = "Plane";
        public string color { get; set;}

        public override void ShowTransportInfo()
        {
            Console.WriteLine("This is a " + type + " with ID: " + ID + " and " + color + " color");
        }
    }
}