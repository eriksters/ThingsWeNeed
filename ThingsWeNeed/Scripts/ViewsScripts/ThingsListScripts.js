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
    
    $("button#save_button").click(function () {
        var alertStr = '';
        var needsList = new Array();
        var $theButton = $(this);

        buyMap.forEach(function (value, key) {
            if (value === true) {
                var idString = "#" + key;
                var str = $(document).find(idString).attr("id") + ": " + value;
                var thingPrice = $(document).find(idString).find("input.price_input")[0].value;
                alertStr += idString + "\n";
                alertStr += str + "\n";
                alertStr += thingPrice + "\n \n";

                needsList.push({ ThingId: idString.slice(1, idString.length), ThingPrice: new Number(thingPrice)});

                

                console.debug("hello");


            }
        }); 

        var urlStr = $theButton.data('request-url');
        console.debug(urlStr);

        $.ajax({
            url: urlStr,
            dataType: 'json',
            type: 'POST',
            data: JSON.stringify({ CreateNeeds: needsList }),
            contentType: 'application/json',
            success: function () {
                return data;
            }
        });

        //var xhr = new XMLHttpRequest();
        //xhr.open("POST", "/Needs/Create", true);
        //xhr.setRequestHeader("Content-Type", "application/json");
        //xhr.send(JSON.stringify({
        //    CreateNeeds: needsList
        //}));

    });
});