using Cocomix_API.DTO;
using Cocomix_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cocomix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOrder() 
        {
            try
            {
                return Ok(await _orderService.getListOrder());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getOrderByID(int id)
        {
            try
            {
                var order = await _orderService.getOrderById(id);
                return order != null ? Ok(order) : NotFound();
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> addOrder(OrderDTO orderDTO)
        {
            try
            {
                return orderDTO != null ? Ok(await _orderService.addOrder(orderDTO)) : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOrder(int id)
        {
            try
            {
                var result = await _orderService.deleteOrder(id);
                return result != null ? Ok(result) : NotFound();   
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateOrder(int id , DataOrderDTO data)
        {
            try
            {
                if (data == null)
                    return BadRequest();
                var result = await _orderService.updateOrder(id, data);
                return result != null ? Ok(result) : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
