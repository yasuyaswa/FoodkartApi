using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodkartApi.Model;
using AutoMapper;
using FoodkartApi.DataModels.Customer;

namespace FoodkartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly FoodAppContext _context;
        private readonly IMapper mapper;

        public OrderDetailsController(FoodAppContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsById()
        {
          if (_context.OrderDetails == null)
          {
              return NotFound();
          }
            return await _context.OrderDetails.ToListAsync();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
        {
          if (_context.OrderDetails == null)
          {
              return NotFound();
          }
            var orderDetail = await _context.OrderDetails.FindAsync(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        /*[HttpGet("OrderDetail")]
        public IActionResult GetItemNameByItemId(int ItemId)
        {


            var query = from f in _context.Menus
                        join n in _context.OrderDetails on f.ItemId equals n.ItemId
                        where n.ItemId.Equals(ItemId)
                        group new { f, n} by 1 into g
                        select new
                        {
                            f.ItemPrice
                            Sum(x=> x.f.ItemPrice * x.n.ItemQty),

                        };
            return Ok(query);
        }
        */
        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (id != orderDetail.Sno)
            {
                return BadRequest();
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderDetailExists(id))
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

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetailCreateDto>> PostOrderDetail(OrderDetailCreateDto orderDetailDto)
        {
            var orderDetail = mapper.Map<OrderDetail>(orderDetailDto);
          if (_context.OrderDetails == null)
          {
              return Problem("Entity set 'FoodAppContext.OrderDetails'  is null.");
          }
            await _context.OrderDetails.AddAsync(orderDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (await OrderDetailExists(orderDetail.Sno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.Sno }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> OrderDetailExists(int id)
        {
            return await _context.OrderDetails.AnyAsync(e => e.Sno == id);
        }
    }
}
