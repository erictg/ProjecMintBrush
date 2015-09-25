
//© ArtSharp.co

//created by Eric Solender

//Account Functions to interface account api
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var AccountListEnum = { CommentEntries: 'CommentEntries', EntriesOwned: 'EntriesOwned', EventsOwned: 'EventsOwned' };
Object.freeze(AccountListEnum);


//params of functions : data, textStatus, xhr
function CreateAccount(username, password, email, successFunction, errorFunction) {
    if(typeof(username) !=  "string" || typeof(username) !=  "string" || typeof(email) !=  "string" || typeof(successFunction) != "function" || typeof(errorFunction) != "function"){
        return "error";
    }
    var account = { Username: username, Password: password, Email: email };
    $.ajax({
        url: "http://artsharp.co/api/account/postaccount",
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
    $.getJSON("http://artsharp.co/api/account/getaccount?hexcode=" + hexcode)
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
        url: "http://artsharp.co/api/account/deleteaccount",
        type: "DELETE",
        dataType: "json",
        data: account,
        success: successFunction,
        error: errorFunction
    });
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



//Event Functions
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function CreateEvent(ownerID, startTime, endTime, artistPickTime, minPrice, maxPrice, optimalPrice, successFunction, errorFunction) {

    if (typeof (ownerID) != "string" || typeof (startTime) != "number" || typeof (endTime) != "number" || typeof (artistPickTime) != "number" || typeof (minPrice) != "number" || typeof (maxPrice) != "number" || typeof (optimalPrice) != "numbers" || typeof (successFunction) != "function" || typeof (errorFunction) != "function") {
        throw new Error("error in parameters");
    }
    var object = { OwnedByUser: ownerId, StartTime: startTime, EndTime: endTime, ArtistPickTime: artistPickTime, MinPrice: minPrice, MaxPrice: maxPrice, OptimalPrice: optimalPrice };
    
    $.ajax({
        url: "http://artsharp.co/api/event/postevent",
        type: "POST",
        datType: "json",
        data: object,
        success: successFunction,
        error: errorFunction
    });

}

