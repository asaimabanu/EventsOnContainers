using CartAPI.Models;

namespace CartAPI.Data
    {
    public interface ICartRepositiry
        {
        Task<Cart> GetCartAsync(string cartId);
        Task<Cart> UpdateCartAsync(Cart basket);

        Task<bool> DeleteCartAsync(string cartId);

        }
    }
