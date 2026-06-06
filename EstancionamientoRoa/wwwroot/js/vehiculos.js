function filtrarVehiculos() {
    let input = document.getElementById("buscarVehiculo");
    let filtro = input.value.toLowerCase();
    let tabla = document.getElementById("tablaVehiculos");
    let filas = tabla.getElementsByTagName("tr");
    for (let i = 1; i < filas.length; i++) {
        let celda = filas[i].getElementsByTagName("td")[0];
        if (celda) {
            let texto = celda.textContent || celda.innerText;
            if (texto.toLowerCase().indexOf(filtro) > -1) {
                filas[i].style.display = "";
            } else {
                filas[i].style.display = "none";
            }
        }
    }
}