
//params of functions : data, textStatus, xhr
function CreateAccount(username, password, email, successFunction, errorFunction) {
    if(typeof(username) !=  "string" || typeof(username) !=  "string" || typeof(email) !=  "string" || typeof(successFunction) != "function" || typeof(errorFunction) != "function"){
        return "error";
    }
    var account = { Username: username, Password: password, Email: email };
    $.ajax({
        url: "http://localhost:64898/api/account/postaccount",
        type: "POST",
        datType: "json",
        data: account,
        success: successFunction,
        error: errorFunction
    });
}

//pass 'done' into done function -- this is the json for what was returned
function QueryAccount(doneFunction, hexcode) {
    if (typeof (doneFunction) != "function") {
        return "error";
    }
    $.getJSON("http://localhost:64898/api/account/getaccount?hexcode=" + hexcode)
      .done(doneFunction);
}

//params : data, textStatus, xhr
function UpdateAccount(hexcode1, idToUpdate1, listToUpdate1, isAdding1, successFunction, errorFunction) {
    if (typeof (hexcode1) != "string" || typeof (idToUpdate1) != "string" || typeof (listToUpdate1) != "string" || typeof (isAdding1) != "boolean" || typeof (successFunction) != "function" || typeof (errorFunction) != "function") {
        return "error";
    }
    var update = { hexCode: hexcode1, idToUpdate: idToUpdate1, listToUpdate: listToUpdate1, isAdding: isAdding1 };
    $.ajax({
        url: "http://localhost:64898/api/account/updateaccount",
        type: "UPDATE",
        datType: "json",
        data: update,
        success: successFunction,
        error: errorFunction
    });

}
function DeleteAccount(username, password, email, successFunction, errorFunction) {
    if (typeof (username) != "string" || typeof (password) != "string" || typeof (email) != "string" || typeof (successFunction) != "function" || typeof (errorFunction) != "function") {
        return "error";
    }
    var account = {Username: username, Password: password, Email: email}
    $.ajax({
        url: "http://localhost:64898/api/account/deleteaccount",
        type: "DELETE",
        dataType: "json",
        data: account,
        success: successFunction,
        error: errorFunction
    });
}