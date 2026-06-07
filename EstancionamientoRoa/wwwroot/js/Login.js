document.getElementById("formLogin")
.addEventListener("submit",async function(event){
event.preventDefault();
let usuario=document.getElementById("usuario").value;
let password=document.getElementById("password").value;
let resultado=document.getElementById("resultadoLogin");
let respuesta=await fetch("/xml/usuarios.xml");
let texto=await respuesta.text();
let parser=new DOMParser();
let xml=parser.parseFromString(texto,"text/xml");
let usuarios=xml.getElementsByTagName("usuario");
let valido=false;
for(let i=0;i<usuarios.length;i++){
let nombre=usuarios[i]
.getElementsByTagName("nombre")[0]
.textContent.trim();
let pass=usuarios[i]
.getElementsByTagName("password")[0]
.textContent.trim();
if(usuario.trim()==nombre &&
password.trim()==pass){
valido=true;
}
}
if(valido){
resultado.innerHTML="Inicio de sesion correcto";
}
else{
resultado.innerHTML="Usuario o contraseña incorrectos";
}
});