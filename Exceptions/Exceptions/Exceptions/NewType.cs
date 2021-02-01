using System;

namespace Exceptions
{
    
    public static class NewType
    {
        internal static int A { get; set; }
        internal static int B { get; set; }
        internal static int C { get; set; }
        
        internal static double x { get; set; }
        internal static double y { get; set; }
        
        /*static bool Predicat(char chr)
        {
            if (chr == ' ') 
                return true;
            else 
                return false;
        }*/
        
        internal static void Parse(string input)
        {
            string[] inputDataString = input.Split(",".ToCharArray());

            if (inputDataString.Length == 1)
                inputDataString = input.Split(" ".ToCharArray());

            /*char[] test = inputDataString[0].ToCharArray();
            
            char[] findChars = Array.FindAll(test, Predicat);
            Console.WriteLine("Length " + findChars.Length);
            */

            if (inputDataString.Length > 3)
                throw new FormatException();
            try
            {
                A = int.Parse(inputDataString[0]);
                B = int.Parse(inputDataString[1]);
                C = int.Parse(inputDataString[2]);
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
        }
        //A*x + B*y = С
        internal static void Show()
        {
            Console.WriteLine("Your input: ");
            Console.WriteLine( A + "*x + " + B + "*y = " + C);
        }
        internal static void ShowSolution()
        {
            try
            {
                if (B != 0)
                {
                    y = new Random().Next(1, 10);
                    if (A != 0 && B != 0)
                    {
                        x = -(B * y) / A;
                        Console.WriteLine("The equation is solvable");
                        Console.WriteLine(A + " * " + x + " + " + B + " * " + y + " = " + C);
                    }
                    else
                        throw new ArgumentOutOfRangeException();
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentOutOfRangeException exception1)
            {
                Console.WriteLine(exception1.Message);
            }
        }
    }
}