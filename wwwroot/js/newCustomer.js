function newAdress(){
    var newAdressForm =                 "<h2 class='titleAdress'>Endereço:</h2>";
    var newAdressForm = newAdressForm + "<div class='formLine'>";
    var newAdressForm = newAdressForm + "<input class='formInput cepInput' type='text' placeholder='CEP'>";
    var newAdressForm = newAdressForm + "</div>";
    var newAdressForm = newAdressForm + "<div class='formLine'>";
    var newAdressForm = newAdressForm + "<input class='formInput' type='text' placeholder='Endereço'>";
    var newAdressForm = newAdressForm + "<input class='formInput adressNumber' type='text' placeholder='Numero'>";
    var newAdressForm = newAdressForm + "</div>";
    var newAdressForm = newAdressForm + "<div class='formLine'>";
    var newAdressForm = newAdressForm + "<input class='formInput' type='text' placeholder='Bairro'>";
    var newAdressForm = newAdressForm + "<input class='formInput' type='text' placeholder='Complemento'>";
    var newAdressForm = newAdressForm + "</div><br>";
    
    var adressForm = document.getElementById("adresses");
    adressForm.innerHTML = adressForm.innerHTML + newAdressForm;
}

function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Cadastro de clientes</h2>";
    var getSession = getSession + "</div>";
    
    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}