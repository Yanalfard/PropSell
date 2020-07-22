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




}