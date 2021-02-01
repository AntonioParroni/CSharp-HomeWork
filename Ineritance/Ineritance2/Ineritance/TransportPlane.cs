using System;
namespace Ineritance
{
    public class TransportPlane:Plane
    {
        public override string type { get; set; } = "Transport Plane";
        public string model { get; set;}
        public uint maxLoad { get; set;}

        public override void ShowTransportInfo()
        {
            Console.WriteLine("This is a " + type + '\n' +
                              "ID: " + ID + '\n' + 
                              "Color: " + color + '\n' +
                              "Model: " + model + '\n' + 
                              "Max Load: " + maxLoad + "kg");
        }
    }
}