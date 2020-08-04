function search(input, link) {
    
    const keyword = document.getElementById(input).value;

    if (keyword == "Admin") {
        window.location.href = "Admin/AdClient.html";
        return;
    }

    localStorage.setItem("keyword", keyword);
    window.location.href = link;
}

function LogOut() {
    localStorage.removeItem("user");
    localStorage.removeItem("userType");
    window.location.href = "../Landing.html";
}