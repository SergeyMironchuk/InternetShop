using System.Data.Entity;

namespace InternetShop.Models.Shop.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbSet<Product> ProductList { get; set; }
    }
}