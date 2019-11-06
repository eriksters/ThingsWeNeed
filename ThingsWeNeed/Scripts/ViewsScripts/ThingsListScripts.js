$(function () {
    $("button.buy_button").click(function() {
        $(this).hide();
        $(this).parent().children("div.btn_stopper")
            .show();
    });

    $("input.cancel_button").click(function() {
        var $divElement = $(this).parent().parent();
        $divElement.parent().children("button.buy_button")
            .show();
        $divElement.hide();
    });
});