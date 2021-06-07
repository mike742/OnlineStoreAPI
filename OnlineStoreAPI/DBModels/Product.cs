using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineStoreAPI.DBModels
{
    public partial class Product
    {
        public Product()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
