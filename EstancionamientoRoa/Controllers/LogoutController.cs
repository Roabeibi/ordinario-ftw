using Microsoft.AspNetCore.Mvc;
namespace EstancionamientoRoa.Controllers;
public class LogoutController : Controller
{
    public IActionResult Index()
    {
        HttpContext.Session.Remove("logueado");
        TempData["msg"] = "Sesión cerrada";
        return RedirectToAction("Index", "Login");
    }
}