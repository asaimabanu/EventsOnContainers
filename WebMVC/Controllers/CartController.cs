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
        private readonly IEventCatalogService _eventcatalogService;
        private readonly IIdentiyService<ApplicationUser> _identityService;

        public CartController(IIdentiyService<ApplicationUser> identityService,
            ICartService cartService, IEventCatalogService eventcatalogService)
        {
            _identityService = identityService;
            _cartService = cartService;
            _eventcatalogService = eventcatalogService;
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
                var basket = await _cartService.SetQuantities(user, quantities);
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
        public async Task<IActionResult> AddToCart(EventItem eventtDetails)
        {
            try
            {
                if (int.Parse(eventtDetails.Id) > 0)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var product = new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Quantity = 1,
                        EventName = eventtDetails.Title,
                        PictureUrl = eventtDetails.PictureUrl,
                        TicketPrice = decimal.Parse(eventtDetails.Price),
                        EventId = eventtDetails.Id
                    };
                    await _cartService.AddItemToCart(user, product);
                }
            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in circuit-opened mode                 
                HandleBrokenCircuitException();
            }

            return RedirectToAction("Index", "EventCatalog");

        }

        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }
    }
}
