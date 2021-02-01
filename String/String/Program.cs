/*1. Создать метод, принимающий введенную пользователем
строку, и выводящий на экран статистику по этой строке.
Статистика должна включать общее кол-во символов, кол-во
пробелом, кол-во цифр, кол-во символов пунктуации, кол-во
букв и кол-во пробелов.
2. Пользователь вводит строку и символ. В строке найти все
вхождения этого символа и перевести его в верхний регистр, а
также удалить часть строки, начиная с последнего вхождения
этого символа и до конца.
3. Удалить из строки повторяющиеся слова.
4. Преобразовать все слова по правилу: удалить из слова все
последующие вхождения первого символа.
5. Преобразовать все слова по правилу: удалить в слове только
последние вхождения каждого символа.*/

using System;
using System.Linq;
using System.Reflection.Metadata;

namespace String
{
    class Program
    {

        static bool isNum(string arr , int pos)
        {
            if (arr[pos] == '0')
                {
                    return true;
                }
                if (arr[pos] == '1')
                {
                    return true;
                }
                if (arr[pos] == '2')
                {
                    return true;
                }
                if (arr[pos] == '3')
                {
                    return true;
                }
                if (arr[pos] == '4')
                {
                    return true;
                }
                if (arr[pos] == '5')
                {
                    return true;
                }
                if (arr[pos] == '6')
                {
                    return true;
                }
                if (arr[pos] == '7')
                {
                    return true;
                }
                if (arr[pos] == '8')
                {
                    return true;
                }
                if (arr[pos] == '9')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert your string below.");
            string test = Console.ReadLine();
            Console.WriteLine('\n' + "Your string: " + test);
          
            int symbols = 0, spaces = 0, numbers = 0, letters = 0, words = 0;

            symbols = test.Count();

            char[] arr = test.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ' ')
                {
                    spaces++;
                }
            }

            for (int i = 0; i < test.Length; i++)
            {
                if (isNum(test, i))
                {
                    numbers++;
                }
            }
            
            string [] textMass = test.Split(' ');
            
            Console.WriteLine("There are: " + symbols + " symbols in this string");
            Console.WriteLine("There are: " + spaces + " spaces in this string");
            Console.WriteLine("There are: " + numbers + " numbers in this string");
            Console.WriteLine("There are: " + test.Count(char.IsPunctuation) + " punctuation symbols in this string");
            Console.WriteLine("There are: " + test.Count(char.IsLetter) + " total letters in this string");
            Console.WriteLine("There are: " + textMass.Length + " words in this string");
            Console.WriteLine(' ');
            
            
            
            Console.WriteLine("Please insert your next string below.");
            string test2 = Console.ReadLine();
            Console.WriteLine("Your string: " + test2);
            Console.WriteLine("Please insert your char symbol.");
            char chOld = Console. ReadLine()[0];
            char chNew = Char.ToUpper(chOld);

            string test3 = test2.Replace(chOld, chNew);
            Console.WriteLine("Your new string: " + test3);
            int newStringSize = test3.LastIndexOf(chNew);
            Console.WriteLine("Last Position is: " + newStringSize);
            string test4 = test3.Substring(0,newStringSize + 1);
            
            Console.WriteLine("New string is: " + test4);
            
            
            Console.WriteLine("Please insert your next string below.");
            string test5 = Console.ReadLine();
            Console.WriteLine("Your string: " + test5);
            string test6 = string.Join(" ", test5.Split(' ').Distinct());
            Console.WriteLine("Your result: " + test6);

            char firstChar = test6[0];
            
            
            string[] mas = test6.Split(' ', '.', ',');
            string [] newmas = new string [mas.Length];
            char chrem;
            for (int i = 0; i < mas.Length; i++)
            {
                chrem = test6[0];
                newmas[i] = mas[i].Replace(chrem.ToString(), "");
                Console.WriteLine(newmas[i]);
            }
            
            
            // не знаю как решить последнее!
            
        }
    }
}