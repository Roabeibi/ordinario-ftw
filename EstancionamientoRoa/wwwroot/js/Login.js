async function validarLogin() {

    let usuario = document.getElementById("usuario").value;
    let password = document.getElementById("password").value;
    let respuesta = await fetch("/xml/usuarios.xml");
    let texto = await respuesta.text();
    let parser = new DOMParser();
    let xml = parser.parseFromString(texto, "text/xml");
    let usuarios = xml.getElementsByTagName("usuario");
    let valido = false;
    for (let i = 0; i < usuarios.length; i++) {
        let nombre = usuarios[i]
            .getElementsByTagName("nombre")[0]
            .textContent;

        let pass = usuarios[i]
            .getElementsByTagName("password")[0]
            .textContent;

        if (usuario == nombre && password == pass) {
            valido = true;
        }
    }
 let mensaje = document.getElementById("mensaje");

 if (valido) {
        mensaje.innerHTML = "Usuario correcto";
    }
 else {
        mensaje.innerHTML = "Usuario incorrecto";
    }
}