var logoffSuccessful = false;
function logOffClicked() {
    logoff(logoffSuccessCallback, logoffErrorCallback);
    return logoffSuccessful;
}

function logoffSuccessCallback() {
    logoffSuccessful = true;
}

function logoffErrorCallback() {
    logoffSuccessful = false;
    alert("Logoff failed. Not sure what happens now!");
}