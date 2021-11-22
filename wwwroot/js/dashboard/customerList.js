function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Clientes</h2>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "<a id='OptionSession' href='./NewCustomer'>Novo cliente <i class='fas fa-regular fa-user-plus'></i></a>";

    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}

function showAddress(index){
    console.log(index);
    var address = document.getElementById(index);
    address.style.display = "flex";
    address.style.flexDirection = "column";

    var btn = document.getElementById("spanShow "+index);
    btn.style.display = "none";
    var btn = document.getElementById("spanHide "+index);
    btn.style.display = "flex";
}

function hideAddress(index){
    console.log(index);
    var address = document.getElementById(index);
    address.style.display = "none";

    var btn = document.getElementById("spanShow "+index);
    btn.style.display = "flex";
    var btn = document.getElementById("spanHide "+index);
    btn.style.display = "none";
}
