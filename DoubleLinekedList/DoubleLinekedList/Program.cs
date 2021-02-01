using System;

namespace DoubleLinekedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<string> x = new DoubleLinkedList<string>();
            x.AddToTail("Hello");
            x.AddToTail("World");
            Console.WriteLine(x.ShowDataOnPos(1));
            Console.WriteLine(x.ShowDataOnPos(2));
            x.AddToTail("Test");
            Console.WriteLine(x.ShowDataOnPos(3));
            
            x.AddToHead("Brrr");
            Console.WriteLine(x.ShowDataOnPos(1));
            Console.WriteLine(x.ShowDataOnPos(2));
            Console.WriteLine(x.ShowDataOnPos(4));
            x.ShowFullList();
            
            x.RemoveFromHead();
            x.ShowFullList();
            
            x.RemoveFromHead();
            x.ShowFullList();
            
            x.RemoveFromHead();
            x.ShowFullList();
            
            x.AddToHead("Just Something");
            x.ShowFullList();
            
            x.RemoveFromTail();
            x.ShowFullList();
            
            x.AddToTail("Simple");
            x.ShowFullList();
            
            x.AddToHead("This is");
            x.ShowFullList();
            
            x.AddToTail("Test");
            x.ShowFullList();
            
            x.AddToTail("Test1");
            x.ShowFullList();
            x.AddToTail("Test2");
            x.ShowFullList();
            
            x.AddToPos("First",1);
            x.ShowFullList();
            
            x.AddToPos("Last",7);
            x.ShowFullList();
            
            x.AddToPos("Test && Test1",5);
            x.ShowFullList();
            
            x.AddToPos("Just Something Simple",3);
            x.ShowFullList();
            
            x.RemoveOnPos(10);
            x.ShowFullList();
            
            x.RemoveOnPos(1);
            x.ShowFullList();
            x.RemoveOnPos(2);
            x.ShowFullList();
            x.RemoveOnPos(5);
            x.ShowFullList();
            x.RemoveOnPos(2);
            x.ShowFullList();
            x.RemoveOnPos(5);
            x.ShowFullList();
            x.RemoveOnPos(4);
            x.ShowFullList();
            x.RemoveOnPos(3);
            x.ShowFullList();
            x.RemoveOnPos(1);
            x.ShowFullList();
            
            x.RemoveFromTail();
            
            x.AddRangeToPos(new string[] {"A1", "A2", "A3", "A4", "A5", "A6","A7" },0);
            x.ShowFullList();
            /*x.RemoveFromTail();
            x.ShowFullList();
            x.RemoveFromTail();
            x.ShowFullList();*/
            
            x.AddRangeToPos(new string[] {"B8", "B9", "B10", "B11", "B12", "B13","B14" },8);
            x.ShowFullList();
            
            x.AddRangeToPos(new string[] {"C15", "C16", "C17", "C18", "C19", "C20","C21" },15);
            x.ShowFullList();
            
            x.RemoveRangeFromTo(3,6);
            x.ShowFullList();
            
            x.AddRangeToPos(new string[] {"C123", "1235", "C3457", "Csdfg8", "CSDF9", "3520","CSDDB1" },19);
            x.ShowFullList();
            
            
        }
    }
}
