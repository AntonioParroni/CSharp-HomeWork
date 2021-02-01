using System;

namespace Interface2
{
    public class Chemicals : Goods, IFlammableProduct, IGoodsActions
    {
        public Chemicals(string name, double price, int quantity, string productGroup = "Chemicals")
            : base(name, price, quantity)
        {
            ProductGroup = productGroup;
        }
 
        string ProductGroup { get; set; }
 
        public override void ShowInformation()
        {
            Console.WriteLine("Goods group:\t" + ProductGroup + "\nName:\t \t" + Name + "\nPrice:\t\t" + Price + "\nQuantity\t" + Quantity);
        }
        

        public void Inflammable(object obj)
        {
            if (obj.GetType() == typeof(Chemicals))
            {
                Chemicals t = obj as Chemicals;
                t.ShowInformation();
                Console.WriteLine("Is Burning");
            }
        }

        public void Inflammable()
        {
            ShowInformation();
            Console.WriteLine("Is Burning");
        }

        public void IsArrived(int ArrivedAmount)
        {
            Quantity+= ArrivedAmount;
        }

        public void IsRealized()
        {
            double earn = Price * Quantity;
            Console.WriteLine("Total Earnings " + earn +"$");
            Price = 0;
            Quantity = 0;
        }

        public void IsTransfer(int TransferAmount)
        {
            Quantity -= TransferAmount;
        }

        public void IsDrop()
        {
            Quantity = 0;
        }
    }
}