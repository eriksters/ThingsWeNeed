$(function () {

    var buyMap = new Map();
    $("button.buy_button").click(function() {
        $(this).hide();
        $(this).parent().children("div.btn_stopper")
            .show();
        buyMap.set($(this).closest("tr").attr("id"), true);
    });

    $("input.cancel_button").click(function() {
        var $divElement = $(this).parent().parent();
        $divElement.parent().children("button.buy_button")
            .show();
        $divElement.hide();
        buyMap.set($(this).closest("tr").attr("id"), false);
        var alertString = '';
        buyMap.forEach(function (value, key) {
            alertString += (key + ": " + value + "\n");
        });
        alert(alertString);
    });

    //Purchase:
    //Paid
    //Id
    
    $("button#save_button").click(function () {
        var purchaseArray = [];
        var count = 0;
        var alertStr = '------';
        buyMap.forEach(function (key, value) {
            if (value == true) {
                var str = $(document).find("#" + key).attr("style");
                alertStr += str + '\n'
            }
        }); 
        alert(alertStr);
        $.post('/Home/Index', buyMap);
    });
});