function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    getSession = getSession + "<h2 class='subTitle'>Novo pedido</h2>";
    getSession = getSession + "</div>";

    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}
