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
    console.log(object);

    Property = JSON.parse(object);
    document.getElementById("Title").textContent = Property.Title;
    document.getElementById("Description").textContent = Property.Description;
    document.getElementById("Price").textContent = Property.Price;

    const images = SelectImageByPropertyId(Property.id);
    const slideshow = document.getElementById("slideshow");
    for (const img of images) {
        slideshow.innerHTML = slideshow.innerHTML +
            `
                <li>
                   <img src="${img.Name}" alt="" uk-cover>
                </li>
            `
    }
}

RetrieveData();

let hasClicked = false;

function Click() {
    if (hasClicked) return;

    var today = new Date();
    const date = `${today.getFullYear()}-${today.getMonth() + 1}-${today.getDate()}-${today.getHours()}:${today.getMinutes()}`;

    const click = {
        "Date": date,
        "PropertyId": Property.id
    }

    const ans = AddClick(click);

    if (ans.StatusEffect != 200) {
        alert("مشکلی پیش آمد، لطفا بعدا امتحان کنید");
        return;
    }

    //---> int id
    //---> int PropertyId
    //---> int UserId
    //---> int Status
    //---> string PostDate
    const rel = SelectPropertyClientRelByPropertyId(Property.id);
    console.log(rel);

    try {
        if (rel[0].StatusEffect != 200) {
            alert("مشکلی پیش آمد، لطفا بعدا امتحان کنید");
            return;
        }
    }
    catch {
        alert("مشکلی پیش آمد، لطفا بعدا امتحان کنید");
        return;
    }

    let person = "";

    switch (rel[0].Status) {
        //client
        case 0:
            person = SelectClientById(rel[0].UserId);
            break;
        //constructor
        case 1:
            person = SelectConstructorById(rel[0].UserId);
            break;
        //dealer
        case 2:
            person = SelectDealerById(rel[0].UserId);
            break;
        default:
            break;
    }

    debugger;

    if (person.StatusEffect != 200) {
        alert("مشکلی پیش آمد، لطفا بعدا امتحان کنید");
        console.log(person);
        return;
    }

    const label = document.getElementById("callNumber");
    label.classList.remove("collapsed");
    label.textContent = person.TellNo;

    hasClicked = true;
}