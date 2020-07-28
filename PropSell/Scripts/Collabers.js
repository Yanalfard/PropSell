let Friends = "";
let FriendNums = [];

function InitializeFriends() {


    const currentUser = JSON.parse(localStorage.getItem("user"));
    Friends = SelectFriendsByMeId(currentUser.id);

    if (Friends == false) return;
    if (Friends.length == null) return;

    for (let friend of Friends) {
        let user = "";

        const Client = SelectClientById(friend.FriendId);
        if (Client == undefined) return;

        if (Client != false) {
            user = Client;
        }
        else {
            const Dealer = SelectDealerById(friend.FriendId);
            if (Dealer == undefined) return;
            if (Dealer != false) {
                user = Dealer;
            }
            else {
                const Constructor = SelectConstructorById(friend.FriendId);
                if (Constructor == undefined) return;
                if (Constructor != false) {
                    user = Constructor;
                }
                else {
                    UIkit.notification("این شماره در سیستم ثبت نشده است");
                    return;
                }
            }
        }
        console.log(user);

        GenerateFriend(user);
        FriendNums.push(user.TellNo);
    }

    

}

InitializeFriends();

function LookForUser() {
    const Tel = document.getElementById("txtTel").value;

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

    const currentUser = JSON.parse(localStorage.getItem("user"));

    if (currentUser.TellNo == Tel) {
        UIkit.notification("شما نمی توانید خودتان را به عنوان دوست اضافه کنید");
        return;
    }

    if (FriendNums.includes(Tel)) {
        UIkit.notification("این شماره در لیست شما وجود دارد");
        return;
    }

    let user = ""

    const Client = SelectClientByTellNo(Tel);
    if (Client == undefined) return;

    if (Client.id != -1) {
        user = Client;
    }
    else {
        const Dealer = SelectDealerByTellNo(Tel);
        if (Dealer == undefined) return;
        if (Dealer.id != -1) {
            user = Dealer;
        }
        else {
            const Constructor = SelectConstructorByTellNo(Tel);
            if (Constructor == undefined) return;
            if (Constructor.id != -1) {
                user = Constructor;
            }
            else {
                UIkit.notification("این شماره در سیستم ثبت نشده است");
                return;
            }
        }
    }

    //---> int id
    //---> int MeId
    //---> int FriendId
    const object = {
        MeId: currentUser.id,
        FriendId : user.id
    }

    try {
        const ans = AddFriends(object);
    }
    catch
    {
        UIkit.notification("مشکلی پیش آمد لطفا بعدا امتحان کنید");
        return;
    }

    GenerateFriend(user);
    FriendNums.push(user.TellNo);
}

function GenerateFriend(user) {
    const list = document.getElementById("collabers");

    list.innerHTML = list.innerHTML +
        `
            <!-- #region model -->
            <li id="${user.TellNo}" class="row">
                <label>
                    ${user.TellNo}
                </label>
                <button onclick="remove('${user.TellNo}')">
                    <img src="../../Resources/Vector/Icons/cross.svg "  />
                </button>
            </li>
            <!-- #endregion -->
        `
}

function remove(Tel) {
    let user = ""
    const Client = SelectClientByTellNo(Tel);
    if (Client == undefined) return;

    if (Client.id != -1) {
        user = Client;
    }
    else {
        const Dealer = SelectDealerByTellNo(Tel);
        if (Dealer == undefined) return;
        if (Dealer.id != -1) {
            user = Dealer;
        }
        else {
            const Constructor = SelectConstructorByTellNo(Tel);
            if (Constructor == undefined) return;
            if (Constructor.id != -1) {
                user = Constructor;
            }
            else {
                UIkit.notification("این شماره در سیستم ثبت نشده است");
                return;
            }
        }
    }

    debugger;
    const currentUser = JSON.parse(localStorage.getItem("user"));
    const ans = SelectFriendsByFriendIdAndMeId(user.id, currentUser.id);
    const delans = DeleteFriends(ans[0].id);

    if (delans != true) {
        UIkit.notification("مشکلی پیش آمده لطفا بعدا تکرار کنید");
        return;
    }

    const ae = document.getElementById(Tel);
    ae.parentElement.removeChild(ae);

    console.log(ans);



    //Remove Friend by MEID and FriendID

}