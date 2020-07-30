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

    const city = SelectCityById(model.CityId);
    const province = SelectProvinceById(city.ProvinceId);

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

                <div class="uk-padding-remove right uk-margin-remove-top uk-margin-remove-bottom">
                    <label>
                        ${province.Name}
                    </label>
                    <label >
                        ${city.Name}   
                    </label>
                </div>

                <p>
                    ${model.Description}
                </p>
                <div class="price row">
                    <img src="../Resources/Vector/real.svg" />
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

    window.location = "Property.html";
    //openInNewTab("DbPropertyEditor.html");
}

function Fetch(keyword) {

    if (keyword == null || keyword == "") return;

    document.getElementById("searchbox").value = keyword;

    //#region search

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

    const prov = document.getElementById("Province").value;
    const city = document.getElementById("slcity").value;
    const name = document.getElementById("searchbox").value;

    const searchProvince = (prov == 0) ? false : true;
    const searchCity = (city == 0) ? false : true;
    const searchName = (name == "") ? false : true;

    //user chosen ids
    let provinceId = prov;
    let cityId = SelectCityByName(city).id;

    let props = [];

    document.getElementById("browse").innerHTML = "";
    if (min != "" && max != "") {
        props = SelectPropertiesByPriceBetween(min, max);
        if (props == null || props == false) {
            return;
        }

        for (let prop of props) {
            if (searchName) {
                if (!prop.Title.includes(name)) continue;
            }

            if (searchProvince) {
                const propCity = SelectCityById(prop.CityId);
                const propProvince = SelectProvinceById(propCity.ProvinceId);

                if (propProvince.id != provinceId) continue;

                if (searchCity) {
                    if (propCity.id != cityId) continue;
                }
            }

            generateBlock("browse", prop);
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
