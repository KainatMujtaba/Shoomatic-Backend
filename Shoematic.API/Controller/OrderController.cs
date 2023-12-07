using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoematic.API.Dto;
using Shoematic.Data;
using Shoematic.Data.Entities;
using System.Net;

namespace Shoematic.API.Controller
{
    public class OrderController : BaseController
    {
        public ShoematicDbContext Context { get; set; }
        public OrderController(ShoematicDbContext context)
        {
            Context = context;
        }

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(AddOrderRequestDto dto)
        {
            if (dto == null) { return BadRequest(ModelState); }
            var newOrder = new Order()
            {
                ProductId = dto.ProductId,
                UserId = dto.UserId,
                SizeId = dto.SizeId,
                OrderDate = DateTime.Now,
            };
            
            await Context.Orders.AddAsync(newOrder);
            
            try
            {
                await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.InnerException?.Message);
            }
            return StatusCode(200,"Order Created successfully");
        }

        [HttpGet("Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = Context.Orders
                .Include(x=>x.Product)
                .Include(x=>x.User)
                .Include(x=>x.Size)
                .Select(order=>new OrderDto()
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    ProductName = order.Product.Name, 
                    ProductColor = order.Product.Color,
                    ProductDescription = order.Product.Description,
                    ProductPrice = order.Product.Price,
                    UserAddress = order.User.Address,
                    UserName = order.User.UserName,
                    Size = order.Size.Name
                    
                }).ToList();

            return StatusCode(200,orders);
        }
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await Context.Orders.FirstOrDefaultAsync(p => p.Id == id);
            if (order is null)
                return StatusCode(404, "Order Not found");
            Context.Orders.Remove(order);
            await Context.SaveChangesAsync();
            return StatusCode(200, "Order deleted Successfully");
        }
    }
}
