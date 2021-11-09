function getSession(){
    var getSession =              "<div id='sessionLeft'>";
    var getSession = getSession + "<h2 class='subTitle'>Novo Produto</h2>";
    var getSession = getSession + "</div>";
    
    var session = document.getElementById("session");
    session.innerHTML = session.innerHTML + getSession;
}

window.onload=function(){
    let image = document.getElementById('productImagePreview');
    let input = document.getElementById('productImage');

    image.addEventListener('click', () => {
        input.click();
    });

    input.addEventListener('change', () => {
        let reader = new FileReader();

        reader.onload = () => {
            image.src = reader.result;
        }

        reader.readAsDataURL(input.files[0])
    });
}