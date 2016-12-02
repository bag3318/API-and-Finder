$(document).ready(function () {
    var $messages = $("#messages");
    $.ajax({
        type: "GET",
        url: "http://localhost:51304/api/Messages",
        success: function (messages) {
            $.each(orders, function (i ,order) {
                $messages.append("<li>" + message.message+"</li>");
            });
        }
    });
});