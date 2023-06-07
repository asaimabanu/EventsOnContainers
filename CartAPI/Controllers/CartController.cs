using CartAPI.Data;
using CartAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CartAPI.Controllers
    {
    [Authorize]
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
        public async Task<IActionResult> Get(string  id)
            {
            var basket = await _cartRepository.GetCartAsync (id);
            return Ok (basket);
            }

        [HttpPost]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]Cart basket)
            {
            var updated_basket = await _cartRepository.UpdateCartAsync(basket);
            return Ok(updated_basket);
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
            {
            var result = await _cartRepository.DeleteCartAsync(id);
            return Ok(result);
            }
        }
    }
