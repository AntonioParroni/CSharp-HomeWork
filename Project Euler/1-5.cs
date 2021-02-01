// Я знаю, что я все забрутфорсил. Извините. 
// Мои познания в алгоритмах и дискретной математике конечно оставляют желать лучшего. Но оно хотя бы все работает, и я рад тому, что мне все это удалось написать самому.  
// Пятое упражнение - выдаст правильный результат, нужно только немноого подождать)) 

using System;
namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*1. Если выписать все натуральные числа меньше 10, кратные 3 или 5, то
                получим 3, 5, 6 и 9. Сумма этих чисел - 23.
                Найдите сумму всех чисел меньше 1000, кратных 3 или 5.*/
            // int sum = 0;
            // for (int i = 999; i >= 0; --i)
            // {
            //     if (i % 3 == 0 || i % 5 ==  0)
            //     {
            //         sum += i;
            //     }
            // }
            // Console.WriteLine(sum);
            /*2. Каждый следующий элемент ряда Фибоначчи получается при сложении
                двух предыдущих. Начиная с 1 и 2, первые 10 элементов будут:
            1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
            Найдите сумму всех четных элементов ряда Фибоначчи, которые не
                превышают четыре миллиона*/
            // var first = 1;
            // var second = 2;
            // var sum = 2;
            // for (var i = 0;; i++)
            // {
            //     var buf = first + second;
            //     first = second;
            //     second = buf;
            //     Console.WriteLine("First " + first);
            //     Console.WriteLine("+");
            //     Console.WriteLine("Second " + second);
            //     Console.WriteLine("----------");
            //
            //     if (second % 2 == 0)
            //     {
            //         sum += second;
            //     }
            //         
            //     if (second >= 4000000)
            //     {
            //         break;
            //     }
            // }
            //
            // Console.WriteLine(sum);
            //
            /*3. Простые делители числа 13195 - это 5, 7, 13 и 29.
                Каков самый большой делитель числа 600851475143, являющийся
                простым числом?*/
            // long probNum = 600851475143L;
            // long answer = probNum;
            // long i;
            //
            // for (i = 2; i <= probNum / i; i++) {
            //     while (probNum % i == 0) {
            //         answer = i;
            //         probNum /= i;
            //     }
            // }
            // if (probNum > 1) {
            //     answer = probNum;
            // }
            // Console.WriteLine(answer);
            /*4. Число-палиндром с обеих сторон (справа налево и слева направо)
            читается одинаково. Самое большое число-палиндром, полученное
                умножением двух двузначных чисел – 9009 = 91 × 99.
                Найдите самый большой палиндром, полученный умножением двух
            трёхзначных чисел*/
            // int mul = 1;
            // string max;
            // var maxbuf = 0;
            // var maxbuf2 = 0;
            //
            // for (int i = 100; i < 1000; i++)
            // {
            //     for (int j = 100; j < 1000; j++)
            //     {
            //         mul = i * j;
            //         int first = mul % 10;
            //         mul /= 10;
            //         int second = mul % 10;
            //         mul /= 10;
            //         int third = mul % 10;
            //         mul /= 10;
            //         int fourth = mul % 10;
            //         mul /= 10;
            //         int fifth = mul % 10;
            //         mul /= 10;
            //         int last = mul % 10;
            //         if (first == last && second == fifth && third == fourth)
            //         {
            //             Console.WriteLine(i + " x " + j + " = " + first + second + third + fourth + fifth + last);
            //             max = $"{first}{second}{third}{fourth}{fifth}{last}";
            //             maxbuf = Convert.ToInt32(max);
            //         }
            //         if (maxbuf > maxbuf2)
            //         {
            //             maxbuf2 = maxbuf;
            //         }
            //     }
            // }
            // Console.WriteLine("Result " + maxbuf2);
            
            /*5. 2520 - самое маленькое число, которое делится без остатка на все
                числа от 1 до 10.
                Какое самое маленькое число делится нацело на все числа от 1 до 20?*/
            // int i = 1;
            // bool found = false;
            // bool[] a = new bool[10];
            //
            // while (!found)
            // {
            //     i++;
            //     //System.Threading.Thread.Sleep(10);
            //     for (int j = 1, f = 0; j < 11; ++j, f++)
            //     {
            //         if (i % j == 0)
            //         {
            //             Console.WriteLine(i + "%" + j + " = 0");
            //             a[f] = true;
            //         }
            //         else
            //         {
            //             a[f] = false;
            //         }
            //     }
            //
            //     int tillTen = 0;
            //     for (int z = 0; z < 10; z++)
            //     {
            //         if (a[z])
            //         {
            //             tillTen++;
            //         }
            //
            //         if (tillTen == 10)
            //         { 
            //             found = true;
            //             break;
            //         }
            //     }
            // }
            // Console.WriteLine("Result " + i);
            
            /*5. 2520 - самое маленькое число, которое делится без остатка на все
                числа от 1 до 10.
                Какое самое маленькое число делится нацело на все числа от 1 до 20?*/
            
            int i = 1;
            bool found = false;
            bool[] a = new bool[20];
            
            while (!found)
            {
                i++;
                for (int j = 1, f = 0; j < 21; ++j, f++)
                {
                    if (i % j == 0)
                    {
                        a[f] = true;
                    }
                    else
                    {
                        a[f] = false;
                        break;
                    }
                }
                int tillTwenty = 0;
                for (int z = 0; z < 20; z++)
                {
                    if (a[z])
                    {
                        tillTwenty++;
                    }
                    else if (!a[z])
                    {
                        break;
                    }
                    if (tillTwenty == 20)
                    {
                        found = true;
                        Console.WriteLine("Result is: " + i);
                        break;
                    }
                }
            }
            
            
        }
    }
}
                
            
                
            
        
