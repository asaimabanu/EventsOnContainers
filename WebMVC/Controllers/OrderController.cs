﻿using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using Stripe;
using WebMvc.Models;
using WebMvc.Models.OrderModels;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartService _cartSvc;
        private readonly IOrderService _orderSvc;
        private readonly IIdentiyService<ApplicationUser> _identitySvc;
        private readonly ILogger<OrderController> _logger;
        private readonly IConfiguration _config;


        public OrderController(IConfiguration config,
            ILogger<OrderController> logger,
            IOrderService orderSvc,
            ICartService cartSvc,
            IIdentiyService<ApplicationUser> identitySvc)
        {
            _identitySvc = identitySvc;
            _orderSvc = orderSvc;
            _cartSvc = cartSvc;
            _logger = logger;
            _config = config;
        }
        public async Task<IActionResult> Create()
        {
            var user = _identitySvc.Get(HttpContext.User);
            var cart = await _cartSvc.GetCart(user);
            var order = _cartSvc.MapCartToOrder(cart);
            ViewBag.StripePublishableKey = _config["StripePublicKey"];
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order frmOrder)
        {
                var user = _identitySvc.Get(HttpContext.User);
                var order = frmOrder;
                order.UserName = user.Email;
                order.BuyerId = user.Email;
                order.OrderDate = DateTime.Now;
                order.OrderStatus = OrderStatus.Preparing;

                var options = new RequestOptions
                {
                    ApiKey = _config["StripePrivateKey"]
                };

                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = (int)(order.OrderTotal * 100),
                    Currency = "usd",
                    Source = order.StripeToken,
                    Description = $"Event Order payment {order.UserName}",
                    ReceiptEmail = order.UserName
                };
                var chargeService = new ChargeService();
                Charge stripeCharge = null;

                try
                {
                    stripeCharge = chargeService.Create(chargeOptions, options);
                }
                catch (StripeException stripeException)
                {
                    _logger.LogDebug("Stripe exception " + stripeException.Message);
                    ModelState.AddModelError(string.Empty, stripeException.Message);
                    return View(frmOrder);
                }

                try
                {

                    if (stripeCharge.Id != null)
                    {
                        order.PaymentAuthCode = stripeCharge.Id;
                    var modifiedOrder = new ModifiedOrder
                    {
                        OrderId =order.OrderId,
                        FirstName = order.FirstName,
                        LastName = order.LastName,
                        OrderDate = order.OrderDate,
                        UserName = user.Email,
                        BuyerId = user.Email,
                        OrderStatus = OrderStatus.Preparing,
                        Address = order.Address,
                        PaymentAuthCode = order.PaymentAuthCode,
                        OrderTotal = order.OrderTotal,
                        OrderItems = order.OrderItems
                    };

                    int orderId = await _orderSvc.CreateOrder(modifiedOrder);

                        //await _cartSvc.ClearCart(user);
                        return RedirectToAction("Complete", new { id = orderId, userName = user.UserName });
                    }

                    else
                    {
                        ViewData["message"] = "Payment cannot be processed, try again";
                        return View(frmOrder);
                    }

                }
                catch (BrokenCircuitException)
                {
                    ModelState.AddModelError("Error", "It was not possible to create a new order, please try later on. (Business Msg Due to Circuit-Breaker)");
                    return View(frmOrder);
                }
        }

        public IActionResult Complete(int id, string userName)
        {

            _logger.LogInformation("User {userName} completed checkout on order {orderId}.", userName, id);
            return View(id);

        }

    }
}
