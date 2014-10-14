using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop.Models.Shop.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  byte[] Image { get; set; }
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }
    }
}