using WebMvc.Models.OrderModels;

namespace WebMvc.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(OrderToApi order);

        OrderToApi MapOrderToOrderApi(Order order);
    }
}
