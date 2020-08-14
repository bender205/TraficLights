/*
var ligths = document.getElementsByClassName('circle');


function illuminateRed() {
    clearLights();
    var currentLight = getElementByCurretnId("red");    
    currentLight.style.backgroundColor = "red";
    }

    function illuminateYellow() {        
    clearLights();
        var currentLight = getElementByCurretnId("yellow");    
        currentLight.style.backgroundColor = "orange";
        }

        
        function illuminateGreen() {
            
    clearLights();
            var currentLight = getElementByCurretnId("green");    
            currentLight.style.backgroundColor = "green";
            }
        
function clearLights(){
    for(var i =0; i< ligths.length; i++)
    {
        ligths[i].style.backgroundColor = "#111";
       
    }      
}

    function getElementByCurretnId(color){
        for(var i =0; i< ligths.length; i++)
    {
        if(ligths[i].id == color)
        {
            return ligths[i];
        }
    }      
    }*/

var bulbs = document.getElementsByClassName('bulb');





function changeColor(color) {
    disableAllBulbs();
    if (color == 'red') {
        var red = document.getElementById("red");
        red.style.backgroundColor = color;
    }
    else if (color == 'orange') {
        var orange = document.getElementById("orange");
        orange.style.backgroundColor = color;
    }
    else if (color == 'green') {
        var green = document.getElementById("green");
        green.style.backgroundColor = color;
    }
}


function disableAllBulbs() {
    for (var i = 0; i < bulbs.length; i++) {
        bulbs[i].style.backgroundColor = "grey";
    }

}