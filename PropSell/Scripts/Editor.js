//---> int id
//---> string Title
//---> string Description
//---> bool Valid
//---> bool ShowToFriends
//---> int UserId
//---> int CityId
//---> string Neighborhood
//---> long Price


let Property = "";

function RetrieveData() {

    const object = localStorage.getItem("property");

    Property = JSON.parse(object);
    document.getElementById("lblName").textContent = Property.Title;
    document.getElementById("txtText").textContent = Property.Description;
    document.getElementById("lblPrice").textContent = Property.Price;

    const city = SelectCityById(Property.CityId);

    document.getElementById("slcity").value = city;

}

RetrieveData();

function AcceptEddition() {

    const currentUser = JSON.parse(localStorage.getItem("user"));

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

    const ans = AddProperty(property);

    if (ans == false || ans.StatusEffect != 200) {
        UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
        return;
    }

    if (ans.id == -1) {
        UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
        return;
    }
}