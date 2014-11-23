using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop.Models.Shop.Entities
{
    [Table("Orders")]
    public class Order : Cart
    {
        public int id { get; set; }
        public virtual Person Person { get; set; }
        public DateTime Date { get; set; }
    }
}