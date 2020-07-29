﻿//---> int id
//---> string Title
//---> string Description
//---> bool Valid
//---> bool ShowToFriends
//---> int UserId
//---> int CityId
//---> string Neighborhood
//---> long Price
function generateBlock(divId, model) {

    let div = document.getElementById(divId);
    if (!model.Valid) return;

    let images = SelectImageByPropertyId(model.id);

    if (images == undefined || images == false) images = [{ Name: "" }]
    //console.log("RAW:" + JSON.stringify(model));


    div.innerHTML = div.innerHTML.concat(`
        <!-- #region Model -->

                <div class="model row center" onclick="modelClick(this)">
                    <data class="collapsed">
                        ${JSON.stringify(model)}
                    </data>
                    <div class="column">
                       

                        <header>
                            ${model.Title}
                        </header>

                        <p>
                            ${model.Description}
                        </p>
                        <div class="price row">
                            <img src="../../Resources/Vector/real.svg" class="uk-margin-small-right"/>
                            <label>${model.Price}</label>
                        </div>
                    </div>

                    <img src="${images[0].Name}" alt="" />
                </div>

        <!-- #endregion -->
        `)
}

function modelClick(model) {

    const data = JSON.parse(model.childNodes[1].innerHTML);

    localStorage.setItem("property", JSON.stringify(data));

    window.location = "DbPropertyEditor.html";
}

function openInNewTab(url) {
    var win = window.open(url, '_blank');
    win.focus();
}

function InitializeDashboardBlocks() {

    //switch (localStorage.getItem("userType")) {
    //    case "Client":
    //        SelectPropertyByUserId
    //        break;
    //    case "Constructor"

    //        break;
    //    case "Dealer"
    //        break;

    //    default:
    //}

    const currentUser = JSON.parse(localStorage.getItem("user"));


    const Properties = SelectPropertyByUserId(currentUser.id);

    if (!Properties) return;

    for (let prop of Properties) {
        generateBlock("blocks", prop);
    }


}

InitializeDashboardBlocks()

function PropertyDesigner() {

    //openInNewTab("DbPropertyCreator.html");
    window.location = "DbPropertyCreator.html";
}