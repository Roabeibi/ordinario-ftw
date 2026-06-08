using Microsoft.AspNetCore.Mvc;
using EstancionamientoRoa.Controllers;
namespace EstancionamientoRoa.Controllers;
public class ReportesController : Controller
{
public IActionResult Index()
{
if(HttpContext.Session.GetString("logueado") != "true")
{
return RedirectToAction("Index","Login");
}
ViewBag.TotalVehiculos =
HomeController.listaVehiculos.Count;
ViewBag.TotalEntradas =
HomeController.listaEntradas.Count;
ViewBag.TotalSalidas =
HomeController.listaSalidas.Count;
ViewBag.IngresoTotal =
HomeController.listaSalidas.Count * 20;
int dentro =
HomeController.listaEntradas.Count
-
HomeController.listaSalidas.Count;
if(dentro < 0)
{
dentro = 0;
}
ViewBag.VehiculosDentro = dentro;
ViewBag.HoraActual =
DateTime.Now.ToString("HH:mm:ss");
double ocupacion =
(dentro * 100.0) / 50;
ViewBag.Ocupacion =
ocupacion.ToString("0.0");
return View();}}