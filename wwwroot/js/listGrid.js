function cardWidth(size){
    var divs =document.getElementsByTagName("div");
    for(var i=0;i<=divs.length;i++) 
    {
        if(divs[i].className == "cardOrderStatus") 
        {
            divs[i].style.width = size;
        }
    }
}

function orderListDirection(){
    var direction = document.querySelector('#orderTable');
    direction.style.flexDirection = "column";
    
    cardWidth("auto")
}

function orderGridDirection(){
    var direction = document.querySelector('#orderTable');
    direction.style.flexDirection = "row";

    cardWidth("300px")
}