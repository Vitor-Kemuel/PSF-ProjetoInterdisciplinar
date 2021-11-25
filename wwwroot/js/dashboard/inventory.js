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
    inputName.setAttribute('id', "productName " + index);
    inputName.setAttribute('class', 'formInput');
    inputName.setAttribute('type', 'text');
    inputName.setAttribute('placeholder', 'Nome');
    inputName.setAttribute('name', 'Name');
    inputName.setAttribute('value', nameProduct);

    nameContainer.appendChild(inputName);
    nameContainer.appendChild(hr);

    var productEditBtnContainer = document.getElementById("productEditBtnContainer " + index);
    var productEditBtn = document.getElementById("productEditBtn " + index);

    productEditBtnContainer.removeChild(productEditBtn);

    productEditBtn.setAttribute('onclick', 'cancelEditProduct("' + index + '","' + nameProduct + '","' + priceValue + '")');

    productEditBtn.innerHTML = "Cancelar";

    productEditBtnContainer.appendChild(productEditBtn)

    var priceContainer = document.getElementById("productPriceContaier " + index);
    var price = document.getElementById("priceValue " + index);

    priceContainer.removeChild(price);

    var inputPrice = document.createElement('input');
    inputPrice.setAttribute('id', 'priceValue ' + index);
    inputPrice.setAttribute('class', 'formInput');
    inputPrice.setAttribute('data-mask', '##0,00');
    inputPrice.setAttribute('data-mask-reverse', 'true');
    inputPrice.setAttribute('data-mask-selectonfocus', 'true');
    inputPrice.setAttribute('type', 'text');
    inputPrice.setAttribute('placeholder', 'Preço');
    inputPrice.setAttribute('value', priceValue);
    inputPrice.setAttribute('asp-for', "TypeProduct.Price");

    priceContainer.appendChild(inputPrice);

    var saveBtn = document.createElement('input');
    saveBtn.setAttribute('id', 'submit ' + index);
    saveBtn.setAttribute('type', 'submit')
    saveBtn.setAttribute('value', 'Salvar')

    var priceContainerDiv = document.getElementById("productPriceContaierDiv " + index);
    priceContainerDiv.appendChild(saveBtn);
}

function cancelEditProduct(index, nameProduct, priceValue){
    var nameContainer = document.getElementById("productNameContainer " + index);
    var inputName = document.getElementById("productName " + index);
    var hr = document.getElementById("productLine " + index);

    nameContainer.removeChild(inputName);
    nameContainer.removeChild(hr);

    var name = document.createElement('h2');
    name.setAttribute('id', 'productName ' + index);
    name.setAttribute('class', 'productName');

    name.innerHTML = nameProduct;

    nameContainer.appendChild(name);
    nameContainer.appendChild(hr);

    var productEditBtnContainer = document.getElementById("productEditBtnContainer " + index);
    var productEditBtn = document.getElementById("productEditBtn " + index);

    productEditBtnContainer.removeChild(productEditBtn);

    productEditBtn.setAttribute('onclick', 'editProduct("' + index + '","' + nameProduct + '","' + priceValue + '")');

    productEditBtn.innerHTML = "Editar";

    productEditBtnContainer.appendChild(productEditBtn)

    var priceContainer = document.getElementById("productPriceContaier " + index);
    var inputPrice = document.getElementById("priceValue " + index);

    priceContainer.removeChild(inputPrice);

    var price = document.createElement('i');
    price.setAttribute('id', 'priceValue ' + index);

    price.innerHTML = parseFloat(priceValue).toFixed(2);

    priceContainer.appendChild(price);

    var priceContainerDiv = document.getElementById("productPriceContaierDiv " + index);
    var saveBtn = document.getElementById('submit ' + index);

    priceContainerDiv.removeChild(saveBtn)
}
