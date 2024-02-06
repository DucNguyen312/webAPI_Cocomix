using Cocomix_API.DTO;
using Cocomix_API.Models;

namespace Cocomix_API.Service
{
    public interface OrderDetailsService
    {
        public Task<OrderDetail> GetOrderDetailById(int id);
        public Task<List<OrderDetail>> GetListOrderDetailsByOrderID(int orderID);
        public Task<OrderDetail> UpdateOderDetail(int id, OrderDetailsDTO orderDTO);
        public Task<string> deleteOrderDetails(int orderID);
    }
}
