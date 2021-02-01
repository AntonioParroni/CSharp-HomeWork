
/*События
    И н те рф е й с INotifyPropertyChanged пространства имен
System.ComponentModel определяет, что наследник содержит
событие PropertyChanged, оповещающее об изменении свойства
объекта. Изучить данный интерфейс, используя MSDN Library.
    Разработать классы: Author, Client, LibraryCard, Catalogue. Описать
их поля, поля инкапсулировать свойствами и для классов
    реализовать интерфейс INotifyPropertyChanged.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;



namespace Event2
{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public virtual Person DeepCopy(Person current)
        {
            Person copied = new Person(current.Name);
            return copied;
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
    
    public class Author : Person
    {
        public Author(string Name) : base(Name) { }

        public new Author DeepCopy(Person current)
        {
            return new Author(current.Name);
        }
    }
   
    class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Author Writer { get; set; }
        public string Title { get; set; }



        private Boolean available;
        public Boolean Available 
        {
            get { return available; }
            set
            {
                available = value;
                if (available == true) OnAvailableChanged();
            }
        }

        public virtual void OnAvailableChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Available"));
        }




        public Book(Author writer, string title)
        {
            this.Writer = writer.DeepCopy(writer);
            this.Title = title;
            this.Available = true;
        }
        
        public override string ToString()
        {
            return string.Format("\"{1}\" by {0}", Writer.Name, Title);
        }        
    }
    class Catalogue
    {
        public string Name { get; set; }
        public List < LibraryCard > clientCards;
        public List < Book > catalogue;



        public Catalogue(string Name)
        {
            this.Name = Name;
            this.catalogue = new List<Book>();
            this.clientCards = new List<LibraryCard>();
        }
        
        public void ShowCatalogue()
        {
            Console.WriteLine("\n{0} : There are {1} books and {2} clients.\n", Name, catalogue.Count, clientCards.Count);
            var i = 0;
            foreach (Book item in catalogue)
            {
                if (item.Available == true) Console.WriteLine("  {0}. {1}", i, item);
                else Console.WriteLine("- {0}. {1}", i, item);
                i++;
            }
            Console.WriteLine();
            var j = 0;
            foreach (LibraryCard card in clientCards)
            {
                if (card.clientBookList.Count != 0) Console.WriteLine("  {0}. {1}  has taken {2} books", j, card.Reader, card.clientBookList.Count);
                else Console.WriteLine("  {0}. {1} ", j, card.Reader);
                j++;
            }
            Console.WriteLine("\n");
        }
    }
    class Client : Person
    {
        public Client(string Name) : base(Name) { }


        public Client(string Name, Catalogue library): base(Name) 
        {
            this.Name = Name;
            for (int i = 0; i < library.catalogue.Count; i++)
            {
                library.catalogue[i].PropertyChanged += Client_OnAvailableChanged;
            }
        }
        public static void Client_OnAvailableChanged(object sender, PropertyChangedEventArgs e)
        {            
            Console.WriteLine("\nI'v got library message! {1} is {0}\n", e.PropertyName, sender.ToString());
        }
        public new Client DeepCopy(Person current)
        {
            return new Client(current.Name);
        }
    }
    class LibraryCard
    {
        public Client Reader { get; set; }
        public Dictionary<Book, DateTime> clientBookList;
        public LibraryCard(Client reader, Catalogue library)
        {
            this.Reader = reader.DeepCopy(reader);
            this.clientBookList = new Dictionary<Book, DateTime>();
        }
        public void ShowClientCard()
        {
            Console.WriteLine("\nThis is the Card of {0} : {1} books were taken.", Reader.Name, clientBookList.Count);
            var i = 0;
            foreach (KeyValuePair<Book, DateTime> kvp in clientBookList)
            {
                Console.WriteLine(" {0}. {1} -   {2}", i, kvp.Key, kvp.Value.ToString("d"));
                i++;
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Catalogue library = new Catalogue("Library");

            library.catalogue.Add(new Book((new Author("Isaac Asimov")), "The Foundation"));
            library.catalogue.Add(new Book((new Author("Steven Prata")), "C++ Language"));
            library.catalogue.Add(new Book((new Author("Lewis Carrol")), "Alice In WonderLand"));
            library.catalogue.Add(new Book((new Author("Fyodor Dostoyevsky")), "Crime and Punishment"));
            library.catalogue.Add(new Book((new Author("Unknown")), "The Bible"));

            library.clientCards.Add(new LibraryCard(new Client("Antonio Parroni", library), library));
            library.clientCards.Add(new LibraryCard(new Client("Olivia Evans", library), library));
            library.clientCards.Add(new LibraryCard(new Client("Isaac Asimov", library), library));

            library.ShowCatalogue();

            try
            {
                GiveOut(0, "Antonio Parroni", library);
                GiveOut(1, "Antonio Parroni", library);
                GiveOut(2, "Olivia Evans", library);
                GiveOut(3, "Isaac Asimov", library);
                GiveOut(4, "Isaac Asimov", library);

                library.ShowCatalogue();

                GetBack(4, "Isaac Asimov", library);
                GetBack(2, "Olivia Evans", library);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
            finally
            {
                library.ShowCatalogue();
            }

            Console.ReadKey();
        }

        static void GetBack(int bookIndex, string clientName, Catalogue library)
        {
            if (bookIndex > library.catalogue.Count || bookIndex < 0)
                throw new ArgumentOutOfRangeException("I can't take the book. bookIndex is out of range of catalogue.");

            Book book = library.catalogue[bookIndex];

            if (book.Available == true)
                Console.WriteLine("I can't take the book. This book is available already!!!");

            LibraryCard card = library.clientCards.Find(item => item.Reader.Name == clientName);

            if (card == null)
                Console.WriteLine("I can't take the book. There is no such Client! ");
            else
            {
                book.Available = true;
                Boolean rezult = card.clientBookList.Remove(book);
                if (rezult == false)
                    Console.WriteLine("I can't take the book. Client did not take the book!!!");
            }
        }

        static void GiveOut(int bookIndex, string clientName, Catalogue library)
        {
            if (bookIndex > library.catalogue.Count || bookIndex < 0)
                Console.WriteLine("I can't give out the book. bookIndex is out of range of catalogue");

            Book book = library.catalogue[bookIndex];

            if (book.Available == false)
                Console.WriteLine("I can't give out the book. This book is given out!!!");

            LibraryCard card = library.clientCards.Find(item => item.Reader.Name == clientName);

            if (card == null)
                Console.WriteLine("I can't give out the book. There is no such Client! ");
            else
            {
                book.Available = false;
                card.clientBookList.Add(book, DateTime.Today);
            }
        }
    }
}