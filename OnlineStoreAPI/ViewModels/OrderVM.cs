using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreAPI.ViewModels
{
    public class OrderVM
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<int> ProductIds { set; get; }
    }
}
