function remove(){
    var divs = document.getElementsByTagName("div");
    for ( var i = (divs.length) - 1 ; i >- 1 ; i-- ) 
    {
        if(divs[i].className == "adress") 
        {
            divs[i].parentNode.removeChild(divs[i]);
            return;
        }
    }
}

function newAdress(){
    var newAdressForm =                 "<div class='adress'";
    var newAdressForm = newAdressForm + "<h2 class='titleAdress'>Endereço:</h2>";
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
    var newAdressForm = newAdressForm + "</div>";
    
    var adressForm = document.getElementById("adresses");
    adressForm.innerHTML = adressForm.innerHTML + newAdressForm;

    // var trash = document.getElementById("trash");
    // if (trash == null){
    //     var removeOption = document.getElementById("optionAdress");
    //     removeOption.innerHTML = "<span id='trash' class='btnForm trash' onclick='remove()'><i class='fas fa-trash-alt'></i></span>" + removeOption.innerHTML;
    // }
}

function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Cadastro de clientes</h2>";
    var getSession = getSession + "</div>";
    
    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}