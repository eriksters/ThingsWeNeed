﻿$(function () {
    //  Map that stores the 'buy state' of things
    //  The key is the thing's Id, value is a boolean. TRUE = buying, FALSE = not buying
    var buyMap = new Map();

    //  When a buy button is clicked, add the thing to the buyMap, with a value of TRUE
    $("button.buy_button").click(function() {
        $(this).hide();
        $(this).parent().children("div.btn_stopper")
            .show();
        buyMap.set($(this).closest("tr").attr("id"), true);
    });

    //  When a cancel button is clicked, set the thing's buy state to FALSE
    $("input.cancel_button").click(function() {
        var $divElement = $(this).parent().parent();
        $divElement.parent().children("button.buy_button")
            .show();
        $divElement.hide();
        buyMap.set($(this).closest("tr").attr("id"), false);
    });

    //  Save the purchase
    $("button#save_button").click(function () {

        //  List that stores the items that a User is buying
        var needsList = new Array();
        var $theButton = $(this);

        //  Loop through the buyMap and if a thing is to be bought, add it to the needsList as an Object { ThingId: -id-, ThingPrice: -price- }
        buyMap.forEach(function (value, key) {
            if (value === true) {
                var idString = "#" + key;
                var thingPrice = $(document).find(idString).find("input.price_input")[0].value;
                needsList.push({
                    ThingId: idString.slice(1, idString.length),
                    ThingPrice: new Number(thingPrice)
                });
            }
        }); 

        //  Get the request URL from the HTML tag
        var urlStr = $theButton.data('request-url');

        //  Send the POST request to the server as a JSON
        //  JSON Structure: { createNeeds: [{ThingId: -id1-, ThingPrice: -price1-}..]}
        $.ajax({
            url: urlStr,
            dataType: 'json',
            type: 'POST',
            data: JSON.stringify({ createNeeds: needsList }),
            contentType: 'application/json',
            success: function () {
                return data;
            }
        });
    });
});