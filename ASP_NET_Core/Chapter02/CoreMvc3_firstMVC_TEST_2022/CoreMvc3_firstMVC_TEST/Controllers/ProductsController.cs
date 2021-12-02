using Microsoft.AspNetCore.Mvc;

namespace CoreMvc3_firstMVC_TEST.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
