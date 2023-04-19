//1- Declare Hub
var connection =
    new signalR.HubConnectionBuilder().withUrl("/ProductsHub").build();
//2- Start connection with hub server==> Clients
connection.start().then(function () {
    console.log("Connection Success!!");
});//online client on hub
//3- send info to hub server
function SendData() {
    var name = document.getElementById("name").value;
    var msg = document.getElementById("text").value;
    const productId = document.getElementById("id").value;


    //RPC from server
    connection.invoke("WriteComment", name, text, productId);
}

//4- recive info come from hub server
connection.on("NotifyNewComment", function (n, t, pid) {
    if (pid == productId)
        document.getElementById("comments").innerHTML +=
            "<li>" + n + ":" + t + "</li>";
});