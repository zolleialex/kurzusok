$('button[data-toggle="account-delete-modal"]').click(function (event) {
    let users = document.getElementsByClassName("users");
    let div = document.getElementById("names");
    for (var user of users) {
        if (user.checked) {
            let username = document.createElement("p");
            username.setAttribute("class", "d-block");
            username.innerHTML=user.getAttribute("name");
            div.appendChild(username);
            let input = document.createElement('input');
            input.setAttribute("type", "hidden");
            input.setAttribute("value", user.id);
            input.setAttribute("name", "users");
            div.appendChild(input);
        }
    }
    $("#deleteAccount").modal('show');
})