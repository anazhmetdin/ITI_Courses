//1- Declare Hub
var connection =
    new signalR.HubConnectionBuilder().withUrl("/ProductsHub").build();
//2- Start connection with hub server==> Clients
connection.start().then(function () {
    console.log("Connection Success!!");
});//online client on hub

//3- send info to hub server
connection.on("NotifyNewProduct", function (product) {
    document.querySelector("tbody").innerHTML +=
        `<tr>
            <td>
                ${product['name']}
            </td>
            <td>
                ${product['description']}
            </td>
            <td>
                ${product['price']}
            </td>
            <td>
                ${product['quantity']}
            </td>
            <td>
                <a href="/Products/Edit/${product['id']}" >Edit</a> |
                <a href="/Products/Details/${product['id']}" >Details</a> |
                <a href="/Products/Delete/${product['id']}" >Delete</a>
            </td>
        </tr>`;
});
