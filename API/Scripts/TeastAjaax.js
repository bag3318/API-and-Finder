$(document).ready(function () {
    var $messages = $("#messages");
    $.ajax({
        type: "GET",
        url: "/api/Messages",
        success: function (messages) {
            $.each(orders, function (i ,order) {
                $messages.append("<li>" + messages.message+"</li>");
            });
        }
    });
});