using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeastHub;
using FeastHub.Auth;

namespace FoodDeliveryApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }
        [Route("searchfood")]
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItems>>> GetOrder(string name)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var data = Menus.FindAll(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));


            return data;

        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.UserId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [Route("AddToCart")]
        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostOrder(Cart cart)
        {
            // if (_context.Order == null)
            // {
            //     return Problem("Entity set 'AppDbContext.Order'  is null.");
            // }
            //// _context.Order.Add(order);
            // await _context.SaveChangesAsync();
           var cartitem= AddToCart(cart);
          //  return CreatedAtAction("AddToCart", new { id = cart.CartItems.CartItemId }, cartitem);
          return Ok(cartitem);
        }

        private List<Cart> AddToCart(Cart cart)
        {
               List<Cart> Menus =
                      new()
                      {
                           new Cart() { CartItems = new CartItem(){CartItemId=1,MenuId=2,Quantity=2,VendorId=1}, UserId = 1 },

                      };
            return Menus;
    }


        [Route("OrderFood")]
        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'AppDbContext.Order'  is null.");
            }
           // _context.Order.Add(order);
          //  await _context.SaveChangesAsync();
            var orderdata = PlaceOrder(order);
            return Ok(orderdata);
        }
        private List<Order> PlaceOrder(Order order)
        {
            List<Order> Menus =
                   new()
                   {
                           new Order() { CartItem = new (){1,2}, UserId = 1 },

                   };
            return Menus;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Order?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
        public static List<FoodItems> Menus =
                      new()
                      {
                           new FoodItems() { MenuId = 1, Name = "Jeera Pulao" },
                           new FoodItems() { MenuId = 2, Name = "Mutton Biryani" },
                           new FoodItems() { MenuId = 3, Name = "JChicken Biryani" }
                      };
    }
   
    public class FoodItems
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
    }
}
