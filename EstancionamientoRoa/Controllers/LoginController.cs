using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml;
namespace EstancionamientoRoa.Controllers;
public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(string usuario, string password)
    {
        string ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/xml/usuarios.xml");

        if (!System.IO.File.Exists(ruta))
        {
            ViewBag.Error = "No existe XML";
            return View();
        }

        string xmlTexto = System.IO.File.ReadAllText(ruta);
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlTexto);
        var nodos = doc.GetElementsByTagName("usuario");
        bool valido = false;
        for (int i = 0; i < nodos.Count; i++)
        {
            string nombre = nodos[i]["nombre"].InnerText;
            string pass = nodos[i]["password"].InnerText;
            if (usuario == nombre && password == pass)
            {
                HttpContext.Session.SetString("logueado", "true");
                valido = true;
                break;
            }}
        if (valido)
        {
            return RedirectToAction("Dashboard", "Home");
        }



        ViewBag.Error = "Usuario o contraseña incorrectos";
        return View();}}