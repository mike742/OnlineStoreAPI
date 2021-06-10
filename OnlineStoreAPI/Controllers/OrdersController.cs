using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.DBModels;
using OnlineStoreAPI.ViewModels;
using OnlineStoreDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly online_storeContext _context;

        public OrdersController(online_storeContext context)
        {
            _context = context;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<OrderDTO> Get()
        {
            var res = _context.Orders
                .Select(o => new OrderDTO {
                    Id = o.Id,
                    Name = o.Name,
                    Date = o.Date,
                    Products = _context.Orderproducts
                        .Where(op => op.OrderId == o.Id)
                        .Select(p => new ProductDTO {
                            Id = p.Product.Id,
                            Name = p.Product.Name,
                            Price = p.Product.Price
                        })
                        .ToList()
                })
                .ToList();

            return res;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public OrderDTO Get(int id)
        {
            var res = _context.Orders
                .Where(e => e.Id == id)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    Name = o.Name,
                    Date = o.Date,
                    Products = _context.Orderproducts
                        .Where(op => op.OrderId == o.Id)
                        .Select(p => new ProductDTO
                        {
                            Id = p.Product.Id,
                            Name = p.Product.Name,
                            Price = p.Product.Price
                        })
                        .ToList()
                })
                .FirstOrDefault();


            return res;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] OrderVM value)
        {
            int lastId = _context.Orders.ToList().Last().Id + 1;

            Order newOrder = new Order { 
                Id = lastId,
                Name = value.Name,
                Date = value.Date
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            foreach (int id in value.ProductIds)
            {
                var ohp = new Orderproduct
                {
                    OrderId = lastId,
                    ProductId = id
                };

                _context.Orderproducts.Add(ohp);
            }
            _context.SaveChanges();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderVM value)
        {
            var orderToUpdate = _context.Orders.Where(o => o.Id == id)
                                        .FirstOrDefault();

            if (orderToUpdate != null)
            {
                orderToUpdate.Name = value.Name;
                orderToUpdate.Date = value.Date;

                _context.SaveChanges();
            }
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var orderToDelete = _context.Orders.Find(id);

            if (orderToDelete != null)
            {
                var produtsRange = 
                    _context.Orderproducts.Where(ohp => ohp.OrderId == id).ToList();
                _context.Orderproducts.RemoveRange(produtsRange);

                _context.Orders.Remove(orderToDelete);
                _context.SaveChanges();
            }
        }
    }
}
