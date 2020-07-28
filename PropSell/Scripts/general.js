function search(input, link) {
    const keyword = document.getElementById(input).value;
    localStorage.setItem("keyword", keyword);
    window.location.href = link;
}

function LogOut() {
    localStorage.removeItem("user");
    localStorage.removeItem("userType");
    window.location.href = "../Landing.html";
}