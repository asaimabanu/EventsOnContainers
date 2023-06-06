using WebMvc.Models;
using WebMvc.Models.CartModels;

namespace WebMvc.Services
    {
    public interface ICartService
        {
        Task<Cart> GetCart(ApplicationUser applicationUser);
        Task AddItemToCart(ApplicationUser applicationUser, CartItem item);

        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> SetTicketQuantity(ApplicationUser applicationUser, Dictionary<string, int> ticketQuantity);
        Task ClearCart(ApplicationUser applicationUser);


        }
    }
