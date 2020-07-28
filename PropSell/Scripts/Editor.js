
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

    if (province == false) {
        location.reload();
    }

    document.getElementById("Province").value = province.id;

    ChangeProvinceSelection();


    document.getElementById("slcity").value = city.Name;

    document.getElementById("Neighborhood").textContent = Property.Neighborhood;

    //document.getElementById("chShowToFriends").value = Property.ShowToFriends ? "on" : "off";
    document.getElementById("chShowToFriends").checked = Property.ShowToFriends;
}

function AcceptEddition() {

    const currentUser = JSON.parse(localStorage.getItem("user"));
    const currentProperty = JSON.parse(localStorage.getItem("property"));

    const property = {
        Title: document.getElementById("lblName").innerText,
        Description: document.getElementById("txtText").innerText,
        Valid: true,
        ShowToFriends: (document.getElementById("chShowToFriends").value == "on") ? true : false,
        UserId: currentUser.id,
        CityId: 16,
        NeighborHood: "Here",
        Price: document.getElementById("lblPrice").innerText
    }

    //const ans = UpdateProperty(property);

    //if (ans == false || ans.StatusEffect != 200) {
    //    UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
    //    return;
    //}

    //if (ans.id == -1) {
    //    UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
    //    return;
    //}

    const imges = SelectImageByPropertyId(currentProperty.id);

    for (let img of imges) {
        const t = DeleteImage(img.id);
    }


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


//-
RetrieveData();
