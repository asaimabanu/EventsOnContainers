using CartAPI.Data;
using CartAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CartAPI.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
        {
        private readonly ICartRepositiry _cartRepository;

        public CartController(ICartRepositiry cartRepository)
            {
            _cartRepository = cartRepository;
            }
        [HttpGet("{id}")]
        [ProducesResponseType (typeof(Cart), (int)HttpStatusCode.OK )]
        public async Task<ActionResult> Get(string  id)
            {
            var basket = await _cartRepository.GetCartAsync (id);
            return Ok (basket);
            }

        [HttpPost]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post(Cart basket)
            {
            var updated_basket = await _cartRepository.UpdateCartAsync(basket);
            return Ok(updated_basket);
            }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(string id)
            {
            var result = await _cartRepository.DeleteCartAsync(id);
            return Ok(result);
            }
        }
    }
