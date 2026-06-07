async function cargarVehiculos(){
let filtro=document
.getElementById("buscarVehiculo")
.value
.toLowerCase();
let respuesta=await fetch("/xml/vehiculos.xml");
let texto=await respuesta.text();
let parser=new DOMParser();
let xml=parser.parseFromString(texto,"text/xml");
let vehiculos=xml.getElementsByTagName("vehiculo");
let tabla=document.getElementById("tablaVehiculos");
tabla.innerHTML=`
<tr>
<th>Placa</th>
<th>Modelo</th>
<th>Color</th>
</tr>
`;

for(let i=0;i<vehiculos.length;i++){

let placa=vehiculos[i]
.getElementsByTagName("placa")[0]
.textContent;

let modelo=vehiculos[i]
.getElementsByTagName("modelo")[0]
.textContent;

let color=vehiculos[i]
.getElementsByTagName("color")[0]
.textContent;

if(placa.toLowerCase().includes(filtro)){

tabla.innerHTML+=`
<tr>
<td>${placa}</td>
<td>${modelo}</td>
<td>${color}</td>
</tr>
`;

}

}

}