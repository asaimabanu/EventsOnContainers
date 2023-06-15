using CartAPI.Data;
using Common.Messaging;
using MassTransit;

namespace CartApi.Messaging.Consumers
{
    public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
    {
        private readonly ICartRepositiry _repository;
        public OrderCompletedEventConsumer(ICartRepositiry repository)
        {
            _repository = repository;
        }
        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
        {
            await _repository.DeleteCartAsync(context.Message.BuyerId);
        }
    }
}