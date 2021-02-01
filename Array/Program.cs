/*1. Заполнить одномерный массив случайными числами. Сжать
массив, удалив из него все 0 и заполнить освободившиеся
справа элементы значениями -1.
2. Заполнить одномерные массив случайными числами.
Преобразовать массив так, чтобы сначала шли отрицательные
элементы, а потом положительные.
3. В двумерном массиве, размеры которого вводятся с
клавиатуры, поменять местами заданные столбцы.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        static int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;         
        }
        
        static void Main(string[] args)
        {
            Random rand = new Random();
            
            int arraySize = 10;
           int [] array = new int [arraySize];

           for (int i = 0; i < array.Length; i++)
           {
               array[i] = rand.Next(5) ;
           }

           int zeroCount = 0;
           for (int i = 0; i < array.Length; i++)
           {
               if (array[i] == 0)
               {
                   zeroCount++;
               }
               Console.WriteLine(array[i]);
           }

           Console.WriteLine("Zeros: " + zeroCount);

           InsertionSort(array);
           // int [] arrayN = array.Reverse();
           
           for (int i = 0; i < array.Length; i++)
           {
               Console.WriteLine(array[i]);
           }

           Console.WriteLine(" ");


           for (int i = 0; i < array.Length / 2; i++)
           {
               int tmp = array[i];
               array[i] = array[array.Length - i - 1];
               array[array.Length - i - 1] = tmp;
           }

           for (int i = 0; i < array.Length; i++)
           {
               if (array[i] == 0)
               {
                   array[i] = -1;
               }
           }

           // int decrementor = arraySize - 1;
           // for (int i = 0; i < array.Length; i++)
           // {
           //     if (array[i] == 0)
           //     {
           //         if (array[arraySize - 1] == 0)
           //         {
           //             break;
           //         }
           //         else
           //         {
           //             if (array[decrementor] != 0)
           //             {
           //                 array[i] = array[decrementor];
           //                 array[decrementor] = 0;
           //                 decrementor--;
           //             }
           //             else
           //             {
           //                 if (array[decrementor - 1] != 0)
           //                 {
           //                     array[i] = array[decrementor];
           //                     array[decrementor] = 0;    
           //                 }
           //                 else
           //                 {
           //                     
           //                 }
           //             }
           //         }
           //     }
           // }


           Console.WriteLine("Result 1:");
           for (int i = 0; i < array.Length; i++)
           {
               Console.WriteLine(array[i]);
           }

           Console.WriteLine(" ");

           int[] array1 = new int [10];
           
           for (int i = 0; i < array1.Length; i++)
           {
               array1[i] = rand.Next(10) ;
           }
           
           for (int i = 0; i < array1.Length; i++)
           {
               Console.WriteLine(array1[i]);
           }

           InsertionSort(array1);
           
           Console.WriteLine("Result 2:");
           for (int i = 0; i < array1.Length; i++)
           {
               Console.WriteLine(array1[i]);
           }

           int size1, size2;
           Console.WriteLine("Input first number");
           size1 =  Convert.ToInt32(Console.ReadLine());
           Console.WriteLine("Input second number");
           size2 = Convert.ToInt32(Console.ReadLine());
           
           int[,] array3 = new int[size1,size2];
           for (int i = 0; i < array3.GetLength(0); i++)
           {
               for (int j = 0; j < array3.GetLength(1); j++)
               {
                   array3[i, j] = rand.Next(10);
               }
           }

           Console.WriteLine("Sample");
           for (int i = 0; i < array3.GetLength(0); i++)
           {
               Console.WriteLine();
               for (int j = 0; j < array3.GetLength(1); j++)
               {
                   Console.Write(array3[i, j] + " ");
               }
           }

           if (size2 % 2 == 0)
           {
               for (int i = 0; i < array3.GetLength(0); i++)
               {
                   for (int j = 0; j < array3.GetLength(1); j++)
                   {
                       array3[i,j] = array3[i,j] + array3[i,j + 1];
                       array3[i, j + 1] = array3[i, j] - array3[i, j + 1];
                       array3[i,j] = array3[i, j] - array3[i, j + 1];
                       j++;
                   }
               }
           }

           else if (size2 % 2 != 0)
           {
               for (int i = 0; i < array3.GetLength(0); i++)
               {
                   for (int j = 0; j < array3.GetLength(1) - 1; j++)
                   {
                       array3[i,j] = array3[i,j] + array3[i,j + 1];
                       array3[i, j + 1] = array3[i, j] - array3[i, j + 1];
                       array3[i,j] = array3[i, j] - array3[i, j + 1];
                       j++;
                   }
               }    
           }

           Console.WriteLine();
           Console.WriteLine();
           Console.WriteLine("Result");
           for (int i = 0; i < array3.GetLength(0); i++)
           {
               Console.WriteLine();
               for (int j = 0; j < array3.GetLength(1); j++)
               {
                   Console.Write(array3[i, j] + " ");
               }
           }
        }
    }
}
                
            
        