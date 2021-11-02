

var setChat = document.getElementById("containerdiv");            

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
                    $("#msg").append(mensagem);
                    $("#resp").append(data.resposta);

                    $("#mensagem").val("")
                    setChat.classList.toggle("hide");
                }
            });
        }
    )
});

$(document).ready(function () {
    $('#action_menu_btn').click(function () {
        $('containerdiv').toggle();
    });
});