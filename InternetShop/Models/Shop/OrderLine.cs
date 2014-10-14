using InternetShop.Models.Shop.Entities;

namespace InternetShop.Models.Shop
{
    public class OrderLine
    {
        public Product Product { get; set; } 
        public int Kolich { get; set; }
    }
}