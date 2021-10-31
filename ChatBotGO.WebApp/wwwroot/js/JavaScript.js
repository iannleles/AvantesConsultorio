$(function () {
    $("#Enviar").click(
        function () {
            var mensagem = $("#mensagem").val();

            var stringUrl = "api/Chat"

            $.ajax({
                type: "POST",
                url: stringUrl,
                async: false,
                data: { mensagem: mensagem },

                success: function (data) {
                    $("#displaymensagem").append(" >> EU : " + mensagem + "\n");
                    $("#displaymensagem").append(data.resposta + "\n");

                    $("#mensagem").val("")
                }
            });
        }
    )
});