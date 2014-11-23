using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop.Models.Shop.Entities
{
    [Table("OrderLines")]
    public class OrderLine
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; } 
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