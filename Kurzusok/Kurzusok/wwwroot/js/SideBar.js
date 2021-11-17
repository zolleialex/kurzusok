let timeout = null;
let collapsedTables = [];
function delay() {
    timeout = setTimeout(closeBar, 1000);
}

function openBar() {
    clearTimeout(timeout);
    document.getElementById("SideBar").style.width = "200px";
    document.getElementById("SideBar").style.padding = "20px";
    document.getElementById("main").style.paddingLeft = "230px";
    document.getElementById("opened").style.display = "inline";
    document.getElementById("closed").style.display = "none";
}
function closeBar() {
    $('.dropdown-toggle').dropdown('hide');
    document.getElementById("SideBar").style.width = "60px";
    document.getElementById("SideBar").style.padding = "20px 0 0 0";
    document.getElementById("main").style.paddingLeft = "90px";
    document.getElementById("opened").style.display = "none";
    document.getElementById("closed").style.display = "inline";
}
