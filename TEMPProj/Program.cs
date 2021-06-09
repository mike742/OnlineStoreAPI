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

            int lastId =  context.Orders.ToList().Last().Id;

            Console.WriteLine("lastId = " + lastId);

        }
    }
}
