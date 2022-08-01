using Microsoft.AspNetCore.Mvc;

namespace FourBlog_Lucas.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
