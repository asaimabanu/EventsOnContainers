using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers
{
    public class EventTicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
