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
        alert("لطفا نوع حساب خود را تعیین کنید");
        return;
    }

    switch (mode) {

        case "Client":
            ClientSignUp();
            break;

        case "Constructor":
            ConstructorSignUp();
            break;

        case "Dealer":
            DealerSignUp();
            break;

        default:
            alert("نوع حساب انتخاب نشده است");
    }
}

function ClientSignUp() {
    const Tel = document.getElementById('Tel').value;
    const Identification = document.getElementById('Identification').value;

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

    if (Identification.length != 10) {
        alert("کد ملی صحیح نمی باشد");
        return;
    }


    //#region SignUp

    //debugger;
    const Client = {
        TellNo: Tel,
        Identification: Identification
    }
    //console.log(Bjax('https://localhost:44374/api/ClientCore/AddClient', Client, 'LP'));
     
    const ans = AddClient(Client);
    console.log(ans);

    if (ans.id == -1) {
        alert("این شماره قبلا ثبت شده است");
        return;
    }

    //#endregion

    return true;
}

function ConstructorSignUp() {
    const Tel = document.getElementById('Tel').value;
    const Identification = document.getElementById('Identification').value;
    const Address = document.getElementById('Address').value;


    if (Tel == "") {
        alert("لطفا شماره تلفن همراه خود را وارد نمایید");
        return;
    }

    if (Tel.length != 11) {
        alert("شماره تلفن همراه خود را بدون کد و علامت + وارد نمایید");
        return;
    }

    if (/^\d+$/.test(Tel)) {
        alert("شماره تلفن صحیح نمی باشد");
        return;
    }

    if (Identification == "") {
        alert("لطفا کد ملی خود را وارد نمایید");
        return;
    }

    if (Identification.length != 10) {
        alert("کد ملی صحیح نمی باشد");
        return;
    }

    if (Address == "") {
        alert("لطفا نام خود را وارد نمایید");
        return;
    }

    //#region SignUp

    const Constructor = {
        Tell: Tel,
        Identification: Identification,
        Address: Address
    }

    const ans = AddConstructor(Constructor);

    //#endregion
}

function DealerSignUp() {
    const Name = document.getElementById('Name').value;
    const Tel = document.getElementById('Tel').value;
    const Identification = document.getElementById('Identification').value;
    const Address = document.getElementById('Address').value;

    if (Name == "") {
        alert("لطفا نام و نام خانوادگی خود را وارد نمایید");
        return;
    }

    if (Tel == "") {
        alert("لطفا شماره تلفن همراه خود را وارد نمایید");
        return;
    }

    if (Tel.length != 11) {
        alert("شماره تلفن همراه خود را بدون کد و علامت + وارد نمایید");
        return;
    }

    if (/^\d+$/.test(Tel)) {
        alert("شماره تلفن صحیح نمی باشد");
        return;
    }

    if (Identification == "") {
        alert("لطفا کد ملی خود را وارد نمایید");
        return;
    }

    if (Identification.length != 10) {
        alert("کد ملی صحیح نمی باشد");
        return;
    }

    if (Address == "") {
        alert("لطفا آدرس خود را وارد نمایید");
        return;
    }

    //#region SignUp

    const Dealer = {
        Name: Name,
        Tell: Tel,
        Identification: Identification,
        Address: Address
    }

    //const ans = AddDealer(Dealer);

    //#endregion
}