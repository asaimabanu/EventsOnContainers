using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using WebMvc.Infrastructure;
using WebMvc.Models;
using WebMvc.Models.CartModels;

namespace WebMvc.Services
    {
    public class CartService : ICartService
        {
        private readonly string _baseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpClient _apiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IConfiguration configuration, 
            IHttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            {
            _configuration = configuration;
            _apiClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _baseUrl = $"{configuration["CartUrl"]}/api/cart";
            }

        private async Task<string> GetTokenAsync()
            {
            var context = _httpContextAccessor.HttpContext;
            return await context.GetTokenAsync("access_token");
            }
        public async Task AddItemToCart(ApplicationUser applicationUser, CartItem item)
            {
            var cart = await GetCart(applicationUser);

            var basketItem = cart.Items.Where(e => e.EventId ==  item.EventId).FirstOrDefault();
            if (basketItem != null)
                {
                basketItem.Quantity++;
                }
            else
                {
                cart.Items.Add(item);
                }
            await UpdateCart(cart);
            }

        public async Task ClearCart(ApplicationUser applicationUser)
            {
            var token = await GetTokenAsync();
            var deleteUri = APIPaths.Basket.CleanBasket(_baseUrl, applicationUser.Email);
            await _apiClient.DeleteAsync(deleteUri, token);
            }

        public async Task<Cart> GetCart(ApplicationUser applicationUser)
            {
            var token = await GetTokenAsync();

            var getBasketUri = APIPaths.Basket.GetBasket(_baseUrl, applicationUser.Email);
            var datastring = await _apiClient.GetStringAsync(getBasketUri, token);
            var response = JsonConvert.DeserializeObject<Cart>(datastring) ?? 
                new Cart
                    {
                    BuyerId = applicationUser.Email
                    };
            return response;
            }

        public async Task<Cart> SetTicketQuantity(ApplicationUser applicationUser, 
            Dictionary<string, int> ticketQuantity)
            {
            var basket = await GetCart(applicationUser);
            basket.Items.ForEach(x =>
            {
                if (ticketQuantity.TryGetValue(x.Id, out var quantity))
                    {
                    x.Quantity = quantity;
                    }
            });
            return basket;
            }

        public async Task<Cart> UpdateCart(Cart cart)
            {
            var token = await GetTokenAsync();
            var updateUri = APIPaths.Basket.UpdateBasket(_baseUrl);

            var response = await _apiClient.PostAsync(updateUri, cart, token);

            response.EnsureSuccessStatusCode();
            return cart;
            }
        }
    }
