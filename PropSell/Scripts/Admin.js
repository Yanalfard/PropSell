﻿function RemoveRecord(id) {

    const todelete = document.getElementById(`record${id}`);
    todelete.parentElement.removeChild(todelete);
}

function RemoveProperty(id) {
    const ans = DeleteProperty(id);
    if (ans == false) return;

    RemoveRecord(id);
}

function RemoveClient(id) {

    const properties = SelectPropertyByUserId(id);

    for (let property of properties) {
        property.Valid = false;
        const delans = UpdateProperty(property, property.id);
    }

    const friends = SelectFriendsByMeId(id);

    for (let friend of friends) {
        const delans = DeleteFriends(friend.id);
    }

    const ans = DeleteClient(id);
    if (ans == false) return;

    RemoveRecord(id);
}

function RemoveConstructor(id) {
    const properties = SelectPropertyByUserId(id);

    for (let property of properties) {
        property.Valid = false;
        const delans = UpdateProperty(property, property.id);
    }

    const friends = SelectFriendsByMeId(id);

    for (let friend of friends) {
        const delans = DeleteFriends(friend.id);
    }

    const ans = DeleteConstructor(id);
    if (ans == false) return;

    RemoveRecord(id);
}

function RemoveDealer() {
    const properties = SelectPropertyByUserId(id);

    for (let property of properties) {
        property.Valid = false;
        const delans = UpdateProperty(property, property.id);
    }

    const friends = SelectFriendsByMeId(id);

    for (let friend of friends) {
        const delans = DeleteFriends(friend.id);
    }

    const ans = DeleteDealer(id);
    if (ans == false) return;

    RemoveRecord(id);
}

function LoadProperties() {

    let properties = SelectAllPropertys();
    properties = SelectAllPropertys();

    if (properties == false || properties == undefined) return;

    const tbody = document.getElementById("tbody");



    for (let prop of properties) {
        let isChecked = (prop.Valid) ? 'checked' : '';
        let isVisible = (prop.ShowToFriends) ? 'checked' : '';
        let isOnFirstPage = (prop.IsOnFirstPage) ? 'checked' : '';

        let city = SelectCityById(prop.CityId).Name;
        if (city == false || city == undefined) city = prop.CityId;

        tbody.innerHTML +=
            `
            <tr id="record${prop.id}">
                <td class="uk-margin-auto-left">${prop.id}</td>
                <td>${prop.Title}</td>
                <td>${prop.Description}</td>
                <td><input class="uk-checkbox " disabled type="checkbox" ${isChecked} /></td>
                <td><input class="uk-checkbox " disabled type="checkbox" ${isVisible} /></td>
                <td>${prop.UserId}</td>
                <td>${city}</td>
                <td>${prop.Neighborhood}</td>
                <td>${prop.Price}</td>
                <td><input class="uk-checkbox " disabled type="checkbox" ${isOnFirstPage} /></td>
                <td><button class="uk-button    uk-button-danger" onclick="RemoveProperty(${prop.id})">حذف</button></td>
            </tr>  
            `;
    }
}

function LoadClients() {

    const clients = SelectAllClients();

    if (clients == false || clients == undefined) return;

    const tbody = document.getElementById("tbody");

    //---> int id
    //---> string TellNo
    //---> string Identification
    for (let client of clients) {
        tbody.innerHTML +=
            `
            <tr id="record${client.id}">
                <td>${client.id}</td>
                <td>${client.TellNo}</td>
                <td>${client.Identification}</td>
                <td><button class="uk-button uk-button-danger" onclick="RemoveClient(${client.id})">حذف</button></td>
            </tr>  
            `;
    }

}

function LoadDealers() {

    const dealers = SelectAllConstructors();


    if (dealers == false || dealers == undefined) return;

    const tbody = document.getElementById("tbody");

    //---> int id
    //---> string TellNo
    //---> string Identification
    //---> string Address
    //---> string Name
    for (let dealer of dealers) {
        tbody.innerHTML +=
            `
            <tr id="record${dealer.id}">
                <td>${dealer.id}</td>
                <td>${dealer.TellNo}</td>
                <td>${dealer.Identification}</td>
                <td>${dealer.Address}</td>
                <td><button class="uk-button uk-button-danger" onclick="RemoveDealer(${dealer.id})">حذف</button></td>
            </tr>  
            `;
    }
}

function LoadConstructors() {

    const constructors = SelectAllPropertys();

    if (constructors == false || constructors == undefined) return;

    const tbody = document.getElementById("tbody");

    //---> int id
    //---> string TellNo
    //---> string Identification
    //---> string Address
    for (let constructor of constructors) {
        tbody.innerHTML +=
            `
            <tr id="record${constructor.id}">
                <td>${constructor.id}</td>
                <td>${constructor.TellNo}</td>
                <td>${constructor.Identification}</td>
                <td>${constructor.Address}</td>
                <td><button class="uk-button uk-button-danger" onclick="RemoveConstructor(${constructor.id})">حذف</button></td>
            </tr>  
            `;
    }
}



