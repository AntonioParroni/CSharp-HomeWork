/*1. Придумать класс, описывающий студента и предусмотреть в
нем следующие поля: имя, фамилия, отчество, группа,
возраст, массив (рваный) оценок по программированию,
администрированию и дизайну. Также добавить методы по
работе с перечисленными данными: возможность установки/
получения оценки, получение среднего балла по данному
предмету, распечатка данных о студенте.*/

using System;

namespace Classes
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public string MiddleName;

        public int GroupId;
        public int Age;

        public int[] GradesProgrammingArray = new int [10];
        public int GradesProgrammingArrayIndex = 0;
        public int[] GradesAdministrationArray = new int[10] ;
        public int GradesAdministraitonArrayIndex = 0;
        public int[] GradesDesignArray = new int[10];
        public int GradesDesignArrayIndex = 0;

       

        public void SetGrades(int[] gradesArray)
        {
            Console.WriteLine($"Insert Grade: ");
            int grade = Convert.ToInt32(Console.ReadLine());
            if (gradesArray == GradesProgrammingArray)
            {
                gradesArray[GradesProgrammingArrayIndex] = grade;
                GradesProgrammingArrayIndex++;
            }
            else if (gradesArray == GradesDesignArray)
            {
                gradesArray[GradesDesignArrayIndex] = grade;
                GradesDesignArrayIndex++;
            }
                
                else if (gradesArray == GradesAdministrationArray)
            {
                gradesArray[GradesAdministraitonArrayIndex] = grade;
                GradesAdministraitonArrayIndex++; 
            }
            /*Array.Resize(ref gradesArray,gradesArray.Length+1);*/
            
        }
        
        public int [] GetGrades(int[] gradesArray)
        {
            return gradesArray;
        }

        public int GetAvgGrade(int[] gradesArray)
        {
            if (gradesArray == GradesProgrammingArray)
            {
                int sum = 0;
                for (int i = 0; i < GradesProgrammingArrayIndex; i++)
                {
                    sum += gradesArray[i];
                }
                return sum / GradesProgrammingArrayIndex;   
            }
                else if (gradesArray == GradesAdministrationArray)
            {
                int sum = 0;
                for (int i = 0; i < GradesAdministraitonArrayIndex; i++)
                {
                    sum += gradesArray[i];
                }
                return sum / GradesAdministraitonArrayIndex;   
            }
                    else if (gradesArray == GradesDesignArray)
            {
                int sum = 0;
                for (int i = 0; i < GradesDesignArrayIndex; i++)
                {
                    sum += gradesArray[i];
                }
                return sum / GradesDesignArrayIndex;   
            }

            return 0;
        }

        public void SetStudentInfo()
        {
            Console.WriteLine($"Student First Name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine($"Student Middle Name: ");
            MiddleName = Console.ReadLine();
            Console.WriteLine($"Student Last Name: ");
            LastName = Console.ReadLine();
            Console.WriteLine($"Student Age: ");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Student Group ID: "); 
            GroupId = Convert.ToInt32(Console.ReadLine());
        }

        public void ShowStudentInfo()
        {
            Console.WriteLine($"Student name is: {FirstName} {LastName} {MiddleName}");
            Console.WriteLine($"Student group is: {GroupId} ");
            Console.WriteLine($"Student age is: {Age}");

            if (GradesProgrammingArrayIndex >= 2)
            {
                Console.WriteLine("Student average grade in programming is: " + GetAvgGrade(GradesProgrammingArray));
            }
            if (GradesAdministraitonArrayIndex >= 2)
            {
                Console.WriteLine("Student average grade in administration is: " + GetAvgGrade(GradesAdministrationArray));
            }
            if (GradesDesignArrayIndex >= 2)
            {
                Console.WriteLine("Student average grade in design is: " + GetAvgGrade(GradesDesignArray));
            }
        }
        
    }
}