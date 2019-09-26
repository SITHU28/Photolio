// When the user scrolls the page, execute myFunction
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    var winScroll = document.body.scrollTop || document.documentElement.scrollTop;
    var height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
    var scrolled = (winScroll / height) * 100;
    document.getElementById("myBar").style.width = scrolled + "%";

    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
        document.getElementById("Nav").className = "ST-bar" + " ST-card-2" +  " ST-blue";
        document.getElementById("myBtn").style.display = "block";
    }
   
    else {
        document.getElementById("Nav").className = "ST-bar" + " ST-card-2"  + " ST-white";
        document.getElementById("myBtn").style.display = "none";
    }
}

// Change style of navbar on scroll
//window.onscroll = function () { changenavbarstyleFunction() };
//function changenavbarstyleFunction() {
//    var navbar = document.getElementById("Nav");

//    if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
//        navbar.className = "ST-bar" + " ST-card-2" + " ST-animate-top" + " ST-blue";
//        document.getElementById("myBtn").style.display = "block";
//    }
//    else if (document.body.scrollTop < 100 || document.documentElement.scrollTop < 100) {

//        navbar.className = "ST-bar" + " ST-card-2" + " ST-animate-left" + " ST-white";
//        document.getElementById("myBtn").style.display = "block";
//    }
//    else {
//        navbar.className = navbar.className.replace("ST-bar ST-card-2 ST-animate-top ST-blue");
//        document.getElementById("myBtn").style.display = "block";
//    }

//}
/*---------------------------------------------to top function-------------------------------------------*/
// When the user clicks on the button, scroll to the top of the document
function mytopFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}