function generateBlocks(count, id) {

    let div = document.getElementById(id);
    console.log(div);
    for (var i = 0; i < count; i++) {
        div.innerHTML = div.innerHTML.concat(`
        <!-- #region Model -->

        <div class="model row center">
            <div class="column">
                <header>
                    لورم ایپسوم متن ساختگی
                </header>

                <p>
                    ${i * 1000}
                </p>
                <div class="price row">
                    <img src="../Resources/Vector/real.svg" />
                    <label>1900000</label>
                </div>
            </div>

            <img src="../Resources/Raster/House.jpeg" alt="" />
        </div>

        <!-- #endregion -->
`)
    }
}

function LoadPremiumBlocks() {
    const prem = SelectPropertyByIsOnFirstPage(true);

    if (prem == false) return;

    for (let model of prem) {
        generateBlock("premium", model);
    }
}

function LoadTop9() {
    const latest = SelectLatestProperties(9);

    if (latest == false) return;

    for (const model of latest) {
        generateBlock("recent", model);
    }
}

//---> int id
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

    const city = SelectCityById(model.CityId);
    const province = SelectProvinceById(city.ProvinceId);

    div.innerHTML = div.innerHTML.concat(`
        <!-- #region Model -->

        <a class="model row center">
            <data class="collapsed">
                ${JSON.stringify(model)}
            </data>
            <div class="column">
                <header>
                    ${model.Title}
                </header>


                <div class="uk-padding-remove right uk-margin-remove-top uk-margin-remove-bottom">
                    <label>
                        ${province.Name}
                    </label>
                    <label >
                        ${city.Name}   
                    </label>
                </div>

                <span class="uk-label uk-margin-auto-left">${model.Neighborhood}</span>

                <p>
                    ${model.Description}
                </p>
                <div class="price row">
                    <img src="../Resources/Vector/real.svg" />
                    <label>${model.Price}</label>
                </div>
            </div>

            <img src="${images[0].Name}" alt="" />
        </a>

        <!-- #endregion -->
        `)
}

LoadPremiumBlocks()
LoadTop9();

$('.model').click(function () {
    //var x1 = $(this).children("data").val();
    localStorage.setItem("property", $(this).children("data").text());

    openInNewTab("Property.html");
    //console.log(x1);
})

function openInNewTab(url) {
    var win = window.open(url, '_blank');
    win.focus();
}

function PropertyDesigner() {
    openInNewTab("DbPropertyCreator")
}