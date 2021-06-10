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

            int id = 8;
            var orderToDelete = context.Orders.Find(id);

            var produtsRange =
                    context.Orderproducts.Where(ohp => ohp.OrderId == id).ToList();

            foreach (var e in produtsRange)
            {
                Console.WriteLine( e.OrderId + " " + e.ProductId);
            }
        }
    }
}
