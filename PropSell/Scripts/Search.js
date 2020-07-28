Fetch(localStorage.getItem("keyword"));


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

$('.model').click(function () {
    //var x1 = $(this).children("data").val();
    localStorage.setItem("property", $(this).children("data").text());

    openInNewTab("Property.html");
    //console.log(x1);
})

function Fetch(keyword) {

    if (keyword == null || keyword == "") return;

    document.getElementById("searchbox").value = keyword;

    //#region search

    debugger;

    let search = false;

    try {
        search = SelectPropertyByTitle(keyword);
    } catch {

    }

    document.getElementById("browse").innerHTML = "";
    if (search == false) return

    for (let item of search) {
        generateBlock("browse", item);
    }

    //#endregion
}

function SearchClick() {
    const min = document.getElementById("priceMin").value;
    const max = document.getElementById("priceMax").value;

    let props = [];

    if (min != "" && max != "") {
        props = SelectPropertiesByPriceBetween(min, max);
        if (props == null || props == false) {
            return;
        }
    }

    Fetch(document.getElementById('searchbox').value);
}

function ChangeProvinceSelection() {
    const value = document.getElementById("Province").value;
    const citySelector = document.getElementById("slcity");
    if (value == 0) {
        citySelector.innerHTML = "";
        return;
    }

    citySelector.innerHTML = "";
    for (let item of findCityByProvince(ProvinceList[value])) {
        citySelector.innerHTML +=
            `
                    <option value="${item}">${item}</option>
            `
    }
}
