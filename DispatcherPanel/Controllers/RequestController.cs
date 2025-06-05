using Microsoft.AspNetCore.Mvc;

namespace DispatcherPanel.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
