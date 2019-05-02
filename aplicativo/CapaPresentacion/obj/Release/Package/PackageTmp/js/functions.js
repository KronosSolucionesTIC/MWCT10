$(function () {
    $('#continuar').click(function (event) {
        /* Act on the event */
        console.log('Entro');
    });
    //Funcion para validar solo numeros
    $('#Menu_cant_medidores').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
        if (this.value > 0) {
            document.getElementById("Menu_doc_entrada").disabled = false;
        } else {
            document.getElementById("Menu_doc_entrada").disabled = true;
        }
    });
    //Funcion para habilitar boton
    $('#Menu_doc_entrada').keypress(function (event) {
        console.log('Cambio');
        document.getElementById("Contenido_habilitar_grupo").disabled = false;
    });
    //Activa o desactiva checkbox
    $('#Menu_Individual').click(function (event) {
        console.log('Leyo click');
        if ($('#Menu_Individual').is(':checked')) {
            document.getElementById("Menu_Unico").checked = false;
        }
    });
    //Activa o desactiva checkbox
    $('#Menu_Unico').click(function (event) {
        console.log('Leyo click');
        if ($('#Menu_Unico').is(':checked')) {
            document.getElementById("Menu_Individual").checked = false;
        }
    });
});