function filtrarTabla(inputId, tablaId){

let input=document.getElementById(inputId);
let filtro=input.value.toLowerCase();

let filas=document.querySelectorAll("#"+tablaId+" tr");

for(let i=1;i<filas.length;i++){

let placa=filas[i].children[0].innerText.toLowerCase();

if(placa.includes(filtro)){
filas[i].style.display="";
}else{
filas[i].style.display="none";
}

}

}