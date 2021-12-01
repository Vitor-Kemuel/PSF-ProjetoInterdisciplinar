function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Carrinho</h2>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "<a id='OptionSession' href='../DashboardCustomer/CartCustomer'>Finalizar compra</a>";

    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}
