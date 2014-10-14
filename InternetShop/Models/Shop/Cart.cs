using System.Collections.Generic;

namespace InternetShop.Models.Shop
{
    public class Cart
    {
        public List<OrderLine> OrderLines { get; set; }

        public Cart()
        {
            OrderLines = new List<OrderLine>();
        }
    }
}