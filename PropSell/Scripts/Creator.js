
function AcceptCreation() {

    UploadImages();

    //if (ImageList.length == 0) {
    //    alert("لطفا تعدادی عکس از ملک خود آپلود کنید");
    //    return;
    //}

    //---> string Title
    const Title = document.getElementById("lblName").innerText;
    //---> string Description
    const Description = document.getElementById("txtText").innerText;
    //---> bool Valid
    const Valid = true;
    //---> bool ShowToFriends
    let ShowToFriends = document.getElementById("chShowToFriends").value;
    ShowToFriends = (ShowToFriends == "on") ? true : false;
    //---> int UserId
    const UserId = JSON.parse(localStorage.getItem("user")).id;
    //---> int CityId
    const CityId = 1;
    //---> string Neighborhood
    const NeighborHood = "Here";
    //---> long Price
    const Price = document.getElementById("lblName").innerText;

    const property = {
        Title: Title,
        Description: Description,
        Valid: Valid,
        ShowToFriends: ShowToFriends,
        UserId: UserId,
        CityId: CityId,
        NeighborHood: NeighborHood,
        Price: Price
    }

    const ans = AddProperty(property);

    if (ans == false || ans.StatusEffect != 200) {
        alert("مشکلی پیش آمده لطفا بعدا امتحان کنید");
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
            alert("مشکلی پیش آمده لطفا بعدا امتحان کنید");
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
            alert("لطفا یک بار دیگر لاگین کنید");
            return;
    }


    var today = new Date();
    const date = `${today.getFullYear()}-${today.getMonth() + 1}-${today.getDate()}-${today.getHours()}:${today.getMinutes()}`;

    debugger;

    //--->  id
    //--->  PropertyId
    //--->  UserId
    //--->  Status
    //--->  PostDate
    const rel = {
        id: 0,
        PropertyId: ans.id,
        UserId: UserId,
        Status: Status,
        PostDate: date
    }

    const relAns = AddPropertyClientRel(rel);
}


function UploadImages() {
    // user has not chosen any file
    if (document.querySelector('#file-input').files.length == 0) {
        alert('لطفا عکس انتخاب کنید');
        return;
    }

    // user has not chosen any file
    if (document.querySelector('#file-input').files.length >= 6) {
        alert('لطفا شش عکس انتخاب کنید');
        return;
    }

    for (let file of document.querySelector('#file-input').files) {
        // allowed types
        var mime_types = ['image/jpeg', 'image/png'];

        // validate MIME type
        if (mime_types.indexOf(file.type) == -1) {
            alert('این نوع فایل قابل قبول نیست');
            return;
        }

        // max 2 MB size allowed
        if (file.size > 2 * 1024 * 1024) {
            alert('حد اکثر حجم هر عکس 2 مگا بایت می باشد');
            return;
        }
    }


    // upload file now
    var data = new FormData();

    // file selected by the user
    const files = document.querySelector('#file-input').files;

    // in case of multiple files append each of them
    for (let file of files) {

        data.append('file', document.querySelector('#file-input').files[0]);
    }

    console.log(data);

    const brob = data;
    let ans;

    //ans = AjaxImageUpload(brob);
    $.ajax({
        url: '/api/upload/uploadfile',
        type: 'POST',
        data: brob,
        beforeSend: ShowPreloader(),
        contentType: false,
        processData: false,

        success: function (imageName) {

            ans = imageName;

            SendImagesToTheDatabase(imageName);

        },

        error: function () {
            alert("مشکلی پیش آمده لطفا بعدا امتحان کنید");
            return;
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
const ImageList = [];

function SendImagesToTheDatabase(imageName) {
    document.getElementById("imgspinner").classList.remove("collapsed");

    var bar = document.getElementById('imageProgress');
    bar.max = imageName.length;

    for (let img of imageName) {

        const image = {
            id: 0,
            Name: `/Resources/Imges/${img}`
        }

        const ans = AddImage(image);
        if (ans == false) {
            alert("مشکلی پیش آمده لطفا بعدا امتحان کنید");
            return;
        }

        console.log(ans);

        ImageList.push(ans);

        bar.value += 1;


    }
    document.getElementById("imgspinner").classList.add("collapsed");

}




