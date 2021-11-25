function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Estoque</h2>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "</div>";
    var getSession = getSession + "<a id='OptionSession' href='./NewProduct'>Novo produto +</a>";

    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}

function editProduct(index, nameProduct, priceValue){
    var nameContainer = document.getElementById("productNameContainer " + index);
    var name = document.getElementById("productName " + index);
    var hr = document.getElementById("productLine " + index);

    nameContainer.removeChild(name);
    nameContainer.removeChild(hr);

    var inputName = document.createElement('input');
    inputName.setAttribute('class', 'formInput');
    inputName.setAttribute('type', 'text');
    inputName.setAttribute('placeholder', 'Nome');
    inputName.setAttribute('name', 'Name');
    inputName.setAttribute('value', nameProduct);

    nameContainer.appendChild(inputName);
    nameContainer.appendChild(hr);

    var priceContainer = document.getElementById("productPriceContaier " + index);
    var price = document.getElementById("priceValue " + index);

    priceContainer.removeChild(price);

    var inputprice = document.createElement('input');
    inputprice.setAttribute('class', 'formInput');
    inputprice.setAttribute('data-mask', '##0,00');
    inputprice.setAttribute('data-mask-reverse', 'true');
    inputprice.setAttribute('data-mask-selectonfocus', 'true');
    inputprice.setAttribute('type', 'text');
    inputprice.setAttribute('placeholder', 'Preço');
    inputprice.setAttribute('value', priceValue);
    inputprice.setAttribute('asp-for', "TypeProduct.Price");

    priceContainer.appendChild(inputprice);

    var saveBtn = document.createElement('input');
    saveBtn.setAttribute('type', 'submit')
    saveBtn.setAttribute('value', 'Salvar')

    var priceContainerDiv = document.getElementById("productPriceContaierDiv " + index);
    priceContainerDiv.appendChild(saveBtn);
}

