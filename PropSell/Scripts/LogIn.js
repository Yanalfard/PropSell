if (JSON.parse(localStorage.getItem("user")) != null) {
    window.location.href = "Dashboard/DbMain.html";
}

function login() {
    const Tel = document.getElementById("Tel").value;
    const Identification = document.getElementById("Identification").value;

    if (Tel == "") {
        alert("لطفا شماره تلفن همراه خود را وارد نمایید");
        return;
    }

    if (Tel.length != 11) {
        alert("شماره تلفن همراه خود را بدون کد و علامت + وارد نمایید");
        return;
    }

    if (/^\d+$/.test(Tel) == false) {
        alert("شماره تلفن صحیح نمی باشد");
        return;
    }

    if (Identification == "") {
        alert("لطفا کد ملی خود را وارد نمایید");
        return;
    }

    const client = SelectClientByTellNo(Tel);
    const constructor = SelectConstructorByTellNo(Tel);
    const dealer = SelectDealerByTellNo(Tel)

    let user = "";
    let userType = "";
    if (client.id != -1) {
        userType = "client";
        user = client;
    }
    else if (constructor.Identification != -1) {
        userType = "constructor";
        user = constructor;
    }
    else if (dealer.id != -1) {
        userType = "dealer";
        user = dealer;
    }

    if (userType === "") {
        alert("این شماره در سیستم ثبت نشده است");
        return;
    }

    if (user.Identification !== Identification) {
        alert("کد ملی درست وارد نشده است");
        return;
    }
    //retrieve with 
    //const a = JSON.parse(localStorage.getItem("user"));
    localStorage.setItem("user", JSON.stringify(user));
    localStorage.setItem("userType", userType);

    window.location.href = "Dashboard/DbMain.html";

}