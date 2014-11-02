using System.Data.Entity;
using InternetShop.Models.Shop.Entities;

namespace InternetShop.Models.Shop
{
    public class ShopDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}