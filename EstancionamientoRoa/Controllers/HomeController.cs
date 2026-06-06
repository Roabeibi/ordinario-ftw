using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EstancionamientoRoa.Models;

namespace EstancionamientoRoa.Controllers;

public class HomeController : Controller
{
    public static List<Comentario> listaComentarios = new List<Comentario>();

    public static List<Vehiculo> listaVehiculos = new List<Vehiculo>();

    public static List<Entrada> listaEntradas = new List<Entrada>();

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

    public IActionResult Vehiculos()
    {
        return View(listaVehiculos);
    }

    [HttpPost]
    public IActionResult GuardarVehiculo(string placa, string modelo, string color)
    {
        Vehiculo vehiculo = new Vehiculo();

        vehiculo.Placa = placa;
        vehiculo.Modelo = modelo;
        vehiculo.Color = color;

        listaVehiculos.Add(vehiculo);

        return RedirectToAction("Vehiculos");
    }

    public IActionResult Entradas()
    {
        return View(listaEntradas);
    }

    [HttpPost]
    public IActionResult GuardarEntrada(string placa, string horaEntrada, string lugar)
    {
        Entrada entrada = new Entrada();

        entrada.Placa = placa;
        entrada.HoraEntrada = horaEntrada;
        entrada.Lugar = lugar;

        listaEntradas.Add(entrada);

        return RedirectToAction("Entradas");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
    public IActionResult Login()
{
    return View();

}

}
