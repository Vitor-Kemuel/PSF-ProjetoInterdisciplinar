// 'use strict';
window.onload=function(){
    function cardStyles(div, size, marg){
        div.style.width = size;
        div.style.margin = marg;
        return;
    }

    function flexStylesLine(div, lineFlex){
        div.style.flexDirection = lineFlex;
    }

    function card(size, marg, flex){
        var divs = document.getElementsByTagName("div");
        for(var i=0;i<=divs.length;i++)
        {
            if(divs[i].getAttribute('class') == "cardOrderStatus")
            {
                console.log(divs[i].getAttribute("class"));
                cardStyles(divs[i], size, marg);
            }
            else if(divs[i].className == "orderInformationLine" || divs[i].className == "timeOrderInformation")
            {
                flexStylesLine(divs[i], flex);
            }
        }
    }

    let listBtn = document.getElementById('listDirectionBtn');
    let gridBtn = document.getElementById('gridDirectionBtn');

    listBtn.addEventListener('click', () => {
        var direction = document.querySelector('#orderTable');
        direction.style.flexDirection = "column";

        card("auto", "10px 10%", "row");
    });

    gridBtn.addEventListener('click', () => {
        var direction = document.querySelector('#orderTable');
        direction.style.flexDirection = "row";

        card("40%", "10px", "column");
    });
}

function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Cozinha</h2>";
    var getSession = getSession + "<div id='changeDirection'>";
    var getSession = getSession + "<i id='listDirectionBtn' class='fas fa-list-ul''></i>";
    var getSession = getSession + "<i id='gridDirectionBtn' class='fas fa-th''></i>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "<a id='OptionSession' href='NewOrder'>Fazer Pedido <i class='fas fa-cart-plus'></i></i></a>";

    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}
