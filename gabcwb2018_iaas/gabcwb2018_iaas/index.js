function ajax(men, method) {
    $.ajax({
        type: "POST",
        url: "Service1.svc/" + method,
        data: JSON.stringify(men),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (msg) {
            $("#lbl").html(msg.mensagemResult)
        }
    })
}