using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.API.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
