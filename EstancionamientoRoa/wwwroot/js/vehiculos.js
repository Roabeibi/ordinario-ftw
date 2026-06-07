function filtrarVehiculos(){

let input=document.getElementById("buscarVehiculo");

let filtro=input.value.toLowerCase();

let tabla=document.getElementById("tablaVehiculos");

let filas=tabla.getElementsByTagName("tr");

for(let i=1;i<filas.length;i++){

let celda=filas[i].getElementsByTagName("td")[0];

if(celda){

let texto=celda.textContent||celda.innerText;

if(texto.toLowerCase().indexOf(filtro)>-1){

filas[i].style.display="";

}
else{

filas[i].style.display="none";

}

}

}

}
function validarVehiculo(){

let placa=document.getElementById("placa").value;
let modelo=document.getElementById("modelo").value;
let color=document.getElementById("color").value;

let valido=true;

document.getElementById("errorPlaca").innerHTML="";
document.getElementById("errorModelo").innerHTML="";
document.getElementById("errorColor").innerHTML="";

if(placa.length<3){

document.getElementById("errorPlaca").innerHTML="Placa invalida";

valido=false;
}

if(modelo==""){

document.getElementById("errorModelo").innerHTML="Escribe modelo";

valido=false;
}

if(color==""){

document.getElementById("errorColor").innerHTML="Escribe color";

valido=false;
}

return valido;
}

function buscarVehiculo(){

let placa=document.getElementById("buscarVehiculo").value;

let resultado=document.getElementById("resultadoBusqueda");

if(placa==""){
resultado.innerHTML="Escribe una placa";
}
else{
resultado.innerHTML="Buscando vehiculo con placa: "+placa;
}

}