using Cocomix_API.DTO;
using Cocomix_API.Models;

namespace Cocomix_API.Service
{
    public interface OrderService
    {
        public Task<List<Order>> getListOrder();
        public Task<Order> getOrderById(int id);
        public Task<Order> addOrder(OrderDTO orderDTO);
        public Task<Order> updateOrder(int id , DataOrderDTO dataOrderDTO);
        public  Task<string> deleteOrder(int id);

    }
}
