using Microsoft.AspNetCore.Mvc;
namespace EstancionamientoRoa.Controllers;
public class ReportesController : Controller{
public IActionResult Index(){
var logueado = HttpContext.Session.GetString("logueado");
if(logueado != "true")
{
return RedirectToAction("Index","Login");
}
ViewBag.TotalVehiculos = HomeController.listaVehiculos.Count;
ViewBag.TotalEntradas = HomeController.listaEntradas.Count;
ViewBag.TotalSalidas = HomeController.listaSalidas.Count;
ViewBag.IngresoTotal = HomeController.listaSalidas.Count * 20;
return View();}}