using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
{
    public class ModifiedOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public string BuyerId { get; set; }

        public string UserName { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string Address { get; set; }
        public string PaymentAuthCode { get; set; }
        public decimal OrderTotal { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        protected ModifiedOrder()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
