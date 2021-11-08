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
    var adressForm = document.getElementById("adresses");
    
    var elementoAdress = document.createElement('div');
    elementoAdress.setAttribute('class', 'adress');
    
    var elementoTitleAdress = document.createElement('h2');
    elementoTitleAdress.setAttribute('class', 'titleAdress');
    elementoTitleAdress.textContent = 'Endereço:';
    
    var elementoFormLine = document.createElement('div');
    elementoFormLine.setAttribute('class', 'formLine');
    
    var elementoFormInputCEP = document.createElement('input');
    elementoFormInputCEP.setAttribute('class', 'formInput cepInput');
    elementoFormInputCEP.setAttribute('type', 'text');
    elementoFormInputCEP.setAttribute('placeholder', 'CEP');
    elementoFormInputCEP.setAttribute('name', 'ZipCodeAddress');
    
    var elementoFormLine2 = document.createElement('div');
    elementoFormLine2.setAttribute('class', 'formLine');
    
    var elementoFormInputAdress = document.createElement('input');
    elementoFormInputAdress.setAttribute('class', 'formInput');
    elementoFormInputAdress.setAttribute('type', 'text');
    elementoFormInputAdress.setAttribute('placeholder', 'Endereço');
    elementoFormInputAdress.setAttribute('name', 'NameAddress');
    
    var elementoFormInputAdressNumber = document.createElement('input');
    elementoFormInputAdressNumber.setAttribute('class', 'formInput adressNumber');
    elementoFormInputAdressNumber.setAttribute('type', 'text');
    elementoFormInputAdressNumber.setAttribute('placeholder', 'Numero');
    elementoFormInputAdressNumber.setAttribute('name', 'NumberAddress');
    
    var elementoFormLine3 = document.createElement('div');
    elementoFormLine3.setAttribute('class', 'formLine');

    var elementoFormInputDistrict = document.createElement('input');
    elementoFormInputDistrict.setAttribute('class', 'formInput');
    elementoFormInputDistrict.setAttribute('type', 'text');
    elementoFormInputDistrict.setAttribute('placeholder', 'Bairro');
    elementoFormInputDistrict.setAttribute('name', 'District');

    var elementoFormInputComplementAddress = document.createElement('input');
    elementoFormInputComplementAddress.setAttribute('class', 'formInput');
    elementoFormInputComplementAddress.setAttribute('type', 'text');
    elementoFormInputComplementAddress.setAttribute('placeholder', 'Complemento');
    elementoFormInputComplementAddress.setAttribute('name', 'ComplementAddress');

    adressForm.appendChild(elementoAdress);

    elementoAdress.appendChild(elementoTitleAdress);
    elementoAdress.appendChild(elementoFormLine);
    elementoFormLine.appendChild(elementoFormInputCEP)

    elementoAdress.appendChild(elementoFormLine2);
    elementoFormLine2.appendChild(elementoFormInputAdress)
    elementoFormLine2.appendChild(elementoFormInputAdressNumber)
    
    elementoAdress.appendChild(elementoFormLine3);
    elementoFormLine3.appendChild(elementoFormInputDistrict)
    elementoFormLine3.appendChild(elementoFormInputComplementAddress)
}

function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Cadastro de clientes</h2>";
    var getSession = getSession + "</div>";
    
    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}
