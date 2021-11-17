

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
                success: function (data){

                    var inputResposta = '<div class="d-flex justify-content-start mb-4">'                    
                    inputResposta += '<div class="img_cont_msg">'
                    inputResposta += '<img src="https://static.turbosquid.com/Preview/001292/481/WV/_D.jpg" class="rounded-circle user_img_msg">'
                    inputResposta += '</div>'
                    inputResposta += '<div class="msg_cotainer_send">'
                    inputResposta += '<span id="resp" disabled> ' + mensagem + '</span>'
                    inputResposta += '</div>'
                    inputResposta += '</div'

                    var inputMensagem = '<div class="d-flex justify-content-end mb-4">';                   
                    inputMensagem += '<div class="msg_cotainer">'
                    inputMensagem += '<span id="msg" disabled> ' + data.resposta + '</span>'
                    inputMensagem += '</div>'
                    inputMensagem += '<div class="img_cont_msg" >';
                    inputMensagem += '<img src="https://static.turbosquid.com/Preview/001292/481/WV/_D.jpg" class="rounded-circle user_img_msg">'
                    inputMensagem += '</div>'
                    inputMensagem += '</div>'

                    $("#containerdiv").append(inputResposta);
                    $("#containerdiv").append(inputMensagem);

                    $("#mensagem").val("")
                }
            });
        }
    )
});