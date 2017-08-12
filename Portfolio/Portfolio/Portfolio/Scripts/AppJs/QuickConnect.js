var notifyMsg = function (msg, color) {
    $.notify({
        // options
        message: msg
    }, {
        // settings
        type: color,
        placement: {
            from: "bottom",
            align: "right"
        },
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        }
    }
);
};

var sentMessage = function (data) {
    if (data.Status === "Success") {
        notifyMsg(data.Message, "success");
        $(this).find("button").prop("disabled", false).text('Send');
    }
    if (data.Status === "Error") {
        notifyMsg(data.Message, "danger");
        $(this).find("button").prop("disabled", false).text('Send');
    }
}

var exceptionOccur = function () {
    notifyMsg("Error Occurred. Please Try Later !", "danger");
    $(this).find("button").prop("disabled", false).text('Send');
}