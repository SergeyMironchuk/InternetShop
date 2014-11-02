namespace InternetShop.Models.Shop.Entities
{
    public class OrderLine
    {
        public Product Product { get; set; } 
        public int Kolich { get; set; }

        public decimal OrderLineSum
        {
            get
            {
                var sum = Product.Price*Kolich;
                return sum;
            }
        }
    }
}