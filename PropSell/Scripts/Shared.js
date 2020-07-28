function generateBlock(divId, model) {

    let div = document.getElementById(divId);
    if (!model.Valid) return;

    let images = SelectImageByPropertyId(model.id);

    if (images == undefined || images == false) images = [{ Name: "" }]
    //console.log("RAW:" + JSON.stringify(model));


    div.innerHTML = div.innerHTML.concat(`
        <!-- #region Model -->

        <a class="model row center" onclick="modelClick(this)">
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
        </a>

        <!-- #endregion -->
        `)
}

function modelClick(model) {

    const data = JSON.parse(model.childNodes[1].innerHTML);

    localStorage.setItem("property", JSON.stringify(data));

    openInNewTab("../Property.html");
}

function openInNewTab(url) {
    var win = window.open(url, '_blank');
    win.focus();
}

function InitializeDashboardBlocks() {
    debugger;

    const currentUser = JSON.parse(localStorage.getItem("user"));

    const Properties = SelectFriendsProperties(currentUser.id);

    if (Properties == false) return;

    for (let prop of Properties) {
        generateBlock("blocks", prop);
    }
}

InitializeDashboardBlocks()

function PropertyDesigner() {

    openInNewTab("DbPropertyCreator.html");
}