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
    }*//*

var bulbs = document.getElementsByClassName('bulb');




function changeColor(color) {
    disableAllBulbs();
    if (color == 'red') {

       *//* var yellow = document.getElementById("yellow");
        setTimeout(yellow.style.backgroundColor = color,1000);*//*


        var red = document.getElementById("red");
        red.style.backgroundColor = color;
    }
    else if (color == 'yellow') {
        var yellow = document.getElementById("yellow");
        yellow.style.backgroundColor = color;
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

function setYellowColor() {
    var yellow = document.getElementById("yellow");
    yellow.style.backgroundColor = color;
}*/

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