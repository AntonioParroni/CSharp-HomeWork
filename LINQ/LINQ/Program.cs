/*                 Тема: Введение в LINQ
Есть коллекция пользовательских объектов типа Person.
public class Person
{
public string Name { get; set; }
public int Age { get; set; }
public string City { get; set; }
}
List<Person> person = new List<Person>()
{
new Person(){ Name = "Andrey", Age = 24, City
 = "Kyiv"
 },
new Person(){ Name = "Liza", Age = 18, City =
 "Moscow"
 },
new Person(){ Name = "Oleg", Age = 15, City =
 "London"
 },
new Person(){ Name = "Sergey", Age = 55, City
 = "Kyiv"
 },
new Person(){ Name = "Sergey", Age = 32, City
 = "Kyiv"
 }
};
1)
 Выбрать людей, старших 25 лет.
2)
 Выбрать людей, проживающих не в Киеве.
3)
 Выбрать имена людей, проживающих в Киеве.
4)
 Выбрать людей старших 35 лет с именем Sergey.
5)
 Выбрать людей, проживающих в Москве.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events;

namespace Events
{

 public class Person
 {
  public string Name { get; set; }
  public int Age { get; set; }
  public string City { get; set; }

  public override string ToString()
  {
   return string.Format("Name: " + Name + " Age: " + Age + " City: " + City);
  }
 }

 
 class Employee
 {
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int Age { get; set; }
  public int DepId { get; set; }
  
  public override string ToString()
  {
   return string.Format("ID: " + Id + " FirstName: " + FirstName + " LastName: " + LastName + " Age: " + Age + " Department: " + DepId);
  }
 }
 }
 class Department
 {
  public int Id { get; set; }
  public string Country { get; set; }
  public string City { get; set; }

  public override string ToString()
  {
   return string.Format("Dp ID : " + Id + " Country: " + Country + " City: " + City);
  }
 }


 class Program
  {
   static void Main(string[] args)
   {
    List<Person> person = new List<Person>()
    {
     new Person(){ Name = "Andrey", Age = 24, City
      = "Kyiv"
     },
     new Person(){ Name = "Liza", Age = 18, City =
      "Moscow"
     },
     new Person(){ Name = "Oleg", Age = 15, City =
      "London"
     },
     new Person(){ Name = "Sergey", Age = 55, City
      = "Kyiv"
     },
     new Person(){ Name = "Sergey", Age = 32, City
      = "Kyiv"
     }
    };
    
    
    // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); 
    // Console.OutputEncoding = Encoding.GetEncoding(1252);
    // Console.OutputEncoding = System.Text.Encoding.UTF8;
    // Console.WriteLine("1) Выбрать людей, старших 25 лет.");
    
    // Не получается у меня в Линуксе и .NETCore.App 3.1.8  сделать корректное отображение кириллицы.  


    Console.WriteLine("1) People with age >= than 25");
    var collection = person
     .Where(person => person.Age >= 25)
     .OrderBy(person => person.Age);
    collection.ToList().ForEach(person => Console.WriteLine(person));
    
    Console.WriteLine("2) People != resident in Kyiv");
    var collection2 = person
     .Where(person => person.City != "Kyiv")
     .OrderBy(person => person.Name);
    collection2.ToList().ForEach(person => Console.WriteLine(person));
    
    Console.WriteLine("3) People == resident in Kyiv");
    var collection3 = person
     .Where(person => person.City == "Kyiv")
     .OrderBy(person => person.Name);
    collection3.ToList().ForEach(person => Console.WriteLine(person));
    
    Console.WriteLine("4) People with age > 35 and with name == Sergey");
    var collection4 = person
     .Where(person => person.Age > 35 && person.Name == "Sergey")
     .OrderBy(person => person.Name);
    collection4.ToList().ForEach(person => Console.WriteLine(person));
    
    Console.WriteLine("5) People == resident in Moscow");
    var collection5 = person
     .Where(person => person.City == "Moscow")
     .OrderBy(person => person.Name);
    collection5.ToList().ForEach(person => Console.WriteLine(person));
    
    
    List<Department> departments = new List<Department>()
    {
     new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
     new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
     new Department(){ Id = 3, Country = "France", City = "Paris" },
     new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
    };

    List<Employee> employees = new List<Employee>()
    {
     new Employee()
      { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
     new Employee()
      { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
     new Employee()
      { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
     new Employee()
      { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
     new Employee()
      { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
     new Employee()
      { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
     new Employee()
      { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepId = 4 }
    };

    
    /*1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке.
    2) Вывести список стран без повторений.
    3) Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет.
    4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает
    23 года*/

    Console.WriteLine("6) People working in Ukraine, but not in Donetsk");
    var collection6 = employees
     .Where(employees => employees.DepId == 2)
     .OrderBy(employees => employees.FirstName);
    
    collection6.ToList().ForEach(employees => Console.WriteLine(employees));
    
    Console.WriteLine("7) List of all unique countries");
    var collection7 = departments
     .Select(departments => departments.Country)
     .Distinct();
     
    collection7.ToList().ForEach(departments => Console.WriteLine(departments));
    
    Console.WriteLine("8) First Three employees with age over 25");
    var collection8 = employees
     .Where(employees => employees.Age > 25)
     .OrderByDescending(employees => employees.Age)
     .Take(3);

    collection8.ToList().ForEach(employees => Console.WriteLine(employees));
    // студентов ? 
    Console.WriteLine("9) Select employees from Kiev with an age above 23");
    var collection9 = employees
     .Where(employees => employees.DepId == 2 && employees.Age > 23);

    collection9.ToList().ForEach(employees => Console.WriteLine(employees));
    
    /*1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в
    Украине. Выполнить запрос немедленно.
    2) Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName,
     LastName, Age. Выполнить запрос немедленно.
    3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается
     в списке.*/

    Console.WriteLine("10) Select and sort first and last names of employees which are in Ukraine.");
    var collection10 = employees
     .Where(employees => employees.DepId == 2 || employees.DepId == 1);

    var collection10x = from emp in collection10
     orderby emp.FirstName, emp.LastName
      select emp;

    collection10x.ToList().ForEach(employees => Console.WriteLine(employees));
    
    Console.WriteLine("11) Sort all employees by age in a descending order");
    var collection11 = employees
      .OrderByDescending(employees => employees.Age);

    collection11.ToList().ForEach(employees => Console.WriteLine(employees));
    
    Console.WriteLine("12) Group up employees age and it's presence in a collection");
    var collection12 = from emp in employees
     group emp by emp.Age into g
     select new { Age = g.Key, Count = g.Count() };

    collection12.ToList().ForEach(employees => Console.WriteLine(employees));
    
   }
  }
 
