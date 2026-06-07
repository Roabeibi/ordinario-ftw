using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EstancionamientoRoa.Models;
namespace EstancionamientoRoa.Controllers;
public class HomeController : Controller{
//comentarios
    public static List<Comentario> listaComentarios = new List<Comentario>();
//  vehículos
    public static List<Vehiculo> listaVehiculos = new List<Vehiculo>();
//  entradas
    public static List<Entrada> listaEntradas = new List<Entrada>();
//   salidas
    public static List<Salida> listaSalidas = new List<Salida>();
//  principal
    public IActionResult Index(){
    return View();}
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
    public IActionResult Vehiculos(){
        return View(listaVehiculos);}
//  vehículo
    [HttpPost]
    public IActionResult GuardarVehiculo(string placa, string modelo, string color){
        Vehiculo vehiculo = new Vehiculo();
        vehiculo.Placa = placa;
        vehiculo.Modelo = modelo;
        vehiculo.Color = color;

        listaVehiculos.Add(vehiculo);

        return RedirectToAction("Vehiculos");}

 //  entradas
    public IActionResult Entradas()
    {
        return View(listaEntradas);}

//  entrada
    [HttpPost]
    public IActionResult GuardarEntrada(string placa, string horaEntrada, string lugar)
    {
        Entrada entrada = new Entrada();

        entrada.Placa = placa;
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
// error
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }}