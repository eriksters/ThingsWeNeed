function Thing(ThingId, Name, Show, Needed, DefaultPrice, HouseholdId) {
    this.ThingId = ThingId;
    this.Name = Name;
    this.Show = Show;
    this.Needed = Needed;
    this.DefaultPrice = DefaultPrice;
    this.HouseholdId = HouseholdId;
}

function getThingFormData(form) {
    var elems = form.elements;
    var thing = new Thing(
        0,
        elems.Name.value,
        true,
        elems.Needed.checked,
        elems.DefaultPrice.value,
        elems.HouseholdId.value
    );

    return thing;
}

function singleThingResponseHandle(response) {
    return new Thing(
        response.ThingId, 
        response.Name, 
        response.Show, 
        response.Needed, 
        response.DefaultPrice, 
        response.HouseholdId
    );
}

function multipleThingResponseHandle(response) {
    let thingArray = new Array
}

function createThing(thing, successCallback, errorCallback) {
    $.ajax({
        type: 'POST',
        url: '/api/Things',
        data: JSON.stringify(thing),
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleThingResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}

function deleteThing(id, successCallback, errorCallback) {
    $.ajax({
        type: 'DELETE',
        url: '/api/Things',
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleThingResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}

function updateThing(thing, successCallback, errorCallback) {
    $.ajax({
        type: 'PUT',
        url: '/api/Things/' + thing.ThingId,
        data: JSON.stringify(thing),
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleThingResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}

function getThing(id, successCallback, errorCallback) {
    $.ajax({
        type: 'GET',
        url: '/api/Things/' + id,
        data: JSON.stringify(),
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleThingResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}

function getThingCollection(successCallback, errorCallback) {
    $.ajax({
        type: 'GET',
        url: '/api/Things',
        contentType: 'application/json',
        success: function (response) {
            successCallback(multipleThingResponseHandle(response))
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}