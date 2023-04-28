using Microsoft.AspNetCore.Mvc;

namespace EventsCatalogAPI.Controllers
{
    [ApiController]
    [Route("api/pic")]
    public class PicController : Controller
    {
        //private const int x = 10;

        private readonly IWebHostEnvironment _hostEnvironment;
        //Injecting host environment to the controller
        public PicController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet("{picId}")]
        //ActionResult=MethodResult, type is  not specified
        public IActionResult GetImage(int picId)
        {
            var webRoot = _hostEnvironment.WebRootPath;
            var path = Path.Combine($"{webRoot}/Pics/", $"event_{picId}.jpg");
            var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/jpeg");
        }
    }
}
