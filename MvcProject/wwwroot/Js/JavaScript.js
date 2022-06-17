

function SelectedCategoryForAdmin(){

    let id = document.getElementById("categories").value;
    window.location.href = "/Administrator/ShowAdministratorPage/" + id;
}
function SelectedCategoryForCatalog() {

    let id = document.getElementById("categories").value;
    window.location.href = "/Catalog/ShowCatalogPage/" + id;
}




