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

    cardWidth("300px");
}

function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Cozinha</h2>";
    var getSession = getSession + "<div id='changeDirection'>";
    var getSession = getSession + "<span class='fas fa-list-ul' onclick='orderListDirection()'></span>";
    var getSession = getSession + "<span class='fas fa-th' onclick='orderGridDirection()'></span>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "<a id='OptionSession' href='#'>Fazer Pedido +</a>";
    
    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}
