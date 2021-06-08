using OnlineStoreAPI.DBModels;
using OnlineStoreDTO;
using System;
using System.Linq;

namespace TEMPProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new online_storeContext();

            var res = context.Orderproducts
                .Where(op => op.OrderId == 2)
                .Select(o => new ProductDTO
                {
                    Id = o.Product.Id,
                    Name = o.Product.Name,
                    Price = o.Product.Price
                })
                .ToArray();

            foreach (var e in res)
            {
                // Console.WriteLine(e.OrderId + " " + e.ProductId);
                Console.WriteLine(e.Id + " " + e.Name + " " + e.Price);
            }


        }
    }
}
