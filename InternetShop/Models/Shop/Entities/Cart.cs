using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Models.Shop.Entities
{
    public class Cart
    {
        public virtual List<OrderLine> OrderLines { get; set;}

        public int CountOfProd
        {
            get { return OrderLines.Sum(orderLine => orderLine.Kolich); }
        }

        public decimal OrderSum
        {
            get { return OrderLines.Sum(orderLine => orderLine.Product.Price*orderLine.Kolich); }
        }

        public Cart()
        {
            OrderLines = new List<OrderLine>();
        }
    }
}