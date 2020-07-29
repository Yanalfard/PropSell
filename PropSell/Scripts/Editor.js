
let Property = "";

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

function RetrieveData() {

    const object = localStorage.getItem("property");

    Property = JSON.parse(object);
    document.getElementById("lblName").textContent = Property.Title;
    document.getElementById("txtText").textContent = Property.Description;
    document.getElementById("lblPrice").textContent = Property.Price;

    const city = SelectCityById(Property.CityId);
    const province = SelectProvinceById(city.ProvinceId);

    //if (province == false) {
    //    location.reload();
    //}

    document.getElementById("Province").value = province.id;

    ChangeProvinceSelection();


    document.getElementById("slcity").value = city.Name;

    document.getElementById("Neighborhood").textContent = Property.Neighborhood;

    //document.getElementById("chShowToFriends").value = Property.ShowToFriends ? "on" : "off";
    document.getElementById("chShowToFriends").checked = Property.ShowToFriends;
}

function InvalidateProperty() {
    const currentProperty = JSON.parse(localStorage.getItem("property"));
    currentProperty.Valid = false;

    const ans = UpdateProperty(currentProperty, currentProperty.id);

    if (ans == false || ans == undefined) return;

    window.location.href = 'DbMain.html';
}

function AcceptEddition() {

    const currentUser = JSON.parse(localStorage.getItem("user"));
    const currentProperty = JSON.parse(localStorage.getItem("property"));

    const cit = document.getElementById("slcity").value;
    const prov = document.getElementById("Province").value;

    const city = SelectCityByName(cit);


    const property = {
        //id: currentProperty.id,
        Title: document.getElementById("lblName").innerText,
        Description: document.getElementById("txtText").innerText,
        Valid: true,
        ShowToFriends: (document.getElementById("chShowToFriends").value == "on") ? true : false,
        UserId: currentUser.id,
        CityId: city.id,
        NeighborHood: document.getElementById("Neighborhood").innerText,
        Price: document.getElementById("lblPrice").innerText
    }

    const ans = UpdateProperty(property, currentProperty.id);

    if (ans == false) {
        UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
        return;
    }

    if (ans.id == -1) {
        UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
        return;
    }

    localStorage.setItem("property", JSON.stringify(property));

    if (ImageList.length != 0) {
        //-user has uploaded images

        const imges = SelectImageByPropertyId(currentProperty.id);

        if (imges != false) {
            for (let img of imges) {
                const t = DeleteImage(img.id);
            }
        }
        //-there used to be no images


        //---> int id
        //---> int PropertyId
        //---> int ImageId
        for (let img of ImageList) {
            const rel = {
                PropertyId: currentProperty.id,
                ImageId: img.id
            }

            const imageAns = AddPropertyImageRel(rel);
            if (imageAns == false || imageAns.StatusEffect != 200) {
                UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
                return;
            }
        }

    }


    window.location = "DbMain.html";
}


//-
RetrieveData();
