using System;
namespace Ineritance
{
    public class PassengerPlane:Plane
    {
        public override string type { get; set; } = "Passenger Plane";
        public string model { get; set;}
        public uint maxSpeed { get; set;}

        public override void ShowTransportInfo()
        {
            Console.WriteLine("This is a " + type + '\n' +
                              "ID: " + ID + '\n' + 
                              "Color: " + color + '\n' +
                              "Model: " + model + '\n' + 
                              "Max Speed: " + maxSpeed + "km/h");
        }
        
    }
}