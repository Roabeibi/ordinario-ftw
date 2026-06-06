using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EstancionamientoRoa.Models;

namespace EstancionamientoRoa.Controllers;

public class HomeController : Controller
{
    public static List<Comentario> listaComentarios = new List<Comentario>();

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Comentarios()
    {
        return View(listaComentarios);
    }

    [HttpPost]
    public IActionResult GuardarComentario(string nombre, string mensaje)
    {
        Comentario comentario = new Comentario();

        comentario.Nombre = nombre;
        comentario.Mensaje = mensaje;

        listaComentarios.Add(comentario);

        return RedirectToAction("Comentarios");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}