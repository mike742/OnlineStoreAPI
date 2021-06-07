using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineStoreAPI.DBModels
{
    public partial class Order
    {
        public Order()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
