//start sidebar

const sidebar = document.querySelector(".sidebar");
const AccountMenubtn = document.querySelector(".AccountMenubtn");
const searchbtn = document.querySelector(".bx-search");

AccountMenubtn.onclick = function () {
    sidebar.classList.toggle("active");
};

searchbtn.onclick = function () {
    sidebar.classList.toggle("active");
};

var chat = document.querySelector(".chat");
var signalr = document.querySelector(".signalr");

chat.onclick = function () {
    signalr.classList.toggle("d-block");
}

//end sidebar

//start menutbn

var hamburgermenu = document.querySelector(".hamburger");
var menuisactive = () => {
    hamburgermenu.classList.toggle("active")
};

hamburgermenu.addEventListener("click", menuisactive)

//end menubtn
