using Microsoft.AspNetCore.Mvc;
using System.Xml;
using EstancionamientoRoa.Models;
namespace EstancionamientoRoa.Controllers;
public class LoginController : Controller
{
public IActionResult Index()
{
return View();
}
[HttpPost]
public IActionResult Index(string usuario,string password)
{
string ruta = Path.Combine(
Directory.GetCurrentDirectory(),
"wwwroot/xml/usuarios.xml");
List<Usuario> listaUsuarios = new List<Usuario>();
XmlDocument doc = new XmlDocument();
doc.Load(ruta);
XmlNodeList nodos = doc.GetElementsByTagName("usuario");
foreach(XmlNode nodo in nodos){
Usuario u = new Usuario();
u.Nombre = nodo["nombre"].InnerText;
u.Password = nodo["password"].InnerText;
listaUsuarios.Add(u);}
bool valido = false;
foreach(Usuario u in listaUsuarios){
if(u.Nombre == usuario && u.Password == password){
valido = true;
break;}}
if(valido){
HttpContext.Session.SetString("logueado","true");
return RedirectToAction("Dashboard","Home");}
ViewBag.Error = "Usuario o contraseña incorrectos";
return View();}
}