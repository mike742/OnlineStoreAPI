using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineStoreAPI.DBModels
{
    public partial class Orderproduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
