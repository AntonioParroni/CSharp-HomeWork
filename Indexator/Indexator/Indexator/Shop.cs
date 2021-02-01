namespace Indexator
{
    public class Shop
    {
        public Laptop[] ShopArray;
        
        public Shop()
        {
            ShopArray = new Laptop[10];
        }
       
        public Laptop this[int index]
        {
            get
            {
                return ShopArray[index];
            }
            set
            {
                ShopArray[index] = value;
            }
        }
    }
}