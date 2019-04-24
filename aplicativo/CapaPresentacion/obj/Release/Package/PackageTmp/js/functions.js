$(function () {
    $('#continuar').click(function (event) {
        /* Act on the event */
        console.log('Entro');
    });
    //Funcion para validar solo numeros
    $('#Contenido_cant_medidores').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
});