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
    var productAddInventoryBtn = document.getElementById("productAddInventoryBtn " + index);

    productEditBtnContainer.removeChild(productEditBtn);
    productEditBtnContainer.removeChild(productAddInventoryBtn);

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
    saveBtn.setAttribute('class', 'productInformation productEditBtn');

    productEditBtnContainer.appendChild(saveBtn);
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

    var productAddInventoryBtn = document.createElement('span');
    productAddInventoryBtn.setAttribute('id', 'productAddInventoryBtn ' + index);
    productAddInventoryBtn.setAttribute('class', 'productInformation productEditBtn')
    productAddInventoryBtn.setAttribute('onClick', 'addInventory("' + index + '","' + nameProduct + '","' + priceValue + '")');
    productAddInventoryBtn.innerHTML = "Adicionar Estoque";

    productEditBtn.setAttribute('onclick', 'editProduct("' + index + '","' + nameProduct + '","' + priceValue + '")');

    productEditBtn.innerHTML = "Editar";

    productEditBtnContainer.appendChild(productAddInventoryBtn)
    productEditBtnContainer.appendChild(productEditBtn)

    var priceContainer = document.getElementById("productPriceContaier " + index);
    var inputPrice = document.getElementById("priceValue " + index);

    priceContainer.removeChild(inputPrice);

    var price = document.createElement('i');
    price.setAttribute('id', 'priceValue ' + index);

    price.innerHTML = parseFloat(priceValue).toFixed(2);

    priceContainer.appendChild(price);

    var saveBtn = document.getElementById('submit ' + index);

    productEditBtnContainer.removeChild(saveBtn)
}

function addInventory(index, nameProduct, priceValue){
    var productEditBtnContainer = document.getElementById("productEditBtnContainer " + index);
    var productEditBtn = document.getElementById("productEditBtn " + index);
    var productAddInventoryBtn = document.getElementById("productAddInventoryBtn " + index);

    var inputAmount = document.createElement('input');
    inputAmount.setAttribute('id', 'amount ' + index);
    inputAmount.setAttribute('class', 'formInput');
    inputAmount.setAttribute('data-mask', '###.##0,00');
    inputAmount.setAttribute('data-mask-reverse', 'true');
    inputAmount.setAttribute('data-mask-selectonfocus', 'true');
    inputAmount.setAttribute('type', 'text');
    inputAmount.setAttribute('placeholder', 'Quantidade');
    inputAmount.setAttribute('name', 'Amount')

    productEditBtnContainer.appendChild(inputAmount)

    productEditBtnContainer.removeChild(productEditBtn);
    productEditBtnContainer.removeChild(productAddInventoryBtn);

    productAddInventoryBtn.setAttribute('onclick', 'cancelAddInventory("' + index +'","' + nameProduct + '","' + priceValue +  '")');

    productAddInventoryBtn.innerHTML = "Cancelar";

    productEditBtnContainer.appendChild(productAddInventoryBtn)

    var saveBtn = document.createElement('input');
    saveBtn.setAttribute('id', 'submit ' + index);
    saveBtn.setAttribute('type', 'submit');
    saveBtn.setAttribute('value', 'Salvar');
    saveBtn.setAttribute('class', 'productInformation productEditBtn');

    productEditBtnContainer.appendChild(saveBtn)
}

function cancelAddInventory(index, nameProduct, priceValue){
    var productEditBtnContainer = document.getElementById("productEditBtnContainer " + index);
    var saveBtn = document.getElementById('submit ' + index);

    productEditBtnContainer.removeChild(saveBtn);

    var inputAmount = document.getElementById('amount ' + index);

    productEditBtnContainer.removeChild(inputAmount);

    var cancelBtn = document.getElementById('productAddInventoryBtn ' + index);
    cancelBtn.setAttribute('onclick', 'addInventory("' + index + '","' + nameProduct + '","' + priceValue + '")');

    cancelBtn.innerHTML = "Adicionar Estoque";

    var productEditBtn = document.createElement('span');
    productEditBtn.setAttribute('id', 'productEditBtn ' + index);
    productEditBtn.setAttribute('class', 'productInformation productEditBtn')
    productEditBtn.setAttribute('onclick', 'editProduct("' + index +'","' + nameProduct + '","' + priceValue +  '")');

    productEditBtn.innerHTML = "Editar";

    productEditBtnContainer.appendChild(productEditBtn)
}
