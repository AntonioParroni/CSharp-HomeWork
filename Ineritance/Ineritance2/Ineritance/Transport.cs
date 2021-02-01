using System;

namespace Ineritance
{
    public class Transport
    {
        public uint ID { get; set; }

        public void ShowID()
        {
            Console.WriteLine(ID);
        }

        public virtual void ShowTransportInfo()
        {
            Console.WriteLine("This is a transport with ID: " + ID);
        }
    }
}