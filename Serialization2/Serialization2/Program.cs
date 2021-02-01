/*С помощью класса XmlTextWriter напишите приложение, сохраняющее в XML-файл информацию о заказах.
Каждый заказ представляет собой несколько товаров.
Информацию, характеризующую заказы и товары необходимо разработать самостоятельно.
Считайте информацию из XML-документа, полученного в первом задании с помощью классов XmlDocument
и XmlTextReader и выведите полученную информацию
на экран*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization2
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer {get; set;}

        public override string ToString()
        {
            return string.Format("Type: " + Type + " Name: " + Name + " Manufacturer: " + Manufacturer + " ID: " + Id);
        }
    }

    class Order
    {
        public int orderId { get; set; }
        public string orderDate { get; set; }
        public double orderPrice { get; set; }
        public int quantity { get; set; }
        public override string ToString()
        {
            return string.Format("OrderID: " + orderId + " Quantity: " + quantity + " OrderDate: " + orderDate + " OrderPrice: " + orderPrice + "$");
        }
    }

    class Orders
    {
        public Dictionary<Product,Order> orders { get; set; }

        public void showOrders()
        {
            foreach (KeyValuePair<Product, Order> keyValue in orders)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.WriteLine();
        }
    }


    class Program
    {
        static void WriteXml(ref Orders orders, string path)
        {
            XmlTextWriter writer = new XmlTextWriter(path, Encoding.Default);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("OrderList");

            for (int index = 0; index < orders.orders.Count; index++) {
                var item = orders.orders.ElementAt(index);
                var itemKey = item.Key;
                var itemValue = item.Value;
                
                writer.WriteStartElement("OrderID", itemValue.orderId.ToString());
                writer.WriteElementString("Price", itemValue.orderPrice.ToString());
                writer.WriteElementString("Quantity", itemValue.quantity.ToString());
                writer.WriteElementString("ProductName", itemKey.Name);
                writer.WriteElementString("ProductManufacturer", itemKey.Manufacturer);
                writer.WriteElementString("ProductType", itemKey.Type);
                writer.WriteElementString("ProductID", itemKey.Id.ToString());
                writer.WriteElementString("Date", itemValue.orderDate);
                writer.WriteEndElement();
            }
            /*foreach (KeyValuePair<Product, Order> entry in orders.orders)
            {
                writer.WriteStartElement("employee");
                writer.WriteAttributeString("id", employee.Id.ToString());
                writer.WriteElementString("id", employee.Id.ToString());
                writer.WriteElementString("name", employee.Name);
                writer.WriteElementString("lastname", employee.Lastname);
                writer.WriteElementString("city", employee.City);
                writer.WriteEndElement();
            }*/
            writer.WriteEndElement();
            writer.Close();
        }

        public static void DeserializeObject(string filename)
        {
            // жаль что так и не понял, почему это н работает
            
            Console.WriteLine("Reading with Stream");
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(Orders));

            // Declare an object variable of the type to be deserialized.
            Orders i;

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                i = (Orders) serializer.Deserialize(reader);
            }
            i.showOrders();
            /*for (int index = 0; index < i.orders.Count; index++)
            {
                var item = i.orders.ElementAt(index);
                var itemKey = item.Key;
                var itemValue = item.Value;
                Console.WriteLine();
            }*/
        }

        private static void PrintNodes(XmlNode elem)
        {
            if (elem.ChildNodes.Count > 0)
            {
                Console.WriteLine($"{elem.Name,-10} {elem.InnerText}");
                foreach (XmlNode node in elem.ChildNodes)
                {
                    PrintNodes(node);
                }
            }
        }
        
        static void ReadXmlDocument(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlElement root = xml.DocumentElement;
            PrintNodes(root);
        }
        
        static void ReadXml(string path)
        {
            XmlTextReader reader = new XmlTextReader(path);
            while (reader.ReadToFollowing("OrderID"))
            {
                reader.ReadToFollowing("Price");
                Console.WriteLine($"{reader.ReadString()}");
                reader.ReadToFollowing("Quantity");
                Console.WriteLine($"{reader.ReadString()}");
                reader.ReadToFollowing("Date");
                Console.WriteLine($"{reader.ReadString()}");
                reader.ReadToFollowing("ProductName");
                Console.WriteLine($"{reader.ReadString()}");
                reader.ReadToFollowing("ProductManufacturer");
                Console.WriteLine($"{reader.ReadString()}");
                reader.ReadToFollowing("ProductType");
                Console.WriteLine($"{reader.ReadString()}");
                reader.ReadToFollowing("ProductID");
                Console.WriteLine($"{reader.ReadString()}");
            }
            reader.Close();
        }
        
        static void WriteXmlDocument(ref Orders orders, string path)
        {
            XmlDocument xml = new XmlDocument();

            XmlElement employeesNode = xml.CreateElement("OrderList");

            for (int index = 0; index < orders.orders.Count; index++) {
                var item = orders.orders.ElementAt(index);
                var itemKey = item.Key;
                var itemValue = item.Value;
                
                XmlElement employeeNode = xml.CreateElement("OrderID");
                XmlAttribute attr = xml.CreateAttribute("id");
                attr.Value = itemValue.orderId.ToString();
                employeeNode.Attributes.Append(attr);
                employeesNode.AppendChild(employeeNode);


                XmlElement priceNode = xml.CreateElement("Price");
                priceNode.InnerText = itemValue.orderPrice.ToString();
                XmlElement nameNode = xml.CreateElement("Name");
                nameNode.InnerText = itemKey.Name;
                XmlElement typeNode = xml.CreateElement("Type");
                typeNode.InnerText = itemKey.Type;
                XmlElement manNode = xml.CreateElement("Manufacurer");
                manNode.InnerText = itemKey.Manufacturer;

                employeeNode.AppendChild(priceNode);
                employeeNode.AppendChild(nameNode);
                employeeNode.AppendChild(typeNode);
                employeeNode.AppendChild(manNode);
            }
            xml.AppendChild(employeesNode);
            xml.Save(path);
        }
        
        
        static void Main(string[] args)
        {
            Product x = new Product
            {
                Id = 1, Manufacturer = "Malaysia", Name = "AMD", Type = "Processor"
            };
            Order y = new Order
            {
                orderId = 1, quantity = 5, orderPrice = 44.99, orderDate = "10.01.2020"
            };

            Orders z = new Orders();
            z.orders = new Dictionary<Product, Order>();
            z.orders.Add(x,y);
            
            z.showOrders();
            
            Product xy = new Product
            {
                Id = 2, Manufacturer = "Russia", Name = "Elbrus", Type = "Processor"
            };
            Order yx = new Order
            {
                orderId = 2, quantity = 100, orderPrice = 999.99, orderDate = "11.01.2020"
            };

            z.orders.Add(xy,yx);
            z.showOrders();
            
            WriteXml(ref z,"test.xml");
            ReadXml("test.xml");
            //DeserializeObject("test.xml");
            
            ReadXmlDocument("test.xml");
            WriteXmlDocument(ref z, "test.xml");

            


        }
    }
}
        