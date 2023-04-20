//1- Declare Hub
var connection =
    new signalR.HubConnectionBuilder().withUrl("/ProductsHub").build();
//2- Start connection with hub server==> Clients
connection.start().then(function () {
    console.log("Connection Success!!");
});//online client on hub

const productId = Number.parseInt(document.getElementById("id").value);

//3- send info to hub server
function SendComment() {
    var name = document.getElementById("name");
    var text = document.getElementById("text");

    //RPC from server
    connection.invoke("WriteComment", name.value, text.value, productId);

    name.value = '';
    text.value = '';
}

function Buy() {
    var qnum = Number.parseInt(document.getElementById("qnum").value);

    //RPC from server
    connection.invoke("Buy", productId, qnum);
}

//4- recive info come from hub server
connection.on("NotifyNewComment", function (n, t, pid) {
    if (pid == productId)
        document.getElementById("comments").innerHTML +=
            '<li class="list-group-item">' + n + ": " + t + '</li>';
});

//4- recive info come from hub server
connection.on("NotifyNewBuy", function (pid, quantity) {
    if (pid == productId) {
        document.getElementById("quantity").innerHTML = quantity
    }
});
//4- recive info come from hub server
connection.on("BuySuccess", function () {
    alert('Success')
});