$(function () {
    $(document).ready(function () {
        /* Act on the event */

        tot = $('#Contenido_total').val();
        lis = $('#Contenido_listados').val();
        console.log(lis);

        if (lis < tot) {
            document.getElementById("Contenido_agregar_dispositivo").disabled = false;
        }
        if (lis == tot & tot > 0) {
            $('#Contenido_guardar').removeAttr('disabled');
        }
        if (lis > 0) {
            document.getElementById("Contenido_eliminar_dispositivo").disabled = false;
        }
    });
    $('#continuar').click(function (event) {
        /* Act on the event */
        console.log('Entro');
    });
    //Funcion para validar solo numeros
    $('#Contenido_cant_medidores').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
        if (this.value > 0) {
            document.getElementById("Contenido_agregar_dispositivo").disabled = false;
        } else {
            document.getElementById("Contenido_agregar_dispositivo").disabled = true;
        }
    });
    //Funcion para habilitar boton
    $('#Menu_doc_entrada').keypress(function (event) {
        document.getElementById("Contenido_habilitar_grupo").disabled = false;
        document.getElementById("Menu_Individual").disabled = true;
        document.getElementById("Menu_Unico").disabled = true;
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
    //Limpia campos
    $('#Contenido_cancelar').click(function (event) {
        $("#Contenido_marca").val('Seleccione...');
        $("#Contenido_modelo").val('Seleccione...');
        $("#Contenido_zona").val('GLOBAL');
        $("#Contenido_codigos").val('Seleccione...');
        $("#Contenido_serial").val('');
        $("#Contenido_energia").val('0');
        $("#Contenido_fase").val('0');
        $("#Contenido_nombreGrupo").val('');
        document.getElementById("Contenido_agregar_dispositivo").disabled = false;
    });
    //Validar campos
    $('#Contenido_actualizarSerial').click(function (event) {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#modalSerial').modal('show');</script>");
        console.log('Entro actualizar serial');
    });
});