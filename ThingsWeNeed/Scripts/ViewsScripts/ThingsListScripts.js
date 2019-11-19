$(function () {

    //Get the buttons that open the modal
    var btn = document.getElementsByClassName("options-button");

    //Get the button that closes the modal
    var modalCloseButton = document.getElementById("modal-close-button");

    //Get the modal 
    var modal = document.getElementById("myModal");

    //Event listener "click" for buttons opening the modal
    $(btn).click(function () {
        openModal();
    });

    //Open modal on a button click
    function openModal() {
        name = event.currentTarget.name; //name equivalent to Thing's name
        header = document.getElementById("modal-header");
        header.innerText = name;
        modal.style.display = "block"
    }

    //Close the modal when "Close" button is clicked
    $(modalCloseButton).click(function () {
        modal.style.display = "none"
    });


    //When the user clicks anywhere outside of the modal, close it
    $(window).click(function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    });

    //When document is ready, close modal
    $(document).ready(function () {
        modal.style.display = "none"
    });

    //  Map that stores the 'buy state' of things
    //  The key is the thing's Id, value is a boolean. TRUE = buying, FALSE = not buying
    var buyMap = new Map();

    //  When a buy button is clicked, add the thing to the buyMap, with a value of TRUE
    $("button.buy_button").click(function () {
        $(this).hide();
        $(this).parent().children("div.btn_stopper")
            .show();
        buyMap.set($(this).closest("tr").attr("id"), true);
    });

    //  When a cancel button is clicked, set the thing's buy state to FALSE
    $("input.cancel_button").click(function () {
        var $divElement = $(this).parent().parent();
        $divElement.parent().children("button.buy_button")
            .show();
        $divElement.hide();
        buyMap.set($(this).closest("tr").attr("id"), false);
    });

    //  Save the purchase
    $("button#save_button").click(function () {

        //  List that stores the items that a User is buying
        var buyList = new Array();
        var $theButton = $(this);

        //  Loop through the buyMap and if a thing is to be bought, add it to the needsList as an Object { ThingId: -id-, ThingPrice: -price- }
        buyMap.forEach(function (value, key) {
            if (value === true) {
                var idString = "#" + key;
                var thingPrice = $(document).find(idString).find("input.price_input")[0].value;
                buyList.push({
                    ThingId: idString.slice(1, idString.length),
                    ThingPrice: new Number(thingPrice)
                });
            }
        });

        //  Get the request URL from the HTML tag
        var urlStr = $theButton.data('request-url');

        //  Send the POST request to the server as a JSON
        //  JSON Structure: { purchases: [{ThingId: -id1-, ThingPrice: -price1-}..]}
        if (buyList.length > 0) {
            $.ajax({
                url: urlStr,
                dataType: 'json',
                type: 'POST',
                data: JSON.stringify({ purchases: buyList }),
                contentType: 'application/json',
                success: function () {
                    return data;
                }
            });
        }
    });
});


