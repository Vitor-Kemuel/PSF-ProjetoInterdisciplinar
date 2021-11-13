function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Clientes</h2>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "<a id='OptionSession' href='/Dashboard/NewCustomer'>Novo cliente <i class='fas fa-regular fa-user-plus'></i></a>";

    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}
