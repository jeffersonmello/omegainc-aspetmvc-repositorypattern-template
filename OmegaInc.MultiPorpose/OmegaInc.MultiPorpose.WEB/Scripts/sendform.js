$('input.btn').on('click', submeter);

function submeter(evento) {

    evento.preventDefault();

    if (validarFormulario()) {

        var url = formulario.prop("action");
        var metodo = formulario.prop("method");

        var dadosFormulario = formulario.serialize();

        waitingDialog.show('Carregando');
        $.ajax({
            url: url,
            type: metodo,
            data: dadosFormulario,
            success: tratarRetorno,
            error: throwErrorException
        });

    }

}

function validarFormulario() {

    btnAcao.prop("disabled", true);
    $(".alert-danger").prop("hidden", true);

    var validado = false;

    // verifica se formulario tem o método valid
    if (formulario.valid == undefined) {

        validado = true;
    }
    else {

        validado = formulario.valid();

        if (!validado) {
            $(".alert-danger").prop("hidden", false);
            $.notify({
                message: 'Ocorreram erros de validação. '
            }, {
                    type: 'danger'
                });
            btnAcao.prop("disabled", false);
        }
    }


    return validado;

}

function throwErrorException(response) {
    waitingDialog.hide();
    swal("Erro!", "Houve um erro na aplicação: " + response, "success");
}

function tratarRetorno(resultadoServidor) {
    waitingDialog.hide();
    if (resultadoServidor.resultado) {

        $.notify({
            message: resultadoServidor.message
        }, {
                type: 'success'
            });

        $('#modal').modal('hide');

        $('#gridDados').bootgrid('reload');

    }
    else {
        $.notify({
            message: 'ERRO: ' + resultadoServidor.message.ErrorMessage
        }, {
                type: 'danger'
            });


        btnAcao.prop("disabled", false);
    }
}