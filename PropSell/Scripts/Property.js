let Property = "";

function RetrieveData() {

    const object = localStorage.getItem("property");

    Property = JSON.parse(object);
    document.getElementById("Title").textContent = Property.Title;
    document.getElementById("Description").textContent = Property.Description;
    document.getElementById("Price").textContent = Property.Price;
    document.getElementById("NeighborHood").textContent = Property.Neighborhood;

    const city = SelectCityById(Property.CityId);
    const province = SelectProvinceById(city.ProvinceId)

    document.getElementById("Province").textContent = province.Name;
    document.getElementById("City").textContent = city.Name;


    const images = SelectImageByPropertyId(Property.id);
    const slideshow = document.getElementById("slideshow");
    const sliderNav = document.getElementById("sliderNav");

    if (images == false) {
        document.querySelector(".slide-show").classList.add('collapsed');
        return;
    }

    for (const img of images) {
        slideshow.innerHTML = slideshow.innerHTML +
            `
                <li id=${img.Name}>
                   <img src="${img.Name}" uk-cover>
                </li>
            `;
        sliderNav.innerHTML = sliderNav.innerHTML +
            `
                <li uk-slideshow-item="${images.indexOf(img)}"><a href="#"><img src="${img.Name}"></a></li>
            `;

    }
}

RetrieveData();

let hasClicked = false;

function Click() {
    if (hasClicked) return;

    debugger;

    var today = new Date();
    const date = `${today.getFullYear()}-${today.getMonth() + 1}-${today.getDate()}-${today.getHours()}:${today.getMinutes()}`;

    const click = {
        "Date": date,
        "PropertyId": Property.id
    }

    const ans = AddClick(click);

    if (ans.StatusEffect != 200) {
        UIkit.notification("مشکلی پیش آمد، لطفا بعدا امتحان کنید");
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
            UIkit.notification("مشکلی پیش آمد، لطفا بعدا امتحان کنید");
            return;
        }
    }
    catch {
        UIkit.notification("مشکلی پیش آمد، لطفا بعدا امتحان کنید");
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


    if (person.StatusEffect != 200) {
        UIkit.notification("مشکلی پیش آمد، لطفا بعدا امتحان کنید");
        console.log(person);
        return;
    }

    const label = document.getElementById("callNumber");
    label.classList.remove("collapsed");
    label.textContent = person.TellNo;

    hasClicked = true;
}