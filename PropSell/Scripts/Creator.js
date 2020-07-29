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

function AcceptCreation() {

    if (document.getElementById("lblName").innerText == "") {
        UIkit.notification("لطفا یک تیتر برای ملک خود انتخاب کنید");
        return;
    }
    if (document.getElementById("txtText").innerText == "") {
        UIkit.notification("لطفا مقداری درباره ملک خود توضیح دهید");
        return;
    }
    if (document.getElementById("lblPrice").innerText == "") {
        UIkit.notification("لطفا قیمت ملک خود را وارد کنید");
        return;
    }

    if (/^\d+$/.test(document.getElementById("lblPrice").innerText) == false) {
        UIkit.notification("قسمت قیمت را به ریال و تنها با اعداد وارد کنید");
        return;
    }

    const cit = document.getElementById("slcity").value;
    const prov = document.getElementById("Province").value;

    if (prov == 0) {
        UIkit.notification("لطفا استان خود را انتخاب کنید");
        return;
    }

    if (cit == null || cit == undefined || cit == "") {
        UIkit.notification("لطفا شهر خود را انتخاب کنید");
        return;
    }

    if (document.getElementById("Neighborhood").innerText == "") {
        UIkit.notification("لطفا محله ملک خود را ذکر کنید");
        return;
    }

    if (ImageList == [] || ImageList == false || ImageList.length == 0) {
        UIkit.notification("لطفا تعدادی عکس آپلود کنید");
        return;
    }

    const city = SelectCityByName(cit);

    const currentUser = JSON.parse(localStorage.getItem("user"));

    const property = {
        Title:          document.getElementById("lblName").innerText,
        Description:    document.getElementById("txtText").innerText,
        Valid: true,
        ShowToFriends: (document.getElementById("chShowToFriends").value == "on") ? true : false,
        UserId: currentUser.id,
        CityId: city.id,
        NeighborHood: document.getElementById("Neighborhood").innerText,
        Price:          document.getElementById("lblPrice").innerText
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

    //---> int id
    //---> int PropertyId
    //---> int ImageId
    for (let img of ImageList) {
        const rel = {
            PropertyId: ans.id,
            ImageId: img.id
        }

        const imageAns = AddPropertyImageRel(rel);
        if (imageAns == false || imageAns.StatusEffect != 200) {
            UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
            return;
        }
    }

    let Status = -1;
    switch (localStorage.getItem("userType")) {
        case "client":
            Status = 0;
            break;
        case "constructor":
            Status = 1;
            break;
        case "dealer":
            Status = 2;
            break;
        default:
            UIkit.notification("لطفا یک بار دیگر لاگین کنید");
            return;
    }


    var today = new Date();
    const date = `${today.getFullYear()}-${today.getMonth() + 1}-${today.getDate()}-${today.getHours()}:${today.getMinutes()}`;

    //--->  id
    //--->  PropertyId
    //--->  UserId
    //--->  Status
    //--->  PostDate
    const rel = {
        id: 0,
        PropertyId: ans.id,
        UserId: currentUser.id,
        Status: Status,
        PostDate: date
    }

    const relAns = AddPropertyClientRel(rel);
    if (relAns == false || relAns.StatusEffect != 200) {
        UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
        return;
    }

    window.location.href = 'DbMain.html';
}


function UploadImages(element) {

    debugger;

    // user has not chosen any file
    if (element.files.length == 0) {
        UIkit.notification('لطفا عکس انتخاب کنید');
        return;
    }

    // user has not chosen any file
    if (element.files.length != 1) {
        UIkit.notification('لطفا تنها یک عکس انتخاب کنید');
        return;
    }

    for (let file of element.files) {
        // allowed types
        var mime_types = ['image/jpeg', 'image/png'];

        // validate MIME type
        if (mime_types.indexOf(file.type) == -1) {
            UIkit.notification('این نوع فایل قابل قبول نیست');
            return;
        }

        // max 1 MB size allowed
        if (file.size > 1 * 1024 * 1024) {
            UIkit.notification('حد اکثر حجم هر عکس 1 مگا بایت می باشد');
            return;
        }
    }


    // upload file now
    var data = new FormData();

    // file selected by the user
    const files = element.files;

    // in case of multiple files append each of them
    for (let file of files) {
        data.append('file', file);
    }

    const brob = data;

    $.ajax({
        url: '/api/upload/uploadfile',
        type: 'POST',
        data: brob,
        beforeSend: ShowPreloader(),
        contentType: false,
        processData: false,

        success: function (imageName) {

            SendImagesToTheDatabase(imageName);
            return true;
        },

        error: function () {
            UIkit.notification("در آپلود عکس ها به سرور مشکلی پیش آمد لطفا بعدا امتحان کنید");
            return false;
        }
    });
}

function ShowPreloader() {
    document.getElementById("imgspinner").classList.remove("collapsed");
    var bar = document.getElementById('imageProgress');
    bar.value = bar.max * 0.2;
}

function HidePreloader() {
    document.getElementById("imgspinner").classList.add("collapsed");
}

///Image Objects
let ImageList = [];

function SendImagesToTheDatabase(imageName) {
    document.getElementById("imgspinner").classList.remove("collapsed");

    for (let img of imageName) {

        const image = {
            id: 0,
            Name: `/Resources/Imges/${img}`
        }

        const ans = AddImage(image);
        if (ans == false) {
            UIkit.notification("در تعریف عکس ها در پایگاه داده مشکلی پیش آمده لطفا بعدا امتحان کنید");
            return;
        }

        ImageList.push(ans);

    }

    var bar = document.getElementById('imageProgress');
    bar.value = bar.max;

    document.getElementById("imgspinner").classList.add("collapsed");

}
