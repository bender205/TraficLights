
var bulbs = document.getElementsByClassName('bulb');




function changeColor(color) {
    disableAllBulbs();

    if (color == 'red') {
        setYellowColor();

        setTimeout(function () {
            disableAllBulbs();
        }, 2000);

        var red = document.getElementById("red"); 
        setTimeout(function () {
            red.style.backgroundColor = color;      
        }, 2000);

    }
   
    else if (color == 'green') {
        setYellowColor(); 
        
        setTimeout(function () {
            disableAllBulbs();
        }, 2000);
        var green = document.getElementById("green");
        setTimeout(function () {
            green.style.backgroundColor = color;
        }, 2000);
           
       

    }
}


function disableAllBulbs() {
    for (var i = 0; i < bulbs.length; i++) {
        bulbs[i].style.backgroundColor = "grey";
    }

}

function setYellowColor() {
    var yellow = document.getElementById("yellow");  
    yellow.style.backgroundColor = "yellow";    
    
}