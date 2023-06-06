using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using WebMvc.Models;
using WebMvc.Models.CartModels;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IEventCatalogService _catalogService;
        private readonly IIdentiyService<ApplicationUser> _identityService;

        public CartController(IIdentiyService<ApplicationUser> identityService,
            ICartService cartService, IEventCatalogService catalogService)
        {
            _identityService = identityService;
            _cartService = cartService;
            _catalogService = catalogService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities,
           string action)
        {
            if (action == "[ Checkout ]")
            {
                return RedirectToAction("Create", "Order");
            }


            try
            {
                var user = _identityService.Get(HttpContext.User);
                var basket = await _cartService.SetTicketQuantity(user, quantities);
                var vm = await _cartService.UpdateCart(basket);

            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit  mode                 
                HandleBrokenCircuitException();
            }

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(EventItem eventDetails)
        {
            try
            {
                if (Convert.ToInt32(eventDetails.Id) > 0)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var cart_event = new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Quantity = 1,
                        EventName = eventDetails.Title,
                        PictureUrl = eventDetails.PictureUrl,
                        TicketPrice = Convert.ToDecimal(eventDetails.Price),
                        EventId = eventDetails.Id.ToString()
                    };
                    await _cartService.AddItemToCart(user, cart_event);
                }
            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in circuit-opened mode                 
                HandleBrokenCircuitException();
            }

            return RedirectToAction("Search", "EventCatalog");

        }

        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }
    }
}
