namespace Interface2
{
    public abstract class Goods
    {
        public Goods(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
 
        public double Price { get; set; }
 
        public string Name { get; set; }
 
        public int Quantity { get; set; }
        
 
        public abstract void ShowInformation();
    }
}