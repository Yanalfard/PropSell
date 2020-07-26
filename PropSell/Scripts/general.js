function search() {
    const keyword = document.getElementById("searchbox").value;
    alert(keyword);
    localStorage.setItem("keyword", keyword);
    window.location.href = "Search.html";
}