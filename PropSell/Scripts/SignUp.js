const PClient = "Client";
const PConstructor = "Constructor";
const PDealer = "Dealer";

let mode = "None";

function reset() {
    const Client = document.getElementById("Client");
    const Constructor = document.getElementById("Constructor");
    const Dealer = document.getElementById("Dealer");

    Client.classList.add('user');
    Constructor.classList.add('user');
    Dealer.classList.add('user');
    Client.classList.remove('user-selected');
    Constructor.classList.remove('user-selected');
    Dealer.classList.remove('user-selected');

    const txtName = document.getElementById('txtName');
    const txtAddress = document.getElementById('txtAddress');
    txtName.classList.add('collapsed');
    txtAddress.classList.add('collapsed');
}

//Moshtari
function ClientClick() {
    reset()
    const UserInfo = document.querySelector('.user-info');
    UserInfo.textContent = PClient;

    const Client = document.getElementById("Client");
    Client.classList.add('user-selected');
    Client.classList.remove('user');

    mode = "Client";
}


//Forooshandeh
function ConstructorClick() {
    reset()
    const UserInfo = document.querySelector('.user-info');
    UserInfo.textContent = PConstructor;

    const Constructor = document.getElementById("Constructor");
    Constructor.classList.add('user-selected');
    Constructor.classList.remove('user');

    const txtAddress = document.getElementById('txtAddress');
    txtAddress.classList.remove('collapsed');

    mode = "Constructor";
}

//Bongah
function DealerClick() {
    reset()
    const UserInfo = document.querySelector('.user-info');
    UserInfo.textContent = PDealer;

    const Dealer = document.getElementById("Dealer");
    Dealer.classList.add('user-selected');
    Dealer.classList.remove('user');

    const txtName = document.getElementById('txtName');
    const txtAddress = document.getElementById('txtAddress');
    txtName.classList.remove('collapsed');
    txtAddress.classList.remove('collapsed');

    mode = "Dealer";
}


function SignUp() {
    if (mode == "None") {
        UIkit.notification("لطفا نوع حساب خود را تعیین کنید");
        return;
    }

    let ans;
    let userType;

    try {
        switch (mode) {

            case "Client":
                ans = ClientSignUp();
                userType = "client";
                break;

            case "Constructor":
                ans = ConstructorSignUp();
                userType = "constructor";
                break;

            case "Dealer":
                ans = DealerSignUp();
                userType = "dealer";
                break;

            default:
                UIkit.notification("نوع حساب انتخاب نشده است");
        }
    } catch (e) {
        UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
        console.log(e);
        return;
    }

    
    if (ans == undefined) {
        return;
    }
    if (ans == false) {
        UIkit.notification("مشکلی پیش آمده لطفا بعدا امتحان کنید");
        return;
    }
    localStorage.setItem("user", JSON.stringify(ans));
    localStorage.setItem("userType", userType);

    window.location.href = "Dashboard/DbMain.html";
}

function ClientSignUp() {
    debugger;

    const Tel = document.getElementById('Tel').value;
    const Identification = document.getElementById('Identification').value;

    if (Tel == "") {
        UIkit.notification("لطفا شماره تلفن همراه خود را وارد نمایید");
        return;
    }

    if (Tel.length != 11) {
        UIkit.notification("شماره تلفن همراه خود را بدون کد و علامت + وارد نمایید");
        return;
    }

    if (/^\d+$/.test(Tel) == false) {
        UIkit.notification("شماره تلفن صحیح نمی باشد");
        return;
    }

    if (Identification == "") {
        UIkit.notification("لطفا کد ملی خود را وارد نمایید");
        return;
    }

    if (Identification.length != 10) {
        UIkit.notification("کد ملی صحیح نمی باشد");
        return;
    }


    //#region SignUp

    const Client = {
        TellNo: Tel,
        Identification: Identification
    }
    //console.log(Bjax('https://localhost:44374/api/ClientCore/AddClient', Client, 'LP'));
     
    const ans = AddClient(Client);

    if (ans.id == -1) {
        UIkit.notification("این شماره قبلا ثبت شده است");
        return;
    }

    //#endregion

    return ans;
}

function ConstructorSignUp() {
    debugger;

    const Tel = document.getElementById('Tel').value;
    const Identification = document.getElementById('Identification').value;
    const Address = document.getElementById('Address').value;


    if (Tel == "") {
        UIkit.notification("لطفا شماره تلفن همراه خود را وارد نمایید");
        return;
    }

    if (Tel.length != 11) {
        UIkit.notification("شماره تلفن همراه خود را بدون کد و علامت + وارد نمایید");
        return;
    }

    if (/^\d+$/.test(Tel) == false) {
        UIkit.notification("شماره تلفن صحیح نمی باشد");
        return;
    }

    if (Identification == "") {
        UIkit.notification("لطفا کد ملی خود را وارد نمایید");
        return;
    }

    if (Identification.length != 10) {
        UIkit.notification("کد ملی صحیح نمی باشد");
        return;
    }

    if (Address == "") {
        UIkit.notification("لطفا نام خود را وارد نمایید");
        return;
    }

    //#region ()


    const Constructor = {
        Tell: Tel,
        Identification: Identification,
        Address: Address
    }

    const ans = AddConstructor(Constructor);

    if (ans.id == -1) {
        UIkit.notification("این شماره قبلا ثبت شده است");
        return;
    }

    return ans;

    //#endregion
}

function DealerSignUp() {
    debugger;


    const Name = document.getElementById('Name').value;
    const Tel = document.getElementById('Tel').value;
    const Identification = document.getElementById('Identification').value;
    const Address = document.getElementById('Address').value;

    if (Name == "") {
        UIkit.notification("لطفا نام و نام خانوادگی خود را وارد نمایید");
        return;
    }

    if (Tel == "") {
        UIkit.notification("لطفا شماره تلفن همراه خود را وارد نمایید");
        return;
    }

    if (Tel.length != 11) {
        UIkit.notification("شماره تلفن همراه خود را بدون کد و علامت + وارد نمایید");
        return;
    }

    if (/^\d+$/.test(Tel) == false) {
        UIkit.notification("شماره تلفن صحیح نمی باشد");
        return;
    }

    if (Identification == "") {
        UIkit.notification("لطفا کد ملی خود را وارد نمایید");
        return;
    }

    if (Identification.length != 10) {
        UIkit.notification("کد ملی صحیح نمی باشد");
        return;
    }

    if (Address == "") {
        UIkit.notification("لطفا آدرس خود را وارد نمایید");
        return;
    }

    //#region SignUp

    const Dealer = {
        Name: Name,
        TellNo: Tel,
        Identification: Identification,
        Address: Address
    }

    const ans = AddDealer(Dealer);

    if (ans.id == -1) {
        UIkit.notification("این شماره قبلا ثبت شده است");
        return;
    }

    return ans;
    //#endregion
}