using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.DBModels;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
