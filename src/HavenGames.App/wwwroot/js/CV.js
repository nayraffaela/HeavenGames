$(document).ready(function () {
    $('#applicationForm').on('submit', function (event) {
        event.preventDefault();
        $.ajax({
            type: $(this).attr('method'),
            url: $(this).attr('action'),
            data: new FormData(this),
            contentType: false,
            processData: false,
            success: function () {
                alert("Sua aplicação para a vaga foi enviada com sucesso!");
            },
            error: function () {
                alert("Houve um erro ao enviar sua aplicação. Por favor, tente novamente.");
            }