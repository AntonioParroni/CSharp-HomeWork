/*Делегаты
Реализовать метод, который осуществляет поиск элемента в
массиве. Метод должен принимать массив Object [] array, в котором
    должен осуществляться поиск, и делегат, определяющий, является
    ли элемент искомым.*/

using System;
namespace Delegate
{
    public struct MyItem
    {
        public string Name;
        public string Code;
        public float Price;
            
        public MyItemType Type;
        public enum MyItemType
        {
            Furniture,
            Consumable, Clothes,
            Mechanical, TrashItem
        }
        public MyItem(string Code, string Name, float Price, MyItem.MyItemType Type)
        {
            this.Code = Code;
            this.Name = Name;
            this.Price = Price;
            this.Type = Type;
        }
        public override string ToString()
        {
            return string.Format("Type: " + Type + " \t  Name:" + Name + "\t ID:" + Code + " \t Price:" + Price + "$");
        }
    }
    
    class Program
    {
        static public void Find(Object[] array, Comparer comparer)
        {
            int i = 0;
            bool flag = false;
            foreach (var item in array)
            {
                i++;
                if (comparer(item))
                {
                    flag = true;
                    Console.WriteLine("Found At Index = " + i + 
                        "\n" + item.ToString());
                }
            }
            if (!flag)
            {
                Console.WriteLine("Not Found!");
                throw new Exception("Invalid Argument");
            }
        }

        public delegate Boolean Comparer(Object elem1);

        static public Boolean CodeComparer(Object goods)
        {
            return ((MyItem)goods).Code == "01";
        }

        static public Boolean TypeComparer(Object goods)
        {
            return ((MyItem)goods).Type == MyItem.MyItemType.TrashItem;
        }

        static public Boolean NameComparer (Object goods)
        {
            return ((MyItem)goods).Name == "Arduino";
        }
        
        static public Boolean PriceComparer (Object goods)
        {
            return ((MyItem)goods).Price == 9.99F;
        }

        static void Main(string[] args)
        {
            MyItem good1 = new MyItem("01", "Table", 22.9F, MyItem.MyItemType.Furniture);
            MyItem good2 = new MyItem("02", "Chips", 12.5F, MyItem.MyItemType.Consumable);
            MyItem good3 = new MyItem("03", "Arduino", 59.9F, MyItem.MyItemType.Mechanical);
            MyItem good4 = new MyItem("04", "Jeans",9.99F, MyItem.MyItemType.Clothes);
            MyItem good5 = new MyItem(null, null,0.0F, MyItem.MyItemType.TrashItem);


            Object[] GoodsArray = { good1, good2, good3, good4, good5};
            
            uint i = 0;
            foreach (Object goods in GoodsArray)
            {
                Console.WriteLine("{0}.{1}", i, goods);
                i++;
            }
            
            
            Console.WriteLine("\nFind Article With 01 Code \n");
            Find(GoodsArray, new Comparer(CodeComparer));

            Console.WriteLine("\nFind Type of Trash Article \n");
            Find(GoodsArray, new Comparer(TypeComparer));

            Console.WriteLine("\nFind Name of Article Arduino \n");
            Find(GoodsArray, new Comparer(NameComparer));
            
            Console.WriteLine("\nFind Article With Price 9.99$  \n");
            Find(GoodsArray, new Comparer(PriceComparer));
        }
    }
}