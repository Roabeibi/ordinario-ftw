using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EstancionamientoRoa.Data;
using MongoDB.Driver;
using EstancionamientoRoa.Models;
namespace EstancionamientoRoa.Controllers;
public class HomeController : Controller
{

MongoDBContext db = new MongoDBContext();

//comentarios
public static List<Comentario> listaComentarios = new List<Comentario>();
//vehiculos
public static List<Vehiculo> listaVehiculos = new List<Vehiculo>();
//entradas
public static List<Entrada> listaEntradas = new List<Entrada>();
//salidas
public static List<Salida> listaSalidas = new List<Salida>();
public static bool logueado=false;

//  principal
    public IActionResult Index()
{
if(!logueado)
{
return RedirectToAction("Index","Login");
}
return View();
}
//  S
public IActionResult Dashboard()
{
if(HttpContext.Session.GetString("logueado") != "true")
{
return RedirectToAction("Index","Login");
}

ViewBag.HoraActual = DateTime.Now.ToString("HH:mm:ss");
return View(listaVehiculos);
}
//  privacidad
    public IActionResult Privacy(){
        return View();}
//  comentarios
    public IActionResult Comentarios(){
        return View(listaComentarios);}
//  comentario
    [HttpPost]
public IActionResult GuardarComentario(string nombre, string mensaje){
        Comentario comentario = new Comentario();
        comentario.Nombre = nombre;
        comentario.Mensaje = mensaje;
        listaComentarios.Add(comentario);
        return RedirectToAction("Comentarios");}
//  vehículos
public IActionResult Vehiculos()
{

var lista =
db.Vehiculos.Find(_ => true).ToList();
return View(lista);
}
//  vehículo
    [HttpPost]
    public IActionResult GuardarVehiculo(string placa, string modelo, string color){
        Vehiculo vehiculo = new Vehiculo();
        vehiculo.Placa = placa;
        vehiculo.Modelo = modelo;
        vehiculo.Color = color;

db.Vehiculos.InsertOne(vehiculo);
        return RedirectToAction("Vehiculos");}

 //  entradas
    public IActionResult Entradas()
    {
        return View(listaEntradas);}

//  entrada
    [HttpPost]
public IActionResult GuardarEntrada(string placa,string modelo,string horaEntrada,string lugar)
    {
        Entrada entrada = new Entrada();

        entrada.Placa = placa;
        entrada.Modelo=modelo;
        entrada.HoraEntrada = horaEntrada;
        entrada.Lugar = lugar;
        listaEntradas.Add(entrada);
        return RedirectToAction("Entradas");}
//  salidas
    public IActionResult Salidas(){
        return View(listaSalidas);}
//  salida
    [HttpPost]
    public IActionResult GuardarSalida(string placa, string horaSalida, string pago)
    {
        Salida salida = new Salida();

        salida.Placa = placa;
        salida.HoraSalida = horaSalida;
        salida.Pago = pago;

        listaSalidas.Add(salida);

        return RedirectToAction("Salidas");}
//  login
    public IActionResult Login(){
        return View();}

public IActionResult Reportes()
{
    return View();
}

    //horario
    public IActionResult Horario()
    {
        return View();
    }

    //error
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}