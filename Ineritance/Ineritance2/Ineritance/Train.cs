using System;

namespace Ineritance
{
    public class Train:Transport
    {
        public string type { get; set; } = "Train";
      
        public string color {get;set;}
        public string model {get;set;}
        public uint wagonsNumber {get;set;}

        public override void ShowTransportInfo()
        {
            Console.WriteLine("This is a " + type + " with ID: " + ID + '\n' +  
                              " Model: " + model + '\n' + 
                              " Color: " + color + '\n' + 
                              " Number of wagons: " + wagonsNumber);
            
        }
    }
}