(function () {
    $.connection.hub.start()
        .done(function () {
            console.log("It worked");
            $.connection.notificationHub.server.announce("Connected!");
        })
        .fail(function () {
            alert("Error");
        });

    $.connection.notificationHub.client.announce = function (message) {
        $('#welcome-messages').append(message + "<br />");
    }
})()