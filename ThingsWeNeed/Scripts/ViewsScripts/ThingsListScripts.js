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
        var alertStr = '';
        buyMap.forEach(function (value, key) {
            if (value === true) {
                var idString = "#" + key;
                var str = $(document).find(idString).attr("id") + ": " + value;
                var price = $(document).find(idString).find("input.price_input")[0].value;
                alertStr += idString + "\n";
                alertStr += str + "\n";
                alertStr += price + "\n \n";
                count += 1;
            }
        }); 
        console.log(alertStr);
        $.post("/Home/Index/", buyMap);
    });
});