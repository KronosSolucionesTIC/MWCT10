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
        $("#Contenido_energia").val('0');
        $("#Contenido_fase").val('0');
        $("#Contenido_nombreGrupo").val('');
    });
    //Validar campos
    $('#Contenido_actualizarSerial').click(function (event) {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#modalSerial').modal('show');</script>");
        console.log('Entro actualizar serial');
    });
});