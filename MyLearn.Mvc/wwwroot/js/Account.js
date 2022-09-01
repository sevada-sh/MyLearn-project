//start preloader

window.addEventListener("load", () =>
    document.querySelector(".preloader").classList.add("hidepreloader"),
    document.querySelector(".body").style.filter = "blur(0px)");

//end preloader

//start reCaptcha

function onSubmit(token) {
    document.getElementById("demo-form").submit();
}

//end reCaptcha